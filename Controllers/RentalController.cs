using System.Collections.Generic;
using System.Linq;
using car_rentals_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using car_rentals_project.utils;


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
      public IActionResult Listar()
      {
      List<Rental> rental =
                _context.Rental.Include(f=>f.Automobile).Include(e => e.Client).ToList();
      
       if (rental.Count == 0) return NotFound();

            return Ok(rental);
      }
      // POST: /api/rental/cadastrar
        [Route("cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar([FromBody] Rental rental)
       {
            rental.Total_Days_Price=
            aluguelCalc.CalcularDiasvalor
           (rental.Total_Price , rental.Total_Days);
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

        // PUT: /api/rental/alterar/ID - WB
        [Route("alterar/{rId}")]
        [HttpPut]
        public IActionResult Alterar([FromBody] Rental rental )
        {
         
            rental.Total_Days_Price=
            aluguelCalc.CalcularDiasvalor
           (rental.Total_Price , rental.Total_Days);
            _context.Rental.Update(rental);
            _context.SaveChanges();
            return Ok(rental);
        }
    }
}

