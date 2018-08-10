using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class TransportRepository : EFRepository<RP.Model.Transport>, ITransportRepository
	{
		public TransportRepository(DbContext context)
            : base(context)
		{
		}
        public override IQueryable<Model.Transport> All()
        {
            return ObjectSet.
                Include(t => t.TransportLocation).
                Include(t => t.TransportAdditionalItem).
                Include(t => t.TransportReference).
                Include(t => t.TransportVehicle).
                Include(t => t.TransportVehicle.VehicleType).
                Include(t => t.TransportVehicle.VehicleDimension).
                Include(t => t.TransportVehicle.VehicleCondition).
                Include(t => t.BusinessUnit).
                Include(t => t.BusinessUnit.BUNotificationEmails).
                Include(t => t.BusinessUnit.Country).
                Include(t => t.BusinessUnit.TimeZone).
                Include(t => t.Quotes).
                Include(t => t.TransportSuppliers).
                Include(t => t.TransportSuppliers.Select(ts => ts.Supplier)).
                AsQueryable();
        }
        public override Model.Transport GetById(int id)
        {
            string strTime = string.Empty;
            var selectedItem = ObjectSet.Where(t => t.Id == id && !t.IsDeleted).FirstOrDefault();
            return selectedItem;
        }
    }
}
