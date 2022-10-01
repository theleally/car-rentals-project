using System.Collections.Generic;
using System.Linq;
using car_rentals_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace car_rentals_project.Controllers
{
    [ApiController]
    [Route("api/rental")]
    public class RentalController : ControllerBase
    {
      private readonly DataContext _context;

      public RentalController(DataContext context) => _context = context;

      // GET: /api/rental/listar
      [Route("listar")]
      [HttpGet]
      public IActionResult Listar() => Ok(_context.Rental.ToList());

      // POST: /api/rental/cadastrar
        [Route("cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar([FromBody] Rental rental)
        {
            _context.Rental.Add(rental);
            _context.SaveChanges();
            return Created("", rental);
        }

        // GET: /api/rental/buscar/1
        [Route("buscar/{rId}")]
        [HttpGet]
        public IActionResult Buscar([FromRoute] int rId)
        {
            Rental rental =
                _context.Rental.FirstOrDefault
            (
                o => o.RentalId.Equals(rId)
            );

            return rental != null ? Ok(rental) : NotFound();
        }

        // DELETE: /api/rental/deletar/1
        [Route("deletar/{rId}")]
        [HttpDelete]
        public IActionResult Deletar([FromRoute] int rId)
        {
            Rental rental =
                _context.Rental.Find(rId);
            if (rental != null)
            {
                _context.Rental.Remove(rental);
                _context.SaveChanges();
                return Ok(rental);
            }
            return NotFound();
        }

        // PATCH: /api/rental/alterar
        [Route("alterar")]
        [HttpPatch]
        public IActionResult Alterar([FromBody] Rental rental)
        {
            _context.Rental.Update(rental);
            _context.SaveChanges();
            return Ok(rental);
        }
    }
}
