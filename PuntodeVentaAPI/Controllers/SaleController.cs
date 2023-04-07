using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PuntodeVentaAPI.Data;
using PuntodeVentaAPI.DataTransfer;
using PuntodeVentaAPI.Models.Views;
using PuntodeVentaAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace PuntodeVentaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SaleController : ControllerBase
    {
        private readonly DataContext _context;

        public SaleController(DataContext context)
        {
            _context = context;
        }

        //Obtener todas las ventas
        [HttpGet]
        public async Task<ActionResult<List<Sale>>> GetAll()
        {
            var sales = await _context.Sale
                    .Include(i => i.Inventory)
                    .Include(i => i.Inventory.Product)
                    .ToListAsync();

            return Ok(sales);
        }

        //Obtener una sola venta
        [HttpGet("id")]
        public async Task<ActionResult<List<Sale>>> Get(int id)
        {
            var sales = await _context.Sale
                .Where(i => i.Id == id)
                .Include(i => i.Inventory)
                .ToListAsync();
            if (sales == null)
            {
                return NotFound("No se encuentra el registro en el inventario");
            }
            return Ok(sales);
        }

        //Ingresar venta
        [HttpPost]
        public async Task<ActionResult<List<Sale>>> CreateSale(CreateSaleDto request)
        {
            //Revisar si existe el registro del inventario
            var inventory = await _context.Inventory.FindAsync(request.InventoryId);
            if (inventory == null)
            {
                return NotFound("Este registro de inventario no existe");
            }

            var newSale = new Sale
            {
                Inventory = inventory,
                QuantitySold = request.QuantitySold,
                Registered = request.Registered,
                Date = request.Date
            };

            _context.Sale.Add(newSale);
            await _context.SaveChangesAsync();


            return Ok(await _context.Sale.ToListAsync());
        }

        //Editar venta
        [HttpPut]
        public async Task<ActionResult<List<Sale>>> UpdateSale(UpdateSaleDto request)
        {
            //Revisar si existe la venta
            var sale = await _context.Sale.FindAsync(request.Id);
            if (sale == null)
            {
                return NotFound("No existe la venta en el sistema");
            }

            //Revisar si existe el registro en el inventario
            var inventories = await _context.Inventory.FindAsync(request.InventoryId);
            if (inventories == null)
            {
                return NotFound("No se encuentra el registro en el inventario");
            }

            sale.Inventory = inventories;
            sale.QuantitySold = request.QuantitySold;
            sale.Registered = request.Registered;
            sale.Date = request.Date;

            await _context.SaveChangesAsync();

            return Ok(await _context.Sale.ToListAsync());
        }

        //Eliminar venta
        [HttpDelete]
        public async Task<ActionResult<List<Sale>>> DeleteSale(int id)
        {
            //Revisar si existe la venta en el sistema
            var sale = await _context.Sale.FindAsync(id);
            if (sale == null)
            {
                return BadRequest("No se encuentra el registro en el inventario");
            }

            _context.Sale.Remove(sale);
            await _context.SaveChangesAsync();

            return Ok(await _context.Sale.ToListAsync());

        }

    }
}
