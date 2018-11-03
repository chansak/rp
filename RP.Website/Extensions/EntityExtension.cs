using AutoMapper;
using RP.Website.Models;
using RP.Model;
using System.Collections.Generic;
using System.Linq;
using RP.Model.Enum;
using System;
using RP.Interfaces;

namespace RP.Website
{
    public static class EntityExtension
    {
        public static Document ToEntity(this DocumentViewModel viewModel)
        {
            var _documentId = Guid.NewGuid();
            var document = new Document();
            document.Id = _documentId;
            document.DocumentStatusId = (int)WorkflowStatus.RequestedForApproval;
            document.BiddingStatusId = (int)BiddingStatus.Waiting;
            //document.FileNumber = viewModel.DocumentCode;
            //document.CreatedDate = viewModel.CreatedDate;
            //document.IssueDate = viewModel.IssuedDate;
            document.ExpiryDate = viewModel.ExpirationDate;
            //document.ExpectedDeliveryDate = viewModel.ExpectedDeliveryDate;
            document.UserId = new System.Guid(viewModel.SaleUserId);
            document.CustomerId = new System.Guid(viewModel.CustomerId);
            document.ContactId = new System.Guid(viewModel.ContactId);
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
            document.IsDelete = false;
            return document;
        }
        public static DocumentViewModel ToViewModel(this Document entity)
        {
            var document = new DocumentViewModel();
            document.Id = entity.Id.ToString();
            document.DocumentCode = entity.FileNumber;
            //document.IssuedDate = entity.IssueDate.Value;
            document.ExpirationDate = entity.ExpiryDate.Value;
            //document.ExpectedDeliveryDate = entity.ExpectedDeliveryDate.Value;
            document.SaleUserId = entity.UserId.ToString();
            document.CustomerId = entity.CustomerId.ToString();
            document.ContactId = entity.ContactId.ToString();
            var productItems = new List<ProductItemViewModel>();
            foreach (var i in entity.DocumentProductItems)
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
            document.Remark = entity.RefPriceAndRemark;
            return document;
        }

        public static CustomerViewModel ToViewModel(this Customer entity)
        {
            var customer = new CustomerViewModel();
            customer.Id = entity.Id.ToString();
            customer.Name = entity.Name;
            customer.HospitalName = entity.Name;
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
        public static SaleUserViewModel ToViewModel(this User entity)
        {
            var user = new SaleUserViewModel();
            user.Id = entity.Id.ToString();
            user.Name = entity.DisplayName;
            user.Branch = entity.Department.DepartmentName;
            return user;
        }

        public static ProductItemViewModel ToViewModel(this DocumentProductItem entity) {
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
            if (o1 != null) {
                var pattern = GenericFactory.Business.GetPatternImageById(o1.PatternId.ToString());
                var path = string.Format(@"../../../FileUpload/{0}",
                                            pattern.PatternImagePath.Replace(@"\", @"/")
                                            .Split(new string[] { @"FileUpload" }, StringSplitOptions.None)[1]
                                            .Remove(0, 1));
                var color = GenericFactory.Business.GetColorById(o1.ColorCodeId.ToString());
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
                var path = string.Format(@"../../../FileUpload/{0}",
                                            pattern.PatternImagePath.Replace(@"\", @"/")
                                            .Split(new string[] { @"FileUpload" }, StringSplitOptions.None)[1]
                                            .Remove(0, 1));
                var color = GenericFactory.Business.GetColorById(o2.ColorCodeId.ToString());
                var position = GenericFactory.Business.GetPositionById(o2.PatternPositionId.ToString());
                screenOption.PatternId = pattern.Id.ToString();
                screenOption.PatternName = pattern.PatternName;
                screenOption.PatternImagePath = path;
                screenOption.PositionId = position.Id.ToString();
                screenOption.PositionName = position.PositionName;
            }
            item.ScreenOption = screenOption;
            var o3 = GenericFactory.Business.GetProductItemSewOptionalByItemId(entity.Id.ToString());
            var sewOption = new SewOptionViewModel();
            if (o2 != null)
            {
                var pattern = GenericFactory.Business.GetPatternImageById(o3.PatternId.ToString());
                var path = string.Format(@"../../../FileUpload/{0}",
                                            pattern.PatternImagePath.Replace(@"\", @"/")
                                            .Split(new string[] { @"FileUpload" }, StringSplitOptions.None)[1]
                                            .Remove(0, 1));
                var position = GenericFactory.Business.GetPositionById(o2.PatternPositionId.ToString());
                sewOption.PatternId = pattern.Id.ToString();
                sewOption.PatternName = pattern.PatternName;
                sewOption.PatternImagePath = path;
                sewOption.PositionId = position.Id.ToString();
                sewOption.PositionName = position.PositionName;
                sewOption.Remark = o3.Remark;
            }
            item.SewOption = sewOption;
            item.ProductCategoryId = entity.Product.ProductCategoryId.ToString();
            item.ProductOptionId = entity.ProductOptionId.ToString();
            return item;
        }
    }
}