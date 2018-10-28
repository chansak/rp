using AutoMapper;
using RP.Website.Models;
using RP.Model;
using System.Collections.Generic;
using System.Linq;
using RP.Model.Enum;
using System;

namespace RP.Website
{
    public static class EntityExtension
    {
        public static Document ToEntity(this DocumentViewModel viewModel)
        {
            var document = new Document();
            document.DocumentStatusId = (int)WorkflowStatus.RequestedForApproval;
            document.BiddingStatusId = (int)BiddingStatus.Waiting;
            //document.FileNumber = viewModel.DocumentCode;
            document.IssueDate = viewModel.IssuedDate;
            document.ExpiryDate = viewModel.ExpirationDate;
            document.ExpectedDeliveryDate = viewModel.ExpectedDeliveryDate;
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
                switch (i.PrintOption.SelectedOption)
                {
                    case 1:
                        {
                            printOption1.Id = Guid.NewGuid();
                            printOption1.ProductItemId = itemId;
                            break;
                        }
                    case 2:
                        {
                            break;
                        }
                    case 0:
                        {
                            break;
                        }
                }
                document.DocumentProductItems.Add(item);
            }
            document.DeliveryContactId = new System.Guid(viewModel.DeliveryContactId);
            var delivery = new DocumentDelivery
            {
                Id = Guid.NewGuid(),
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
            document.IssuedDate = entity.IssueDate;
            document.ExpirationDate = entity.ExpiryDate;
            document.ExpectedDeliveryDate = entity.ExpectedDeliveryDate;
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
                    printOptions.Add(new PrintOptionViewModel
                    {
                        PatternImagePath = o1.PatternImagePath,
                        ColorName = ""
                    });
                }
                var screenOptions = new List<ScreenOptionViewModel>();
                if (i.ProductItemScreenOptionals.Count > 0)
                {
                    var o2 = i.ProductItemScreenOptionals.FirstOrDefault();
                    screenOptions.Add(new ScreenOptionViewModel
                    {
                        PatternImagePath = o2.PatternImagePath,
                        PositionId = o2.PatternPositionId.ToString(),
                        PositionName = ""
                    });
                }
                var sewOptions = new List<SewOptionViewModel>();
                if (i.ProductItemSewOptionals.Count > 0)
                {
                    var o3 = i.ProductItemSewOptionals.FirstOrDefault();
                    sewOptions.Add(new SewOptionViewModel
                    {
                        PatternImagePath = o3.PatternImagePath,
                        PositionId = o3.PatternPositionId.ToString(),
                        PositionName = "",
                        Remark = o3.Remark
                    });
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
    }
}