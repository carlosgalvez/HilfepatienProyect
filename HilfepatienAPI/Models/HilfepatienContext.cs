using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace HilfepatienApi.Models
{
    public class HilfepatienContext : DbContext
    {
        public HilfepatienContext() : base("HilfepatienContext") { }

        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Medicina> Medicinas { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Receta> Recetas { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        protected override void OnModelCreating(DbModelBuilder HilfepatienContext)
        {
            HilfepatienContext.Conventions.Remove<PluralizingTableNameConvention>();
           
        }

     
    }
}