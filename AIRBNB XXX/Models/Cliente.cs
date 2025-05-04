using System.ComponentModel.DataAnnotations;

namespace AIRBNB_XXX.Models
{
    public class Cliente
    {
        [Required]
        public int Cedula {  get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Telefono {  get; set; }
        [Required]
        public string Correo {  get; set; }
    }
}
