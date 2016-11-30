using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HilfepatienApi.Models
{
    public class Paciente 
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public ICollection<Receta> Receta { get; set; }
        public ICollection<Usuarios> Usuarios { get; set; }
    }
}