using AutoMapper;
using RP.DataAccess;
using RP.Website.Models;
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
        public static Document ToEntity(this QuotationViewModel viewmodel)
        {
            return new Document { };
        }
        public static QuotationViewModel ToViewModel(this Document entity)
        {
            return new QuotationViewModel {
                QuotationCode = entity.FileNumber
            };
        }
    }
}