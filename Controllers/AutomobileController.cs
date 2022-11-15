using System.Collections.Generic;
using System.Linq;
using car_rentals_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace car_rentals_project.Controllers
{
    [ApiController]
    [Route("api/automobile")]
    public class AutomobileController : ControllerBase
    {
        private readonly DataContext _context;

        public AutomobileController(DataContext context) =>
            _context = context;

        private static List<Automobile> Automobiles = new List<Automobile>();

        // GET: /api/automobile/listar
        [Route("listar")]
        [HttpGet]
        public IActionResult Listar() =>
            Ok(_context.Automobile.ToList());

        // POST: /api/automobile/cadastrar
        [Route("cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar([FromBody] Automobile automobile)
        {
            _context.Automobile.Add(automobile);
            _context.SaveChanges();
            return Created("", automobile);
        }

        // GET: /api/automobile/buscar/123
        [Route("buscar/{id}")]
        [HttpGet]
        public IActionResult Buscar([FromRoute] int id)
        {
            Automobile automobile =
                _context.Automobile.FirstOrDefault
            (
                f => f.AutomobileId.Equals(id)
            );

            return automobile != null ? Ok(automobile) : NotFound();
        }

        // DELETE: /api/carros/deletar/1
        [Route("deletar/{id}")]
        [HttpDelete]
        public IActionResult Deletar([FromRoute] int id)
        {
            Automobile automobile =
                _context.Automobile.Find(id);
            if (automobile != null)
            {
                _context.Automobile.Remove(automobile);
                _context.SaveChanges();
                return Ok(automobile);
            }
            return NotFound();
        }

        // PATCH: /api/carros/alterar
        [Route("alterar")]
        [HttpPatch]
        public IActionResult Alterar([FromBody] Automobile automobile)
        {
            _context.Automobile.Update(automobile);
            _context.SaveChanges();
            return Ok(automobile);
        }
    }
}