using HilfepatienAPI_Cliente.Models;
using HilfepatienAPI_Cliente.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HilfepatienAPI_Cliente.Controllers
{
    public class PacienteController : Controller
    {
      
        public ActionResult Index()
        {
            PacienteCliente em = new PacienteCliente();
            ViewBag.listPaciente = em.findAll();
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(PacienteViewModel evm)
        {
            PacienteCliente em = new PacienteCliente();
            em.Create(evm.Paciente);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            PacienteCliente em = new PacienteCliente();
            em.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            PacienteCliente em = new PacienteCliente();
            PacienteViewModel evm = new PacienteViewModel();
            evm.Paciente = em.find(id);
            return View("Edit", evm);
        }
        [HttpPost]
        public ActionResult Edit(PacienteViewModel evm)
        {
            PacienteCliente em = new PacienteCliente();
            em.Edit(evm.Paciente);
            return RedirectToAction("Index");
        }
    }
}