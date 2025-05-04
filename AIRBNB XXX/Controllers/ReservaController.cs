using AIRBNB_XXX.Data;
using AIRBNB_XXX.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AIRBNB_XXX.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ReservaController : Controller
    {
        public ReservaRepositorio reservaRepositorio = new ReservaRepositorio();
        public bool Resultado;

        [HttpPost]
        public IActionResult Reservar(Reserva reserva)
        {
            try
            {
                Resultado = reservaRepositorio.ReservarHabitacion(reserva);

                if (Resultado)
                    return Ok("HABITACION RESERVADA CON EXITO");
                else
                    return BadRequest("ERROR AL RESERVAR, INTENTELO DE NUEVO");
            }
            catch (Exception Ex)
            {
                return StatusCode(500, "Error inesperado: " + Ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult EliminarReserva(int IdReserva,int IdHabitacion)
        {
            try
            {
                Resultado = reservaRepositorio.EliminarReserva(IdReserva,IdHabitacion);

                if (Resultado)
                    return Ok("RESERVADA ELIMINADA CON EXITO");
                else
                    return BadRequest("ERROR AL ELIMINAR LA RESERVA, INTENTELO DE NUEVO");
            }
            catch (Exception Ex)
            {
                return StatusCode(500, "Error inesperado: " + Ex.Message);
            }
        }

    }
}
