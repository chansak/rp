﻿using AutoMapper;
using RP.Website.Models;
using RP.Model;
using System.Collections.Generic;
using System.Linq;
using System;
using RP.Interfaces;
using RP.Website.Extensions;

namespace RP.Website
{
    public static class EntityExtension
    {
        public static Document ToEntity(this DocumentViewModel viewModel)
        {

            Guid _documentId = Guid.NewGuid();
            if (!string.IsNullOrEmpty(viewModel.Id))
            {
                _documentId = new System.Guid(viewModel.Id);
            }
            var document = new Document();
            document.Id = _documentId;
            document.BiddingStatusId = (int)BiddingStatus.Waiting;
            //document.ExpiryDate = DateTime.Parse(viewModel.ExpirationDate);
            document.UserId = viewModel.SaleUserId;
            document.CustomerId = new System.Guid(viewModel.CustomerId);
            document.ContactId = new System.Guid(viewModel.ContactId);
            document.PoNumber = viewModel.PoNumber;
            //document.CustomerBranchId = new System.Guid(viewModel.CustomerBranchId);
            foreach (var i in viewModel.Items)
            {
                var itemId = Guid.NewGuid();
                var item = new DocumentProductItem
                {
                    Id = itemId,
                    ProductId = new System.Guid(i.ProductId),
                    ProductUnitId = new System.Guid(i.ProductUnitId),
                    Amount = i.Amount,
                    PricePerUnit = (decimal)i.PricePerUnit
                };
                var printOption1 = new ProductItemPrintOptional();
                var printOption2 = new ProductItemScreenOptional();
                var printOption3 = new ProductItemSewOptional();
                var printStatus = (ItemOptionStatus)i.PrintOption.SelectedOption;
                switch (printStatus)
                {
                    case ItemOptionStatus.ExistingPattern:
                        {
                            printOption1.Id = Guid.NewGuid();
                            printOption1.OptionalStatusId = 1;
                            printOption1.ProductItemId = itemId;
                            printOption1.PatternId = new Guid(i.PrintOption.PatternId.ToString());
                            break;
                        }
                    case ItemOptionStatus.NewPattern:
                        {
                            printOption1.Id = Guid.NewGuid();
                            printOption1.OptionalStatusId = 2;
                            printOption1.ColorCodeId = new Guid(i.PrintOption.ColorId);
                            printOption1.ProductItemId = itemId;

                            break;
                        }
                    case 0:
                        {
                            break;
                        }
                }
                var screenStatus = (ItemOptionStatus)i.ScreenOption.SelectedOption;
                switch (screenStatus)
                {
                    case ItemOptionStatus.ExistingPattern:
                        {
                            printOption2.Id = Guid.NewGuid();
                            printOption2.OptionalStatusId = 1;
                            printOption2.ProductItemId = itemId;
                            printOption2.PatternId = new Guid(i.ScreenOption.PatternId.ToString());
                            break;
                        }
                    case ItemOptionStatus.NewPattern:
                        {
                            printOption2.Id = Guid.NewGuid();
                            printOption2.OptionalStatusId = 2;
                            printOption2.ColorCodeId = new Guid(i.ScreenOption.ColorId);
                            printOption2.PatternPositionId = new Guid(i.ScreenOption.ColorId);
                            printOption2.ProductItemId = itemId;

                            break;
                        }
                    case 0:
                        {
                            break;
                        }
                }
                var sewStatus = (ItemOptionStatus)i.SewOption.SelectedOption;
                switch (sewStatus)
                {
                    case ItemOptionStatus.ExistingPattern:
                        {
                            printOption3.Id = Guid.NewGuid();
                            printOption3.OptionalStatusId = 1;
                            printOption3.ProductItemId = itemId;
                            printOption3.PatternId = new Guid(i.SewOption.PatternId.ToString());
                            break;
                        }
                    case ItemOptionStatus.NewPattern:
                        {
                            printOption3.Id = Guid.NewGuid();
                            printOption3.OptionalStatusId = 2;
                            printOption3.PatternPositionId = new Guid(i.SewOption.PositionId);
                            printOption3.ProductItemId = itemId;
                            printOption3.Remark = i.SewOption.Remark;
                            break;
                        }
                    case 0:
                        {
                            break;
                        }
                }
                if (i.PrintOption.SelectedOption > 0)
                {
                    item.ProductItemPrintOptionals.Add(printOption1);
                }
                if (i.ScreenOption.SelectedOption > 0)
                {
                    item.ProductItemScreenOptionals.Add(printOption2);
                }
                if (i.SewOption.SelectedOption > 0)
                {
                    item.ProductItemSewOptionals.Add(printOption3);
                }
                document.DocumentProductItems.Add(item);
            }
            //document.DeliveryContactId = new System.Guid(viewModel.DeliveryContactId);
            var delivery = new DocumentDelivery
            {
                Id = Guid.NewGuid(),
                DocumentId = _documentId,
                Address1 = viewModel.DeliveryAddress
            };
            document.DocumentDeliveries.Add(delivery);
            document.RefPriceAndRemark = viewModel.Remark;
            document.ConfirmedPriceDays = viewModel.ConfirmPriceDays;
            document.DeliveryDays = viewModel.DeliveryDays;
            document.IsDelete = false;
            return document;
        }
        public static DocumentViewModel ToViewModel(this Document entity)
        {
            var document = new DocumentViewModel();
            document.DocumentStatusId = entity.DocumentStatusId.Value;
            document.Id = entity.Id.ToString();
            document.DocumentCode = entity.FileNumber;
            document.CreatedDate = entity.CreatedDate.HasValue ? entity.CreatedDate.Value.ToDateString() : "";
            //document.IssuedDate = entity.IssueDate.HasValue ? entity.IssueDate.Value.ToDateString() : "";
            document.ExpirationDate = entity.ExpiryDate.HasValue ? entity.ExpiryDate.Value.ToDateString() : "";
            document.ExpectedDeliveryDate = entity.ExpectedDeliveryDate.HasValue ? entity.ExpectedDeliveryDate.Value.ToDateString() : "";
            //document.ExpirationDate = entity.ExpiryDate.Value;
            //document.ExpectedDeliveryDate = entity.ExpectedDeliveryDate.Value;

            document.ConfirmPriceDays = entity.ConfirmedPriceDays == null ? 0 : entity.ConfirmedPriceDays.Value;
            document.DeliveryDays = entity.DeliveryDays == null ? 0 : entity.DeliveryDays.Value;

            document.SaleUserId = entity.UserId.ToString();
            document.CustomerId = entity.CustomerId.ToString();
            document.ContactId = entity.ContactId.ToString();
            document.PoNumber = entity.PoNumber;
            document.PoDate = entity.PoDate.HasValue ? entity.PoDate.Value.ToDateString() : "";
            var productItems = new List<ProductItemViewModel>();
            foreach (var i in entity.DocumentProductItems.Where(i => !i.IsDeleted))
            {
                var printOptions = new List<PrintOptionViewModel>();
                if (i.ProductItemPrintOptionals.Count > 0)
                {
                    var o1 = i.ProductItemPrintOptionals.FirstOrDefault();
                    var printStatus = (ItemOptionStatus)o1.OptionalStatusId;
                    switch (printStatus)
                    {
                        case ItemOptionStatus.ExistingPattern:
                            {
                                var p1 = GenericFactory.Business.GetPatternImageById(o1.PatternId.ToString());
                                var path = string.Format(@"../../../FileUpload/{0}",
                                            p1.PatternImagePath.Replace(@"\", @"/")
                                            .Split(new string[] { @"FileUpload" }, StringSplitOptions.None)[1]
                                            .Remove(0, 1));
                                printOptions.Add(new PrintOptionViewModel
                                {
                                    PatternName = p1.PatternName,
                                    SelectedOption = o1.OptionalStatusId,
                                    PatternId = o1.PatternId.ToString(),
                                    PatternImagePath = path
                                });
                                break;
                            }
                        case ItemOptionStatus.NewPattern:
                            {
                                var p1 = GenericFactory.Business.GetPatternImageById(o1.PatternId.ToString());
                                var color = GenericFactory.Business.GetColorById(o1.ColorCodeId.Value.ToString());
                                var path = string.Format(@"../../../FileUpload/{0}",
                                            p1.PatternImagePath.Replace(@"\", @"/")
                                            .Split(new string[] { @"FileUpload" }, StringSplitOptions.None)[1]
                                            .Remove(0, 1));
                                printOptions.Add(new PrintOptionViewModel
                                {
                                    PatternName = p1.PatternName,
                                    SelectedOption = o1.OptionalStatusId,
                                    PatternImagePath = path,
                                    ColorName = color.ColorName,
                                    ColorId = color.Id.ToString()
                                });
                                break;
                            }
                    }

                }

                var screenOptions = new List<ScreenOptionViewModel>();
                if (i.ProductItemScreenOptionals.Count > 0)
                {
                    var o2 = i.ProductItemScreenOptionals.FirstOrDefault();
                    var screenStatus = (ItemOptionStatus)o2.OptionalStatusId;
                    switch (screenStatus)
                    {
                        case ItemOptionStatus.ExistingPattern:
                            {
                                var p1 = GenericFactory.Business.GetPatternImageById(o2.PatternId.ToString());
                                var path = string.Format(@"../../../FileUpload/{0}",
                                            p1.PatternImagePath.Replace(@"\", @"/")
                                            .Split(new string[] { @"FileUpload" }, StringSplitOptions.None)[1]
                                            .Remove(0, 1));
                                screenOptions.Add(new ScreenOptionViewModel
                                {
                                    PatternName = p1.PatternName,
                                    SelectedOption = o2.OptionalStatusId,
                                    PatternId = o2.PatternId.ToString(),
                                    PatternImagePath = path,
                                    PositionId = o2.PatternPositionId.ToString(),
                                });
                                break;
                            }
                        case ItemOptionStatus.NewPattern:
                            {
                                var color = GenericFactory.Business.GetColorById(o2.ColorCodeId.Value.ToString());
                                var position = GenericFactory.Business.GetPositionById(o2.PatternPositionId.Value.ToString());
                                var p1 = GenericFactory.Business.GetPatternImageById(o2.PatternId.ToString());
                                var path = string.Format(@"../../../FileUpload/{0}",
                                            p1.PatternImagePath.Replace(@"\", @"/")
                                            .Split(new string[] { @"FileUpload" }, StringSplitOptions.None)[1]
                                            .Remove(0, 1));
                                screenOptions.Add(new ScreenOptionViewModel
                                {
                                    PatternName = p1.PatternName,
                                    SelectedOption = o2.OptionalStatusId,
                                    PatternImagePath = path,
                                    PositionId = o2.PatternPositionId.ToString(),
                                    ColorId = color.Id.ToString(),
                                    ColorName = color.ColorName,
                                    PositionName = position.PositionName
                                });
                                break;
                            }
                    }
                }

                var sewOptions = new List<SewOptionViewModel>();
                if (i.ProductItemSewOptionals.Count > 0)
                {
                    var o3 = i.ProductItemSewOptionals.FirstOrDefault();
                    var sewStatus = (ItemOptionStatus)o3.OptionalStatusId;
                    switch (sewStatus)
                    {
                        case ItemOptionStatus.ExistingPattern:
                            {
                                var p1 = GenericFactory.Business.GetPatternImageById(o3.PatternId.ToString());
                                var path = string.Format(@"../../../FileUpload/{0}",
                                            p1.PatternImagePath.Replace(@"\", @"/")
                                            .Split(new string[] { @"FileUpload" }, StringSplitOptions.None)[1]
                                            .Remove(0, 1));
                                sewOptions.Add(new SewOptionViewModel
                                {
                                    PatternName = p1.PatternName,
                                    SelectedOption = o3.OptionalStatusId,
                                    PatternImagePath = path,
                                    PatternId = o3.PatternId.ToString()
                                });
                                break;
                            }
                        case ItemOptionStatus.NewPattern:
                            {
                                var position = GenericFactory.Business.GetPositionById(o3.PatternPositionId.Value.ToString());
                                var p1 = GenericFactory.Business.GetPatternImageById(o3.PatternId.ToString());
                                var path = string.Format(@"../../../FileUpload/{0}",
                                            p1.PatternImagePath.Replace(@"\", @"/")
                                            .Split(new string[] { @"FileUpload" }, StringSplitOptions.None)[1]
                                            .Remove(0, 1));
                                sewOptions.Add(new SewOptionViewModel
                                {
                                    PatternName = p1.PatternName,
                                    SelectedOption = o3.OptionalStatusId,
                                    PatternImagePath = path,
                                    PositionId = o3.PatternPositionId.ToString(),
                                    PositionName = position.PositionName,
                                    Remark = o3.Remark
                                });
                                break;
                            }
                    }

                }

                productItems.Add(new ProductItemViewModel
                {
                    ItemId = i.Id.ToString(),
                    ProductId = i.ProductId.ToString(),
                    ProductCategoryId = i.Product.ProductCategoryId.ToString(),
                    ProductName = i.Product.Name,
                    ProductUnitId = i.ProductUnitId.ToString(),
                    ProductUnitName = i.Unit.UnitName,
                    PricePerUnit = i.PricePerUnit,
                    Amount = i.Amount,
                    PrintOption = printOptions.FirstOrDefault(),
                    ScreenOption = screenOptions.FirstOrDefault(),
                    SewOption = sewOptions.FirstOrDefault()
                });
            }
            document.Items = productItems;
            document.DeliveryAddress = entity.DocumentDeliveries.FirstOrDefault().Address1;
            document.DeliveryContactId = entity.DeliveryContactId.ToString();
            document.Remark = string.IsNullOrEmpty(entity.RefPriceAndRemark) ? "" : entity.RefPriceAndRemark;
            document.PoNumber = string.IsNullOrEmpty(entity.PoNumber) ? "" : entity.PoNumber;

            document.CreatedBy = entity.AspNetUser.Id;
            document.SaleName = entity.AspNetUser.DisplayName;
            document.SaleCode = "";
            document.SaleBranch = "";
            document.CustomerName = entity.Customer.Name;
            document.HospitalName = (entity.Customer.CustomerBranches.Count() == 0) ? "" : entity.Customer.CustomerBranches.FirstOrDefault().CustomerBranchName;
            document.CustomerType = entity.Customer.CustomerType.CustomerTypeName;

            document.ContactName = entity.CustomerContact == null ? "" : entity.CustomerContact.Name;
            document.ContactTel = entity.CustomerContact == null ? "" : (string.IsNullOrEmpty(entity.CustomerContact.Phone) ? "" : entity.CustomerContact.Phone);
            document.ContactFax = entity.CustomerContact == null ? "" : (string.IsNullOrEmpty(entity.CustomerContact.Fax) ? "" : entity.CustomerContact.Fax);
            document.ContactMobile = entity.CustomerContact == null ? "" : (string.IsNullOrEmpty(entity.CustomerContact.Mobile) ? "" : entity.CustomerContact.Mobile);
            document.ContactEmail = entity.CustomerContact == null ? "" : entity.CustomerContact.Email;

            var histories = new List<HistoryViewModel>();
            foreach (var history in entity.Histories)
            {
                histories.Add(new HistoryViewModel
                {
                    Text = history.Text,
                    Type =history.HistoryTypeId.Value,
                    CreatedDate = history.CreatedDate
                });
            }
            document.Histories = histories;
            document.ConfirmPriceDays = entity.ConfirmedPriceDays.HasValue ? entity.ConfirmedPriceDays.Value : 0;
            document.DeliveryDays = entity.DeliveryDays.HasValue ? entity.DeliveryDays.Value : 0;
            var WorkflowStatus = (WorkflowStatus)entity.DocumentStatusId;
            document.WorkFlowName = WorkflowStatus.ToWorkFlowStatusName();
            return document;
        }

        public static CustomerViewModel ToViewModel(this Customer entity)
        {
            var customer = new CustomerViewModel();
            customer.Id = entity.Id.ToString();
            customer.Name = entity.Name;
            customer.HospitalName = entity.CustomerBranches.FirstOrDefault().CustomerBranchName;
            customer.CustomerTypeName = entity.CustomerType.CustomerTypeName;
            return customer;
        }
        public static ContactViewModel ToViewModel(this CustomerContact entity)
        {
            var contact = new ContactViewModel();
            contact.Id = entity.Id.ToString();
            contact.Name = entity.Name;
            contact.Phone = entity.Phone;
            contact.Mobile = entity.Mobile;
            contact.Email = entity.Email;
            contact.Fax = entity.Fax;
            return contact;
        }
        public static SaleUserViewModel ToViewModel(this AspNetUser entity)
        {
            var user = new SaleUserViewModel();
            user.Id = entity.Id.ToString();
            user.Name = entity.DisplayName;
            user.Code = entity.Code;
            return user;
        }

        public static ProductItemViewModel ToViewModel(this DocumentProductItem entity)
        {
            var item = new ProductItemViewModel();
            item.ItemId = entity.Id.ToString();
            item.ProductId = entity.Product.Id.ToString();
            item.ProductName = entity.Product.Name;
            item.ProductUnitId = entity.ProductUnitId.ToString();
            item.ProductUnitName = entity.Unit.UnitName;
            item.Amount = entity.Amount;
            item.PricePerUnit = entity.PricePerUnit;
            var o1 = GenericFactory.Business.GetProductItemPrintOptionalByItemId(entity.Id.ToString());
            var printOption = new PrintOptionViewModel();
            if (o1 != null)
            {
                var pattern = GenericFactory.Business.GetPatternImageById(o1.PatternId.ToString());
                var path = string.Format(@"../../../FileUpload/{0}",
                                            pattern.PatternImagePath.Replace(@"\", @"/")
                                            .Split(new string[] { @"FileUpload" }, StringSplitOptions.None)[1]
                                            .Remove(0, 1));
                var color = GenericFactory.Business.GetColorById(o1.ColorCodeId.ToString());
                printOption.Id = o1.Id.ToString();
                printOption.PatternId = pattern.Id.ToString();
                printOption.PatternName = pattern.PatternName;
                printOption.PatternImagePath = path;
            }
            item.PrintOption = printOption;
            var o2 = GenericFactory.Business.GetProductItemScreenOptionalByItemId(entity.Id.ToString());
            var screenOption = new ScreenOptionViewModel();
            if (o2 != null)
            {
                var pattern = GenericFactory.Business.GetPatternImageById(o2.PatternId.ToString());
                var color = GenericFactory.Business.GetColorById(o2.ColorCodeId.ToString());
                screenOption.Id = o2.Id.ToString();
                if (pattern != null)
                {
                    var path = string.Format(@"../../../FileUpload/{0}",
                            pattern.PatternImagePath.Replace(@"\", @"/")
                            .Split(new string[] { @"FileUpload" }, StringSplitOptions.None)[1]
                            .Remove(0, 1));

                    screenOption.PatternId = pattern.Id.ToString();
                    screenOption.PatternName = pattern.PatternName;
                    screenOption.PatternImagePath = path;
                }
                if (o2.PatternPositionId != null)
                {
                    var position = GenericFactory.Business.GetPositionById(o2.PatternPositionId.ToString());
                    screenOption.PositionId = position.Id.ToString();
                    screenOption.PositionName = position.PositionName;
                }
            }
            item.ScreenOption = screenOption;
            var o3 = GenericFactory.Business.GetProductItemSewOptionalByItemId(entity.Id.ToString());
            var sewOption = new SewOptionViewModel();
            if (o3 != null)
            {
                sewOption.Id = o3.Id.ToString();
                var pattern = GenericFactory.Business.GetPatternImageById(o3.PatternId.ToString());
                var position = GenericFactory.Business.GetPositionById(o3.PatternPositionId.ToString());
                if (pattern != null)
                {
                    sewOption.PatternId = pattern.Id.ToString();
                    sewOption.PatternName = pattern.PatternName;
                    var path = string.Format(@"../../../FileUpload/{0}",
                                pattern.PatternImagePath.Replace(@"\", @"/")
                                .Split(new string[] { @"FileUpload" }, StringSplitOptions.None)[1]
                                .Remove(0, 1));
                    sewOption.PatternImagePath = path;
                }
                if (position != null)
                {
                    sewOption.PositionId = position.Id.ToString();
                    sewOption.PositionName = position.PositionName;
                }
                sewOption.Remark = o3.Remark;
            }
            item.SewOption = sewOption;
            item.ProductCategoryId = entity.Product.ProductCategoryId.ToString();
            item.ProductOptionId = entity.ProductOptionId.ToString();
            item.MaterialId = entity.MaterialId.ToString();
            return item;
        }

        public static DocumentProductItem ToViewModel(this ProductAndOptionViewModel model)
        {
            var itemId = Guid.NewGuid();
            var item = new DocumentProductItem
            {
                Id = itemId,
                ProductId = new System.Guid(model.ProductId),
                ProductUnitId = new System.Guid(model.ProductUnitId),
                ProductOptionId = new System.Guid(model.ProductOptionId),
                Amount = model.Amount,
                PricePerUnit = (decimal)model.PricePerUnit,
                MaterialId = new System.Guid(model.MaterialId)
            };
            var printOption1 = new ProductItemPrintOptional();
            var printOption2 = new ProductItemScreenOptional();
            var printOption3 = new ProductItemSewOptional();
            var printStatus = (ItemOptionStatus)model.PrintOption.SelectedOption;
            switch (printStatus)
            {
                case ItemOptionStatus.ExistingPattern:
                    {
                        printOption1.Id = Guid.NewGuid();
                        printOption1.OptionalStatusId = 1;
                        printOption1.ProductItemId = itemId;
                        printOption1.PatternId = new Guid(model.PrintOption.PatternId.ToString());
                        break;
                    }
                case ItemOptionStatus.NewPattern:
                    {
                        printOption1.Id = Guid.NewGuid();
                        printOption1.OptionalStatusId = 2;
                        printOption1.ColorCodeId = new Guid(model.PrintOption.ColorId);
                        printOption1.ProductItemId = itemId;

                        break;
                    }
                case 0:
                    {
                        break;
                    }
            }
            var screenStatus = (ItemOptionStatus)model.ScreenOption.SelectedOption;
            switch (screenStatus)
            {
                case ItemOptionStatus.ExistingPattern:
                    {
                        printOption2.Id = Guid.NewGuid();
                        printOption2.OptionalStatusId = 1;
                        printOption2.ProductItemId = itemId;
                        printOption2.PatternId = new Guid(model.ScreenOption.PatternId.ToString());
                        break;
                    }
                case ItemOptionStatus.NewPattern:
                    {
                        printOption2.Id = Guid.NewGuid();
                        printOption2.OptionalStatusId = 2;
                        printOption2.ColorCodeId = new Guid(model.ScreenOption.ColorId);
                        printOption2.PatternPositionId = new Guid(model.ScreenOption.ColorId);
                        printOption2.ProductItemId = itemId;

                        break;
                    }
                case 0:
                    {
                        break;
                    }
            }
            var sewStatus = (ItemOptionStatus)model.SewOption.SelectedOption;
            switch (sewStatus)
            {
                case ItemOptionStatus.ExistingPattern:
                    {
                        printOption3.Id = Guid.NewGuid();
                        printOption3.OptionalStatusId = 1;
                        printOption3.ProductItemId = itemId;
                        printOption3.PatternId = new Guid(model.SewOption.PatternId.ToString());
                        break;
                    }
                case ItemOptionStatus.NewPattern:
                    {
                        printOption3.Id = Guid.NewGuid();
                        printOption3.OptionalStatusId = 2;
                        printOption3.PatternPositionId = new Guid(model.SewOption.PositionId);
                        printOption3.ProductItemId = itemId;
                        printOption3.Remark = model.SewOption.Remark;
                        break;
                    }
                case 0:
                    {
                        break;
                    }
            }
            if (model.PrintOption.SelectedOption > 0)
            {
                item.ProductItemPrintOptionals.Add(printOption1);
            }
            if (model.ScreenOption.SelectedOption > 0)
            {
                item.ProductItemScreenOptionals.Add(printOption2);
            }
            if (model.SewOption.SelectedOption > 0)
            {
                item.ProductItemSewOptionals.Add(printOption3);
            }
            return item;
        }

        public static History ToEntity(this MobileHistoryViewModel viewModel)
        {

            return new History
            {
                Id = new Guid(viewModel.Id),
                DocumentId = new Guid(viewModel.DocumentId),
                HistoryTypeId = viewModel.HistoryTypeId,
                UserId = viewModel.UserId,
                Text = viewModel.Text
            };
        }

        public static ProductCategory ToEntity(this ProductCategoryViewModel viewmodel)
        {
            return new ProductCategory
            {
                Id = new Guid(viewmodel.Id),
                CategoryName = viewmodel.CategoryName
            };
        }
        public static ProductCategoryViewModel ToViewModel(this ProductCategory entity)
        {
            return new ProductCategoryViewModel
            {
                Id = entity.Id.ToString(),
                CategoryName = entity.CategoryName
            };
        }
        public static Product ToEntity(this ProductViewModel viewmodel)
        {
            return new Product
            {
                Id = new Guid(viewmodel.Id),
                Name = viewmodel.ProductName,
                ProductCategoryId = new Guid(viewmodel.ProductCategoryId),

            };
        }
        public static ProductViewModel ToViewModel(this Product entity)
        {
            return new ProductViewModel
            {
                Id = entity.Id.ToString(),
                ProductName = entity.Name,
                ProductCategoryId = entity.ProductCategoryId.ToString(),
                ProductCategoryName = entity.ProductCategory.CategoryName
            };
        }
        public static ProductOption ToEntity(this ProductOptionViewModel viewmodel)
        {
            return new ProductOption
            {
                Id = new Guid(viewmodel.Id),
                OptionName = viewmodel.OptionName,
                ProductId = new Guid(viewmodel.ProductId),
            };
        }
        public static ProductOptionViewModel ToViewModel(this ProductOption entity)
        {
            return new ProductOptionViewModel
            {
                Id = entity.Id.ToString(),
                OptionName = entity.OptionName,
                ProductId = entity.ProductId.ToString(),
                ProductName = entity.Product.Name,
                ProductCategoryId = entity.Product.ProductCategoryId.ToString(),
                ProductCategoryName = entity.Product.ProductCategory.CategoryName
            };
        }
    }
}