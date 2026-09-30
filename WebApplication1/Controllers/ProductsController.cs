using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop.Infrastructure;
using WebApplication1.Models.DTOs.Requests;
using WebApplication1.Services.Implementations;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var productos = _service.GetAllProducts();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var producto = _service.GetProductById(id);
            if (producto == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(producto);
            }
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductForCreateDto dto)
        {
            var producto = _service.CreateProduct(dto);
            if (producto == null)
            {
                return Conflict();
            }
            else
            {
                return Created($"/products/{producto.Id}", producto);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductForUpdateDto dto)
        {
            bool updated = _service.UpdateProduct(id, dto);
            if (updated)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            bool deleted = _service.DeleteProduct(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("search")]
        public IActionResult SearchProductsByName([FromQuery] string name)
        {
            var productos = _service.SearchProductsByName(name);
            return Ok(productos);
        }

        [HttpGet("stats")]
        public IActionResult GetStats()
        {
            var productos = _service.GetStats();
            return Ok(productos);
        }
    }
}
