using ReporteKMS.BL.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReporteKMS.Controllers
{
    public class CargaInicialController : Controller
    {
        // GET: CargaInicial
        public ActionResult Index()
        {
            return View();
        }

        // GET: CargaInicial/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CargaInicial/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CargaInicial/Create
        [HttpPost]
        public ActionResult CreateInical()
        {
            try
            {
                CargaInicial blCargaInicial = new CargaInicial();
                blCargaInicial.Inicio();
                return Json(new { success = true });
            }
            catch {
                return Json(new { success = false });
            }
        }

        // GET: CargaInicial/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CargaInicial/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CargaInicial/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CargaInicial/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
