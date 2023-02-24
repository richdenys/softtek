using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using VentasSofttek.DAL.DBContext;
using VentasSofttek.Models.GesVentas;
using VentasSofttek.Models.Login;
using VentasSofttek.Models.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VentasSofttek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VentasController : ControllerBase
    {
        private VentasSofttekDBContext _context;

        public VentasController(VentasSofttekDBContext context)
        {
            _context = context;
        }

        // GET: api/<VentasController>
        [HttpGet]
        public List<Ventas> Get()
        {
            return _context.Ventas.ToList();
        }

        // GET: api/<VentasController>
        [HttpGet]
        [Route("Clients")]
        public List<Clients> Clients()
        {
            return _context.Clients.ToList();
        }

        // GET: api/<VentasController>
        [HttpGet]
        [Route("Products")]
        public List<Product> Products()
        {
            return _context.Prodcuts.ToList();
        }

        // GET FILTRO POR CODIGO DE VENDEDOR
        [HttpGet]
        [Route("getVentasVendedor/{id}")]
        public ActionResult getVentasVendedor(string id)
        {

            return Ok(_context.Ventas.Where(f => f.CodVendedor == id));
        }
        // GET FILTRO POR CODIGO DE Clinte
        [HttpGet]
        [Route("getVentasCliente/{id}")]
        public ActionResult getVentasCliente(string id)
        {
            return Ok(_context.Ventas.Where(f => f.CodClient == id));
        }


        // POST api/<VentasController>
        [HttpPost]
        public IActionResult Post([FromBody] Ventas ventas)
        {

            _context.Ventas.Add(ventas);
            _context.SaveChanges();
            return Created("api/Ventas/"+ventas.ID,ventas);
        }

        // PUT api/<VentasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Ventas ventas)
        {
            _context.Ventas.Update(ventas);
            _context.SaveChanges();
            return Created("api/Ventas/" + ventas.ID, ventas);

        }

        // DELETE api/<VentasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
