﻿using HilfepatienAPI_Cliente.Models;
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
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            MedicinaCliente em = new MedicinaCliente();
            em.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            MedicinaCliente em = new MedicinaCliente();
            MedicinaViewModel evm = new MedicinaViewModel();
            evm.Medicina = em.find(id);
            return View("Edit", evm);
        }
        [HttpPost]
        public ActionResult Edit(MedicinaViewModel evm)
        {
            MedicinaCliente em = new MedicinaCliente();
            em.Edit(evm.Medicina);
            return RedirectToAction("Index");
        }
    }
}