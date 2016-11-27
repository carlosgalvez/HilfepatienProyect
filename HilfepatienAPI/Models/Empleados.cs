using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace HilfepatienApi.Models
{
    public class Empleados
    {
        [Display(Name="Id")]
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Display(Name = "Puesto")]
        public string Puesto { get; set; }
        [Display(Name = "Fecha_Ingreso")]
        public DateTime Fecha_Ingreso { get; set; }
        [Display(Name = "Sueldo")]
        public int Sueldo { get; set; }

    }
    }
