

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RP.Interfaces;
using System.Data.Entity;

namespace RP.DataAccess
{
	public class EFUnitOfWork : IUnitOfWork
	{
		private DbContext context;
        public EFUnitOfWork()
        {
            context = new RPContext();
        }

        public IUnitOfWork Create()
        {
            return new EFUnitOfWork();
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Rollback()
        {

        }

        public string ConnectionString
        {
            get;
            set;
        }

        public DateTime GetDBUtcDateTime()
        {
            return context.Database.SqlQuery<DateTime>("SELECT GETUTCDATE()").FirstOrDefault();
        }

		private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

	}
}


