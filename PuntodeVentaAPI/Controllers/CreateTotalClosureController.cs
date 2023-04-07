using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PuntodeVentaAPI.Data;
using PuntodeVentaAPI.DataTransfer;

namespace PuntodeVentaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CreateTotalClosureController : ControllerBase
    {
        private readonly DataContext _context;
        public CreateTotalClosureController(DataContext context)
        {
            _context = context;
        }

        //Obtener las ventas recien registradas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreateTotalClosureDto>>> Get()
        {
            var query = "INSERT INTO TotalClosure (Date, ProductId, QuantitySold, TotalSale)\r\nOUTPUT inserted.Id, inserted.Date, inserted.ProductId, inserted.QuantitySold, inserted.TotalSale\r\nSELECT \r\n\tGETDATE(),\r\n\tPartialClosure.ProductId,\r\n\tPartialClosure.QuantitySold,\r\n\tPartialClosure.TotalSale\r\nFROM PartialClosure\r\nWHERE PartialClosure.Closed = 0 AND CONVERT(date, PartialClosure.Date) = CONVERT(date, GETDATE())\r\nGROUP BY \r\n\tPartialClosure.ProductId, \r\n\tPartialClosure.QuantitySold,\r\n\tPartialClosure.TotalSale\r\n\r\n--Actualizar los registros a True\r\nUPDATE PartialClosure SET Closed = 1\r\nWHERE Closed = 0\r\n\r\n\r\n";
            var result = await _context.viewTotalClosure.FromSqlRaw(query).ToListAsync();
            if (result.Count == 0)
            {
                return NotFound("Todas las ventas ya han sido cerradas.");
            }
            var viewList = new List<CreateTotalClosureDto>();

            foreach (var item in result)
            {
                var view = new CreateTotalClosureDto
                {
                    Id = item.Id,
                    Date = item.Date,
                    ProductId = item.ProductId,
                    Product = await _context.Products.FindAsync(item.ProductId),
                    QuantitySold = item.QuantitySold,
                    TotalSale = item.TotalSale,
                };

                viewList.Add(view);
            }

            // Actualizar las ventas a "Closed = True"
            await _context.Database.ExecuteSqlRawAsync("UPDATE PartialClosure SET Closed = 1\r\nWHERE Closed = 0");

            return Ok(viewList);
        }
    }
}
