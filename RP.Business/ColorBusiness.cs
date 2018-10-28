using RP.Interfaces;
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
        public IList<Color> GetPatternColor()
        {
            using (var uow = UnitOfWork.Create())
            {
                return uow.ColorRepository.All().ToList();
            }
        }
        public Color GetColorById(string id) {
            using (var uow = UnitOfWork.Create())
            {
                return uow.ColorRepository.GetById(id);
            }
        }
    }
}
