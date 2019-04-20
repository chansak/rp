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
        public IList<PatternImage> GetPatternImage()
        {
            using (var uow = UnitOfWork.Create())
            {
                return uow.PatternImageRepository.All().ToList();
            }
        }
        public PatternImage GetPatternImageById(string id)
        {
            using (var uow = UnitOfWork.Create())
            {
                return uow.PatternImageRepository.GetById(id);
            }
        }
        public void CreateNewPattern(PatternImage pattern)
        {
            using (var uow = UnitOfWork.Create())
            {
                uow.PatternImageRepository.AddNewPattern(pattern);
                uow.Commit();
            }
        }
        public IList<PatternImage> GetPatternImageByCustomerId(string id)
        {
            using (var uow = UnitOfWork.Create())
            {
                return uow.PatternImageRepository.All().Where(i => i.CustomerId.ToString() == id).ToList();
            }
        }
    }
}
