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
      public IActionResult Listar() => Ok(_context.Orders.ToList());

      // POST: /api/order/cadastrar
        [Route("cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar([FromBody] Orders order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return Created("", order);
        }

        // GET: /api/order/buscar/1
        [Route("buscar/{oId}")]
        [HttpGet]
        public IActionResult Buscar([FromRoute] int oId)
        {
            Orders order =
                _context.Orders.FirstOrDefault
            (
                o => o.OrdersId.Equals(oId)
            );

            return order != null ? Ok(order) : NotFound();
        }

        // DELETE: /api/order/deletar/1
        [Route("deletar/{oId}")]
        [HttpDelete]
        public IActionResult Deletar([FromRoute] int oId)
        {
            Orders order =
                _context.Orders.Find(oId);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
                return Ok(order);
            }
            return NotFound();
        }

        // PATCH: /api/client/alterar
        [Route("alterar")]
        [HttpPatch]
        public IActionResult Alterar([FromBody] Orders order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
            return Ok(order);
        }
    }
}
