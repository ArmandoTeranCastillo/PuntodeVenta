using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PuntodeVentaAPI.Data;
using PuntodeVentaAPI.DataTransfer;
using PuntodeVentaAPI.Models;

namespace PuntodeVentaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }

        //Obtener todos los productos del sistema
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            var products = await _context.Products.ToListAsync();

            return Ok(products);
        }

        //Obtener un solo producto
        [HttpGet("id")]
        public async Task<ActionResult<List<Product>>> Get(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if(product == null)
            {
                return NotFound("El producto no existe en el sistema");
            }
            return Ok(product);
        }

        //Agregar un nuevo producto en el sistema
        [HttpPost]
        public async Task<ActionResult<List<Product>>> CreateProduct(CreateProductDto request)
        {
            var product = new CreateProductDto
            {
                Name = request.Name,
                Description = request.Description,
                UnitCost = request.UnitCost
            };

            return Ok(await _context.Products.ToListAsync());
        }

        //Editar un producto del sistema
        [HttpPut]
        public async Task<ActionResult<List<Product>>> UpdateProduct(UpdateProductDto request)
        {
            var product = await _context.Products.FindAsync(request.Id);
            if(product == null)
            {
                return NotFound("El producto no existe en el sistema");
            }

            product.Name = request.Name;
            product.Description = request.Description;
            product.UnitCost = request.UnitCost;

            await _context.SaveChangesAsync();

            return Ok(await _context.Products.ToListAsync());
        }

        //Eliminar un producto del sistema
        [HttpDelete]
        public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound("El producto no existe en el sistema");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok(await _context.Products.ToListAsync());
        }
    }
}
