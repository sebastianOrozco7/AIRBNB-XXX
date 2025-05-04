using AIRBNB_XXX.Data;
using AIRBNB_XXX.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
namespace AIRBNB_XXX.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HabitacionController : Controller
    {
        public HabitacionRepositorio habitacionRepositorio = new HabitacionRepositorio();
        public bool Resultado;

        [HttpPost]
        public IActionResult AgregarHabitacion(Habitacion habitacion)
        {
            try
            {
                Resultado = habitacionRepositorio.AñadirHabitacion(habitacion);

                if (Resultado)
                    return Ok("HABITACION AÑADIDA CORRECTAMENTE");
                else
                    return BadRequest("ERROR AL AÑADIR LA HABITACION");
            }
            catch (Exception Ex)
            {
                return StatusCode(500, "Error inesperado: " + Ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult EliminarHabitacion(int id)
        {
            try
            {
                Resultado = habitacionRepositorio.ElimarHabitacion(id);

                if (Resultado)
                    return Ok("HABITACION ELIMINADA CORRECTAMENTE");
                else
                    return NotFound("HABITACION NO ENCONTRADA VERIFIQUE EL ID");

            }
            catch (Exception Ex)
            {
                return StatusCode(500, "Error inesperado: " + Ex.Message);
            }
        }

    }
}
