using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HilfepatienAPI_Cliente.Models;
using HilfepatienAPI_Cliente.ViewModels;
namespace HilfepatienAPI_Cliente.Controllers
{
    public class EmpleadosController : Controller
    {
       
        public ActionResult Index()
        {
            EmpleadosCliente em = new EmpleadosCliente();
            ViewBag.listEmpleados = em.findAll();
            return View();
        }

        [HttpGet]
        public ActionResult Create() {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(EmpleadosViewModel evm)
        {
            evm.Empleados.Fecha_Ingreso = DateTime.Now;
            EmpleadosCliente em = new EmpleadosCliente();
            em.Create(evm.Empleados);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            EmpleadosCliente em = new EmpleadosCliente();
            em.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmpleadosCliente em = new EmpleadosCliente();
            EmpleadosViewModel evm = new EmpleadosViewModel();
            evm.Empleados = em.find(id);
            return View("Edit", evm);
        }
        [HttpPost]
        public ActionResult Edit(EmpleadosViewModel evm)
        {
            EmpleadosCliente em = new EmpleadosCliente();
            em.Edit(evm.Empleados);
            return RedirectToAction("Index");
        }
	}
}