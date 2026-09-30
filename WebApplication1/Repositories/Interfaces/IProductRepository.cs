using WebApplication1.Entities;

namespace WebApplication1.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public List<Product> GetAllProducts();
        public Product? GetProductById(int id);
        public void AddProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProduct(Product product);
        public List<Product> SearchProductsByName(string name);

    }
}
