using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HilfepatienApi.Models
{
    public class Receta
    {
        public int Id { get; set; }
        public String Tipo_Medicamento { get; set; }
        public String Nombre_Medicamento { get; set; }
        public String Nombre_Paciente { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Paciente Paciente {get;set;}
       
    }
}