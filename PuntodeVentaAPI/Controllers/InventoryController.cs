using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using PuntodeVentaAPI.Data;
using PuntodeVentaAPI.DataTransfer;
using PuntodeVentaAPI.Models;
using PuntodeVentaAPI.Models.Views;

namespace PuntodeVentaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InventoryController : ControllerBase
    {
        private readonly DataContext _context;

        public InventoryController(DataContext context)
        {
            _context = context;
        }

        //Obtener todos los registros
        [HttpGet]
        public async Task<ActionResult<List<Inventory>>> GetAll()
        {
            var inventories = await _context.viewInventory
                    .Include(i => i.Product)
                    .ToListAsync();

            //Eliminar registro si la cantidad de productos es igual a cero
            foreach (var inv in inventories)
            {
                if (inv.IfQuantityIsZero)
                {
                    await DeleteInventory(inv.Id);
                }
            }

            return Ok(inventories);
        }

        //Obtener un solo registro
        [HttpGet("id")]
        public async Task<ActionResult<List<viewInventory>>> Get(int id)
        {
            var inventories = await _context.Inventory
                .Where(i => i.Id == id)
                .ToListAsync();
            if(inventories == null)
            {
                return NotFound("No se encuentra el registro en el inventario");
            }
            return Ok(inventories);
        }

        //Ingresar entrada al inventario
        [HttpPost]
        public async Task<ActionResult<List<Inventory>>> CreateInventory(CreateInventoryDto request)
        {
            //Revisar si existe el producto
            var product = await _context.Products.FindAsync(request.ProductId);
            if(product == null)
            {
                return NotFound("Este producto no existe en el sistema");
            }

            var newInventory = new Inventory
            {
                Product = product,
                Quantity = request.Quantity
            };

            _context.Inventory.Add(newInventory);
            await _context.SaveChangesAsync();


            return Ok(await _context.Inventory.ToListAsync());
        }

        //Editar registro del inventario
        [HttpPut]
        public async Task<ActionResult<List<Inventory>>> UpdateInventory(UpdateInventoryDto request)
        {
            //Revisar si existe el registro en el inventario
            var inventories = await _context.Inventory.FindAsync(request.Id);
            if (inventories == null)
            {
                return BadRequest("No se encuentra el registro en el inventario");
            }

            //Revisar si existe el producto en el sistema
            var product = await _context.Products.FindAsync(request.ProductId);
            if (product == null)
            {
                return BadRequest("No se encuentra el producto en el sistema");
            }

            inventories.Product = product;
            inventories.Quantity = request.Quantity;

            await _context.SaveChangesAsync();

            return Ok(await _context.Inventory.ToListAsync());
        }

        //Eliminar registro del inventario
        [HttpDelete]
        public async Task<ActionResult<List<Inventory>>> DeleteInventory(int id)
        {
            //Revisar si existe el registro en el inventario
            var inventories = await _context.Inventory.FindAsync(id);
            if (inventories == null)
            {
                return BadRequest("No se encuentra el registro en el inventario");
            }

            _context.Inventory.Remove(inventories);
            await _context.SaveChangesAsync();

            return Ok(await _context.Inventory.ToListAsync());

        }



    }
}
