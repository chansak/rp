using AutoMapper;
using RP.DataAccess;
using RP.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP.Website
{
    public class ModelMapping
    {
        public static void Configure()
        {
            //Mapper.Initialize(cfg => {
            //    cfg.CreateMap<RP.Model.Transport, TransportDetailViewModel>();
            //    cfg.CreateMap<TransportDetailViewModel, RP.Model.Transport>();
            //});
        }
    }
}