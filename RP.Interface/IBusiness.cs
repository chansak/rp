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
        IList<Document> GetDocumentsListBySearch(string searchBy, string keyword, string userId = null);
        Document GetDocument(string id);
        void CreateDocument(Document document, string customerCode);
        void UpdateDocumentWithMarkDeleteItems(Document document);
        void UpdateDocument(Document document);
        void UpdateDocumentStatus(Document document);
        DocumentProductItem GetProductItemByItemId(string id);
        ProductItemPrintOptional GetProductItemPrintOptionalByItemId(string id);
        ProductItemScreenOptional GetProductItemScreenOptionalByItemId(string id);
        ProductItemSewOptional GetProductItemSewOptionalByItemId(string id);
        void MarkDeleteProductItemsByDocumentId(IUnitOfWork uow, string id);
        void DeleteProductItemsByDocument(Document document);
        IList<Document> GetApprovalDocumentsListBySearch(string searchBy, string keyword);
        void MarkDeleteProductItemByItemId(string itemId);

        #endregion

        #region User
        IList<AspNetUser> GetSaleUsersList();
        AspNetUser GetSaleUserById(string id);
        AspNetUser GetUserById(string id);
        bool AddNewUser(ApplicationUser user, string password, string role);
        IList<AspNetUser> GetAllUsers(string searchBy, string keyword);
        #endregion

        #region Customer
        IList<Customer> GetCustomersList();
        IList<CustomerContact> GetContactByCustomerId(string id);
        Customer GetCustomerById(string id);
        CustomerContact GetContactById(string id);
        List<CustomerBranch> GetCustomerBranches(string id);
        #endregion

        #region Common
        
        IList<Product> GetProductsByCategoryId(string id);
        IList<ProductOption> GetOptionsByProductId(string id);
        IList<ProductUnit> GetUnitsByProductId(string id);
        Product GetProductsById(string id);
        IList<ProductMaterialUsage> GetMaterialUsageByProductId(string productId, string productUnitId);
        IList<Stock> GetStockCheck(string warehouseId, string materialId, string materialUnitId);
        IList<Material> GetMaterials();
        Material GetMaterialById(string id);
        IList<PatternImage> GetPatternImage();
        IList<PatternImage> GetPatternImageByCustomerId(string customerId,int patternType);
        IList<PatternPosition> GetPatternPosition();
        IList<Color> GetPatternColor();
        Color GetColorById(string id);
        PatternPosition GetPositionById(string id);
        PatternImage GetPatternImageById(string id);
        void UpdateLocation(RP.Model.LocationTracking location);
        #endregion

        #region Patrern
        void CreateNewPattern(PatternImage pattern);
        #endregion

        #region Log
        IList<History> GetHistoryByType(string documentId, int type);
        void AddHistory(History history);
        #endregion

        #region Master Data
        IList<ProductCategory> GetProductCategories();
        IList<ProductCategory> GetAllProductCategories(string searchBy, string keyword);
        void CreateCategory(ProductCategory category);
        ProductCategory GetCategoryById(string id);
        void UpdateCategory(ProductCategory category);
        void DeleteCategoryById(string id);

        IList<Product> GetAllProducts(string searchBy, string keyword);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProductById(string id);

        ProductOption GetProductOptionById(string id);
        IList<ProductOption> GetAllProductOptions(string searchBy, string keyword);
        void CreateProductOption(ProductOption product);
        void UpdateProductOption(ProductOption product);
        void DeleteProductOptionById(string id);
        #endregion
    }
}
