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
    public class PartialClosureController : ControllerBase
    {
        private readonly DataContext _context;

        public PartialClosureController(DataContext context)
        {
            _context = context;
        }

        //Obtener todos los registros de los cierres parciales
        [HttpGet]
        public async Task<ActionResult<List<PartialClosure>>> GetAll()
        {
            var partialclosures = await _context.PartialClosure
                .Include(i => i.Product)
                .ToListAsync();

            return Ok(partialclosures);
        }
    }
}
