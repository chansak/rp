using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP.Interfaces
{
    public static class GenericFactory
    {
        private const string BusinessSessionName = "IBusiness";
        private const string UnitOfWorkSessionName = "IUnitOfWork";

        #region Spring Context Helper
        static IApplicationContext SpringContext;
        static GenericFactory()
        {
            SpringContext = ContextRegistry.GetContext();
        }

        public static T CreateObject<T>(string name)
        {
            return (T)SpringContext.GetObject(name);
        }
        #endregion

        public static IBusiness Business
        {
            get
            {
                var businessObject = CreateObject<IBusiness>(BusinessSessionName);
                var uow = CreateObject<IUnitOfWork>(UnitOfWorkSessionName);
                businessObject.UnitOfWork = uow;
                return businessObject;
            }
        }
    }
}
