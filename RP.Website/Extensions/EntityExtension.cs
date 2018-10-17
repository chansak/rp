using AutoMapper;
using RP.Website.Models;
using RP.Model;
using System.Collections.Generic;
using System.Linq;

namespace RP.Website
{
    public static class EntityExtension
    {
        //public static EntityModel.Transport ToEntity(this ViewModel.TransportDetailViewModel viewmodel)
        //{
        //    return Mapper.Map<ViewModel.TransportDetailViewModel, EntityModel.Transport>(viewmodel);
        //}
        //public static TransportDetailViewModel ToViewModel(this EntityModel.Transport entity)
        //{
        //    return Mapper.Map<EntityModel.Transport, ViewModel.TransportDetailViewModel>(entity);
        //}
        public static Document ToEntity(this DocumentViewModel viewModel)
        {
            var document = new Document();
            document.FileNumber = viewModel.DocumentCode;
            document.IssueDate = viewModel.IssuedDate;
            document.ExpiryDate = viewModel.ExpirationDate;
            document.ExpectedDeliveryDate = viewModel.ExpectedDeliveryDate;
            document.UserId = new System.Guid(viewModel.SaleUserId);
            document.CustomerId = new System.Guid(viewModel.CustomerId);
            document.ContactId = new System.Guid(viewModel.ContactId);
            document.DocumentProductItems = viewModel.Items.Select(i => new DocumentProductItem
            {
                ProductId = new System.Guid(i.ProductId),
                ProductUnitId = new System.Guid(i.ProductUnitId),
                Amount = i.Amount,
                PricePerUnit = (decimal)i.PricePerUnit
            }).ToList();
            document.DeliveryContactId = new System.Guid(viewModel.DeliveryContactId);
            document.DocumentDeliveries.Add(new DocumentDelivery {
                Address1 = viewModel.DeliveryAddress
            });
            document.RefPriceAndRemark = viewModel.Remark;
            return document;
        }
    }
}