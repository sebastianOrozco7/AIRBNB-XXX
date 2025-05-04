using System.ComponentModel.DataAnnotations;

namespace AIRBNB_XXX.Models
{
    public class Reserva
    {
       
        [Required]
        public int CedulaCliente {  get; set; }
        [Required]
        public int IDHabitacion {  get; set; }
        [Required]
        public DateTime FechaInicio {  get; set; }
        [Required]
        public DateTime FechaFin {  get; set; }

    }
}
