using HilfepatienAPI_Cliente.Models;
using HilfepatienAPI_Cliente.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HilfepatienAPI_Cliente.Controllers
{
    public class MedicinaController : Controller
    {
        public ActionResult Index()
        {
            MedicinaCliente em = new MedicinaCliente();
            ViewBag.listMedicina = em.findAll();
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(MedicinaViewModel evm)
        {
            MedicinaCliente em = new MedicinaCliente();
            em.Create(evm.Medicina);
            return View("Index");
        }
    }
}