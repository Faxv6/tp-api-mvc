using WebApplication1.Entities;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private static List<Product> _products = new()
{
    new Product { Id = 1, Name = "Mouse inalámbrico", Price = 3999.99m },
    new Product { Id = 2, Name = "Teclado mecánico", Price = 8299.50m },
    new Product { Id = 3, Name = "Monitor 24 pulgadas", Price = 52499.00m },
    new Product { Id = 4, Name = "Notebook Dell Inspiron", Price = 185000.00m },
    new Product { Id = 5, Name = "Auriculares Bluetooth", Price = 10499.90m },
    new Product { Id = 6, Name = "Webcam HD", Price = 7999.00m },
    new Product { Id = 7, Name = "Silla ergonómica", Price = 61200.00m },
    new Product { Id = 8, Name = "Disco SSD 1TB", Price = 44999.99m },
    new Product { Id = 9, Name = "Tablet Samsung Galaxy", Price = 93499.00m },
    new Product { Id = 10, Name = "Impresora multifunción", Price = 73900.00m }
};
        public List<Product> GetAllProducts()
        {
            return _products;
        }
        public Product? GetProductById(int id)
        {
            for (int i = 0; i < _products.Count; i++)
            {
                if (id == _products[i].Id)
                {
                    return _products[i];

                }
            }
            return null;
        }
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }
        public void UpdateProduct(Product product)
        {
            for (int i = 0; i < _products.Count; i++)
            {
                if (product.Id == _products[i].Id)
                {
                    _products[i] = product;
                    break;
                }
            }
        }
        public void DeleteProduct(Product product)
        {
            Product? ProductoEncontrado = _products.FirstOrDefault(p => p.Id == product.Id);
            if (ProductoEncontrado != null)
            {
                _products.Remove(ProductoEncontrado);
            }
        }
        public List<Product> SearchProductsByName(string name)
        {
            IEnumerable<Product>? ProductosEncontrados = _products.Where(p => p.Name.ToLower().Contains(name.ToLower()));
            return ProductosEncontrados.ToList();
        }
    }
}
