using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HilfepatienApi.Models
{
    public class Empleados
    {
        
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Puesto { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
        public int Sueldo { get; set; }

    }
    }
