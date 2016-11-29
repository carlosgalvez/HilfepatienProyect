using HilfepatienApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HilfepatienApi.Models
{
    public class Medicina
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Display(Name = "Presentacion")]
        public string Presentacion { get; set; }
        [Display(Name = "TipodeMedicamento")]
        public string TipodeMedicamento { get; set; }

        public virtual ICollection<Proveedor> Proveedor { get; set; }
      

    }
}