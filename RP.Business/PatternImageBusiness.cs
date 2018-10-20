﻿using RP.Interfaces;
using RP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP.Business
{
    partial class Business : BaseBusiness, IBusiness
    {
        public IList<PatternImage> GetPatternImage()
        {
            using (var uow = UnitOfWork.Create())
            {
                return uow.PatternImageRepository.All().ToList();
            }
        }
    }
}