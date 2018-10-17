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
                var item = new DocumentProductItem
                {
                    Id = Guid.NewGuid(),
                    ProductId = new System.Guid(i.ProductId),
                    ProductUnitId = new System.Guid(i.ProductUnitId),
                    Amount = i.Amount,
                    PricePerUnit = (decimal)i.PricePerUnit
                };
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
            return document;
        }
    }
}