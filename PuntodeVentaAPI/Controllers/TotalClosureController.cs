using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PuntodeVentaAPI.Data;
using PuntodeVentaAPI.Models;

namespace PuntodeVentaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TotalClosureController : ControllerBase
    {
        private readonly DataContext _context;

        public TotalClosureController(DataContext context)
        {
            _context = context;
        }

        //Obtener todos los registros de los cierres totales
        [HttpGet]
        public async Task<ActionResult<List<TotalClosure>>> GetAll()
        {
            var totalclosures = await _context.TotalClosure
                .Include(i => i.Product)
                .ToListAsync();

            return Ok(totalclosures);
        }
    }
}
