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
    public class CreatePartialClosureController : ControllerBase
    {
        private readonly DataContext _context;
        public CreatePartialClosureController(DataContext context)
        {
            _context = context;
        }

        //Obtener las ventas recien registradas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreatePartialClosureQueryDto>>> Get()
        {
            var query = "INSERT INTO PartialClosure (Date, ProductId, QuantitySold, TotalSale, Closed)\r\nOUTPUT inserted.Id, inserted.Date, inserted.ProductId, inserted.QuantitySold, inserted.TotalSale, inserted.Closed\r\nSELECT \r\n\tGETDATE(),\r\n\tInventory.ProductId,\r\n\tSale.QuantitySold,\r\n\tROUND(Sale.QuantitySold * COALESCE(SUM(Products.UnitCost), 1), 2) AS TotalSale,\r\n\t0\r\nFROM Sale \r\nLEFT JOIN Inventory ON Inventory.Id = Sale.InventoryId\r\nLEFT JOIN Products ON Inventory.ProductId = Products.Id\r\nWHERE Sale.Registered = 0\r\nGROUP BY \r\n\tSale.Date, \r\n\tInventory.ProductId,\r\n\tSale.QuantitySold";

            var result = await _context.viewPartialClosure.FromSqlRaw(query)
                .ToListAsync();
            if (result.Count == 0)
            {
                return NotFound("No hay ventas recién registradas");
            }

            var viewList = new List<CreatePartialClosureQueryDto>();

            foreach (var item in result)
            {
                var view = new CreatePartialClosureQueryDto
                {
                    Id = item.Id,
                    Date = item.Date,
                    ProductId = item.ProductId,
                    Product = await _context.Products.FindAsync(item.ProductId),
                    QuantitySold = item.QuantitySold,
                    TotalSale = item.TotalSale,
                    Closed = item.Closed
                };

                viewList.Add(view);
            }


            // Actualizar las ventas a "Registered = True"
            await _context.Database.ExecuteSqlRawAsync("UPDATE Sale SET Registered = 1 WHERE Registered = 0");
            return Ok(viewList);
        }

    }
}
