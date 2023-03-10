using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace paulbanreservas.Models
{
    public class Persona
    {
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public DateTime fechaDeNacimiento { get; set; }
    }
}
