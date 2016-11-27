using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HilfepatienApi.Models;
using System.Data.Entity;
namespace HilfepatienApi.Controllers
{
    public class UsuariosController : ApiController
    {
        private HilfepatienContext db = new HilfepatienContext();
        // GET api/usuarios
        public List<Usuarios> Get()
        {
            return db.Usuarios.ToList();
        }

        // GET api/usuarios/5
        public List<Usuarios>Get(int Id)
        {
            return db.Usuarios.Where(e => e.Id == Id).ToList();
        }

        // POST api/usuarios
        public bool Post(int Id, string Contraseña, int Medico_Id,int Paciente_Id)
        {
            var e = new Usuarios
            {
                Id = Id,
                Contraseña = Contraseña,
                Medico_Id = Medico_Id,
                Paciente_Id = Paciente_Id
            };

            db.Usuarios.Attach(e);
            db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = true;
            return db.SaveChanges() > 0;
        }

        // PUT api/usuarios/5
        public bool Put(string Contraseña, int Medico_Id, int Paciente_Id)

        {
            var Usuarios = new Usuarios
            {
                Contraseña = Contraseña,
                Medico_Id= Medico_Id


            };
            db.Usuarios.Add(Usuarios);
            return db.SaveChanges() > 0;
        }

        // DELETE api/usuarios/5
        public bool Delete(int Id)
        {
            var e = db.Usuarios.Find(Id);
            db.Usuarios.Attach(e);
            db.Usuarios.Remove(e);
            return db.SaveChanges() > 0;
        }
    }
}
