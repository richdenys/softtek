using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VentasSofttek.DAL.DBContext;
using VentasSofttek.DTO.Service;
using VentasSofttek.Models.Login;
using VentasSofttek.Models.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VentasSofttek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private VentasSofttekDBContext _context;
        private IUserService _userService;
        public UsersController(VentasSofttekDBContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        // GET: api/<VentasController>
        [HttpGet]
        public List<AuthRequest> Get()
        {
            return _context.MUsers.ToList();
        }

        // POST api/<UsersController>
        [HttpPost]
        [Route("Login")]
        public ActionResult Login([FromBody] AuthRequest auth)
        {
            Respuesta respuesta=new Respuesta();
            var userresponse = _userService.Autch(auth);
            if (userresponse==null)
            {
                respuesta.Mensaje = "Los datos no son correctos";
                respuesta.Exito = 0;

            }
            else
            {
                respuesta.Exito = 1;
                respuesta.data = userresponse;
            }
            return Ok(respuesta);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AuthRequest user)
        {
            _context.MUsers.Add(user);
            _context.SaveChanges();
            return Created("api/Ventas/" + user.Email, user);
        }

 
    }
}
