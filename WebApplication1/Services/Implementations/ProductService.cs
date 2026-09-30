using System.Numerics;
using System.Xml.Linq;
using WebApplication1.Entities;
using WebApplication1.Models.DTOs.Requests;
using WebApplication1.Models.DTOs.Responses;
using WebApplication1.Repositories.Implementations;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
        public List<ProductForReadDto> GetAllProducts()
        {
            List<Product> products = _repository.GetAllProducts();
            List<ProductForReadDto> resultado = new List<ProductForReadDto>();
            foreach (var product in products)
            {
                ProductForReadDto dto = new ProductForReadDto
                {
                    Name = product.Name,
                    Id = product.Id,
                    Price = product.Price
                };
                resultado.Add(dto);
            }
            return resultado;
        }

        public ProductForReadDto? GetProductById(int id)
        {
            List<ProductForReadDto> products = GetAllProducts();
            ProductForReadDto? ProductoEncontrado = products.FirstOrDefault(p => p.Id == id);
            if (ProductoEncontrado != null)
            {
                return ProductoEncontrado;
            }
            return null;
        }

        public ProductForReadDto? CreateProduct(ProductForCreateDto dto)
        {
            int idMax;
            List<Product> products = _repository.GetAllProducts();
            if (products.Any())
            {
                idMax = products.Max(p => p.Id) + 1;
            }
            else
            {
                idMax = 1;
            }
            if (!products.Any(p => p.Name == dto.Name))
            {
                Product resultado = new Product()
                {
                    Id = idMax,
                    Name = dto.Name,
                    Price = dto.Price
                };
                _repository.AddProduct(resultado);

                ProductForReadDto dtoRead = new ProductForReadDto()
                {
                    Id = idMax,
                    Name = dto.Name,
                    Price = dto.Price
                };
                return dtoRead;
            }
            return null;
        }
        public bool UpdateProduct(int id, ProductForUpdateDto dto)
        {
            Product? resultado = _repository.GetProductById(id);
            if (resultado == null)
            {
                return false;
            }
            Product nuevo = new Product()
            {
                Id = id,
                Name = dto.Name,
                Price = dto.Price
            };
            _repository.UpdateProduct(nuevo);
            return true;
        }
        public bool DeleteProduct(int id)
        {
            Product? resultado = _repository.GetProductById(id);
            if (resultado == null)
            {
                return false;
            }
            _repository.DeleteProduct(resultado);
            return true;
        }

        public List<ProductForReadDto> SearchProductsByName(string name)
        {
            List<Product> products = _repository.SearchProductsByName(name);
            List<ProductForReadDto> resultado = new List<ProductForReadDto>();
            foreach (var product in products)
            {
                ProductForReadDto dto = new ProductForReadDto
                {
                    Name = product.Name,
                    Id = product.Id,
                    Price = product.Price
                };
                resultado.Add(dto);
            }
            return resultado;
        }

        public ProductStatsDto GetStats()
        {
            List<Product> products = _repository.GetAllProducts();
            if (!products.Any())
            {
                ProductStatsDto resultado = new ProductStatsDto()
                {
                    Total = 0,
                    AveragePrice = 0,
                    MostExpensiveName = "No hay productos"
                };
                return resultado;
            }
            else
            {
                ProductStatsDto resultado = new ProductStatsDto()
                {
                    Total = products.Count,
                    AveragePrice = products.Average(x => x.Price),
                    MostExpensiveName = products.OrderByDescending(p => p.Price).First().Name
                };
                return resultado;
            }
        }
    }
}