using System.ComponentModel.DataAnnotations;

namespace AIRBNB_XXX.Models
{
    public class Habitacion
    {
        [Required]
        public int IDHabitacion { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public float Precio { get; set; }
        [Required]
        public bool Diponibilidad {  get; set; }

    }
}
