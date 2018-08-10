using AutoMapper;
using RP.Website.Models;
using EntityModel = RP.Model;
using ViewModel = RP.Website.Models;
namespace RP.Website
{
    public static class EntityExtension
    {
        public static EntityModel.Transport ToEntity(this ViewModel.TransportDetailViewModel viewmodel)
        {
            return Mapper.Map<ViewModel.TransportDetailViewModel, EntityModel.Transport>(viewmodel);
        }
        public static TransportDetailViewModel ToViewModel(this EntityModel.Transport entity)
        {
            return Mapper.Map<EntityModel.Transport, ViewModel.TransportDetailViewModel>(entity);
        }
    }
}