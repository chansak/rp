using RP.DataAccess;
using RP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP.Business
{
    partial class Business : BaseBusiness, IBusiness
    {
        public void UpdateLocation(RP.Model.LocationTracking location) {
            using (var uow = UnitOfWork.Create())
            {
                try
                {
                    uow.LocationTrackingRepository.Add(location);
                    uow.Commit();
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
            }
        }
    }
}
