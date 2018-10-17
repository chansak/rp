//using RP.Model;
using RP.Model;
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

        #region Documents
        IList<Document> GetDocumentsList();
        Document GetDocument(string id);
        void CreateDocument(Document document,string customerCode);
        #endregion

        #region Common
        IList<User> GetSaleUsersList();
        IList<Customer> GetCustomersList();
        IList<CustomerContact> GetContactByCustomerId(string id);
        IList<ProductCategory> GetProductCategories();
        IList<Product> GetProductsByCategoryId(string id);
        IList<ProductOption> GetOptionsByProductId(string id);
        IList<ProductUnit> GetUnitsByProductId(string id);
        Product GetProductsById(string id);
        IList<ProductMaterialUsage> GetMaterialUsageByProductId(string id,string productUnitId);
        IList<Stock> GetStockCheck(string warehouseId, string materialId, string materialUnitId);
        #endregion

        #region Pattern
        IList<PatternImage> GetPatternImage();
        IList<PatternPosition> GetPatternPosition();
        IList<Color> GetPatternColor();

        #endregion

    }
}
