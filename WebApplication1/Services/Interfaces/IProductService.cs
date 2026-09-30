using WebApplication1.Models.DTOs.Requests;
using WebApplication1.Models.DTOs.Responses;

namespace WebApplication1.Services.Interfaces
{

    public interface IProductService
    {
        public List<ProductForReadDto> GetAllProducts();
        public ProductForReadDto? GetProductById(int id);
        public ProductForReadDto? CreateProduct(ProductForCreateDto dto);
        public bool UpdateProduct(int id, ProductForUpdateDto dto);
        public bool DeleteProduct(int id);
        public List<ProductForReadDto> SearchProductsByName(string name);
        public ProductStatsDto GetStats();
    }
}

