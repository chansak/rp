//using RP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP.Interfaces
{
    public interface IBusiness
    {
        #region General
        IUnitOfWork UnitOfWork { get; set; }
        DateTime GetDBUtcDateTime();
        #endregion

        #region Transport
        //Transport GetTransportById(int id);
        #endregion
    }
}
