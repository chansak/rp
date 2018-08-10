using RP.Interfaces;
using RP.Model;

namespace RP.Business
{
    partial class Business : BaseBusiness, IBusiness {
        public Transport GetTransportById(int id)
        {
            using (var uow = UnitOfWork.Create())
            {
                return uow.TransportRepository.GetById(id);
            }
        }
    }
}
