using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JugadoresFutbolPeruano.Models
{
    public class Player
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        public string Name { get; set; } = string.Empty; // Inicialización para evitar errores

        [Required(ErrorMessage = "La edad es obligatoria")]
        [Range(18, 40, ErrorMessage = "La edad debe estar entre 18 y 40 años")]
        public int Age { get; set; }

        [Required(ErrorMessage = "La posición es obligatoria")]
        [StringLength(50, ErrorMessage = "La posición no puede exceder los 50 caracteres")]
        public string Position { get; set; } = string.Empty; // Inicialización para evitar errores

        public int? TeamId { get; set; }
        public Team Team { get; set; } = new Team(); // Inicialización para evitar errores

        public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>(); // Inicialización para evitar errores
    }
}