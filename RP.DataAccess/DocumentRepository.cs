using System.Data.Entity;
using System.Linq;
using RP.Interfaces;
using RP.Model;

namespace RP.DataAccess
{
    public class DocumentRepository : EFRepository<RP.Model.Document>, IDocumentRepository
    {
        public DocumentRepository(DbContext context)
            : base(context)
        {
        }
        public override IQueryable<Model.Document> All()
        {
            return ObjectSet.
                Include(i => i.Customer)
                .AsQueryable();
        }
        public override Model.Document GetById(string id)
        {
            return ObjectSet.Where(i => i.Id.ToString() == id && !i.IsDelete.Value).
                Include(i => i.Customer)
                .FirstOrDefault();
        }
    }
}
