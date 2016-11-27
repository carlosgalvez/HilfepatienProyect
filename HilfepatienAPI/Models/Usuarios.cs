using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HilfepatienApi.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Contraseña { get; set; }
        public int Medico_Id { get; set; }
        public int Paciente_Id { get; set; }
        public virtual Paciente Paciente { get; set; }
        public virtual Medico Medico { get; set; }

    }
}