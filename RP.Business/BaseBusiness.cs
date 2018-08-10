using RP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP.Business
{
    public abstract class BaseBusiness
    {
        public IUnitOfWork unitOfWork;
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return unitOfWork;
            }
            set
            {
                unitOfWork = value;
            }
        }
        public DateTime GetDBUtcDateTime()
        {
            return unitOfWork.GetDBUtcDateTime();
        }
    }
}
