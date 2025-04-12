using System.ComponentModel.DataAnnotations;

namespace ClienteApi2.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre solo puede contener letras.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El correo electr�nico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo electr�nico no tiene un formato v�lido.")]
        public string CorreoElectronico { get; set; }

        [Required(ErrorMessage = "El tel�fono es obligatorio.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El tel�fono solo puede contener n�meros.")]
        public string Telefono { get; set; }
    }
}
