using AIRBNB_XXX.Data;
using AIRBNB_XXX.Models;
using Microsoft.AspNetCore.Mvc;

namespace AIRBNB_XXX.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ClienteController : Controller
    {
        public ClienteRepositorio clienteRepositorio = new ClienteRepositorio();
        public bool Resultado;


        [HttpPost]
        public IActionResult RegistrarCliente(Cliente cliente)
        {
            try
            {
                Resultado = clienteRepositorio.RegistrarCliente(cliente);

                if (Resultado)
                    return Ok("CLIENTE REGISTRADO CORRECTAMENTE");
                else
                    return BadRequest("ALGO SALIO MAL INTENTA REGISTRARTE DE NUEVO");
            }
            catch(Exception Ex)
            {
                return StatusCode(500, "Error inesperado: " + Ex.Message);
            }
        }
    }
}
