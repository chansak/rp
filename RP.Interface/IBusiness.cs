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
        IList<Document> GetDocumentsListBySearch(string searchBy,string keyword);
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
        IList<ProductMaterialUsage> GetMaterialUsageByProductId(string productId, string productUnitId);
        IList<Stock> GetStockCheck(string warehouseId, string materialId, string materialUnitId);
        Customer GetCustomerById(string id);
        CustomerContact GetContactById(string id);
        User GetSaleUserById(string id);
        IList<Material> GetMaterial();
        Material GetMaterialById(string id);
        #endregion

        #region Pattern
        IList<PatternImage> GetPatternImage();
        IList<PatternPosition> GetPatternPosition();
        IList<Color> GetPatternColor();
        Color GetColorById(string id);
        PatternPosition GetPositionById(string id);
        #endregion

    }
}
