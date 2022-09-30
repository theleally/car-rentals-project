using System.Collections.Generic;
using System.Linq;
using car_rentals_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace car_rentals_project.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
      private readonly DataContext _context;

      public OrderController(DataContext context) => _context = context;

      // GET: /api/order/listar
      [Route("listar")]
      [HttpGet]
      public IActionResult Listar() => Ok(_context.Order.ToList());

      // POST: /api/order/cadastrar
        [Route("cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar([FromBody] Order order)
        {
            _context.Order.Add(order);
            _context.SaveChanges();
            return Created("", order);
        }

        // GET: /api/order/buscar/1
        [Route("buscar/{oId}")]
        [HttpGet]
        public IActionResult Buscar([FromRoute] int oId)
        {
            Order order =
                _context.Order.FirstOrDefault
            (
                o => o.OrderId.Equals(oId)
            );

            return order != null ? Ok(order) : NotFound();
        }

        // DELETE: /api/order/deletar/1
        [Route("deletar/{oId}")]
        [HttpDelete]
        public IActionResult Deletar([FromRoute] int oId)
        {
            Order order =
                _context.Order.Find(oId);
            if (order != null)
            {
                _context.Order.Remove(order);
                _context.SaveChanges();
                return Ok(order);
            }
            return NotFound();
        }

        // PATCH: /api/client/alterar
        [Route("alterar")]
        [HttpPatch]
        public IActionResult Alterar([FromBody] Order order)
        {
            _context.Order.Update(order);
            _context.SaveChanges();
            return Ok(order);
        }
    }
}