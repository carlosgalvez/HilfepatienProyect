using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HilfepatienApi.Models
{
    public class Empleados
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display (Name="Nombre")]
        public string Nombre { get; set; }
        [Display (Name="Puesto")]
        public string Puesto { get; set; }
        [Display (Name="Fecha_Ingreso")]
        public DateTime Fecha_Ingreso { get; set; }
        [Display (Name="Sueldo")]
        public int Sueldo { get; set; }

    }
    }
