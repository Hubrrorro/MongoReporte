using ReporteKMS.BL;
using ReporteKMS.BL.Catalogos;
using ReporteKMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReporteKMS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Reporte()
        {
            Reporte reporte = new Reporte();
            var resul = reporte.EjecutadosPendientes();
            return Json(resul);
        }
        [HttpPost]
        public ActionResult ReporteCabecera()
        {
            Reporte reporte = new Reporte();
            var resul = reporte.Cabecera();
            return Json(resul);
        }
        [HttpPost]
        public ActionResult EstatusQA()
        {
            Estatus estatus = new Estatus();
            var resul = estatus.QA();
            return Json(resul);
        }

        [HttpPost]
        public ActionResult CP_PendientesEjecutar(string seccion)
        {
            Pendienteejecutar pendientes = new Pendienteejecutar();
            var resul = pendientes.Obtener(seccion);
            return Json(resul);
        }
        [HttpPost]
        public ActionResult CP_CambiarEstatus(EntitiesCPEstatus modelo)
        {
            try
            {
                Pendienteejecutar pendientes = new Pendienteejecutar();
                pendientes.CambiarStatus(modelo);
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }
        [HttpPost]
        public ActionResult Secciones()
        {
            Seccion seccion = new Seccion();
            var resul = seccion.Obtener();
            return Json(resul,JsonRequestBehavior.AllowGet);

        }
    }
}