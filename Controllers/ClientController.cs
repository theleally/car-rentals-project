using System.Collections.Generic;
using System.Linq;
using car_rentals_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace car_rentals_project.Controllers
{
    [ApiController]
    [Route("api/client")]
    public class ClientController : ControllerBase
    {
        private readonly DataContext _context;

        public ClientController(DataContext context) =>
            _context = context;

        private static List<Client> clients = new List<Client>();

        // GET: /api/client/listar
        [Route("listar")]
        [HttpGet]
        public IActionResult Listar() =>
            Ok(_context.Client.ToList());

        // POST: /api/client/cadastrar
        [Route("cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar([FromBody] Client client)
        {
            _context.Client.Add(client);
            _context.SaveChanges();
            return Created("", client);
        }

        // GET: /api/client/buscar/123
        [Route("buscar/{id}")]
        [HttpGet]
        public IActionResult Buscar([FromRoute] int id)
        {
            Client client =
                _context.Client.Find(id);

            return client != null ? Ok(client) : NotFound();
        }


        // DELETE: /api/client/deletar/1
        [Route("deletar/{id}")]
        [HttpDelete]
        public IActionResult Deletar([FromRoute] int id)
        {
            Client client =
                _context.Client.Find(id);
            if (client != null)
            {
                _context.Client.Remove(client);
                _context.SaveChanges();
                return Ok(client);
            }
            return NotFound();
        }

        // PATCH: /api/client/alterar
        [Route("alterar")]
        [HttpPatch]
        public IActionResult Alterar([FromBody] Client client)
        {
            _context.Client.Update(client);
            _context.SaveChanges();
            return Ok(client);
        }
    }
}
