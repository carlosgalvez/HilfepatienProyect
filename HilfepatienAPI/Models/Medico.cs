using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HilfepatienApi.Models
{
    public class Medico
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Especialidad { get; set; }
        public int Telefono { get; set; }

    }
}