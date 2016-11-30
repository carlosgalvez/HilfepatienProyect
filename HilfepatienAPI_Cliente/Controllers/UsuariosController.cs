using HilfepatienAPI_Cliente.Models;
using HilfepatienAPI_Cliente.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HilfepatienAPI_Cliente.Controllers
{
    public class UsuariosController : Controller
    {
        public ActionResult Index()
        {
            UsuariosCliente em = new UsuariosCliente();
            ViewBag.listUsuarios = em.findAll();
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(UsuariosViewModel evm)
        {
          
            UsuariosCliente em = new UsuariosCliente();
            em.Create(evm.Usuarios);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            UsuariosCliente em = new UsuariosCliente();
            em.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            UsuariosCliente em = new UsuariosCliente();
            UsuariosViewModel evm = new UsuariosViewModel();
            evm.Usuarios = em.find(id);
            return View("Edit", evm);
        }
        [HttpPost]
        public ActionResult Edit(UsuariosViewModel evm)
        {
            UsuariosCliente em = new UsuariosCliente();
            em.Edit(evm.Usuarios);
            return RedirectToAction("Index");
        }
	}
}