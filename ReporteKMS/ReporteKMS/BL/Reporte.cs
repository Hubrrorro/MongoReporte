using ReporteKMS.DAL;
using ReporteKMS.Entities;
using ReporteKMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReporteKMS.BL
{
    public class Reporte
    {
        public int DiasLaborables(DateTime fechaInicio, DateTime FechaFin)
        {
            int cantDias= 0;
            for (DateTime a = fechaInicio; a <= FechaFin; a= a.AddDays(1))
            {
                if (((Int32)a.DayOfWeek > 0) && ( (Int32)a.DayOfWeek < 6))
                    cantDias++;
            }
            return cantDias;
        }
        public EntitieCabeceraReporte Cabecera() {
            EntitieCabeceraReporte cabecera = new EntitieCabeceraReporte();
            List<EntitieReporteEjecutadosPorEjecutar> reporte = new List<EntitieReporteEjecutadosPorEjecutar>();
            DAOCasosPrueba daoCasosPrueba = new DAOCasosPrueba();
            DAOPersonal daoPersoanl = new DAOPersonal();
            DAOSeccion daoSeccion = new DAOSeccion();
            DAOEstatusCP daoEstatus = new DAOEstatusCP();
            List<ModeloCasosPrueba> casosPrueba = daoCasosPrueba.ObtenerTodo();
            var agrupado = casosPrueba.GroupBy(info => info.IdSeccion).Select(group => new
            {
                IdSeccion = group.Key,
                Total = group.Count()
            });
            foreach (var indice in agrupado)
            {
                EntitieReporteEjecutadosPorEjecutar repcasoPrueba = new EntitieReporteEjecutadosPorEjecutar();
                repcasoPrueba.Seccion = daoSeccion.ObtenerById(indice.IdSeccion).Seccion;
                repcasoPrueba.TotalCP = indice.Total;
                var resulSeccion = daoCasosPrueba.ObtenerByIdSeccion(indice.IdSeccion);
                DateTime fechaMin = resulSeccion.Select(x => x.FechaEstimadaInicio).Min();
                DateTime fechaMax = resulSeccion.Select(x => x.FechaEstimadaFin).Max();
                repcasoPrueba.FechaFin = fechaMax.ToShortDateString();
                repcasoPrueba.FechaInicio = fechaMin.ToShortDateString();
                var personalQA = resulSeccion.Select(x => x.persoanlEje).Distinct();
                string responsablesQA = String.Empty;
                foreach (var personaQA in personalQA)
                {
                    responsablesQA += daoPersoanl.ObtenerById(personaQA).Personal + ",";
                }
                repcasoPrueba.ResponsableQA = responsablesQA;
                var idEstatusPendiente = daoEstatus.ObtenerByNombre("Pendiente a ejecutar").Id;
                repcasoPrueba.PorEjecutarReal = resulSeccion.Where(x => x.IdEstatus == idEstatusPendiente).Count();
                var idEstatusEjecutadoExito = daoEstatus.ObtenerByNombre("Ejecutados exitosamente").Id;
                repcasoPrueba.EjecutadosExito = resulSeccion.Where(x => x.IdEstatus.Equals(idEstatusEjecutadoExito)).Count();
                var idEstatusEjecutadoIncidencia = daoEstatus.ObtenerByNombre("Incidencia").Id;
                repcasoPrueba.EjecutadosIncidencia = resulSeccion.Where(x => x.IdEstatus.Equals(idEstatusEjecutadoIncidencia)).Count();
                repcasoPrueba.EjecutadosReal = repcasoPrueba.EjecutadosIncidencia + repcasoPrueba.EjecutadosExito;
                int diasLab = DiasLaborables(fechaMin, fechaMax);
                repcasoPrueba.MediaDia = indice.Total / diasLab;
                DateTime fechaEst = fechaMax;
                if (fechaMax > DateTime.Now)
                    fechaEst = DateTime.Now;
                int diasLabFechaEst = DiasLaborables(fechaMin, fechaEst);
                int CantCPEst = (Int32)(repcasoPrueba.MediaDia * diasLabFechaEst);
                if (fechaMax < DateTime.Now)
                    CantCPEst = indice.Total;
                double porcentajeReal, porcentajeEstimado;
                porcentajeReal = (repcasoPrueba.EjecutadosReal * 100) / indice.Total;
                porcentajeEstimado = (CantCPEst * 100) / indice.Total;
                repcasoPrueba.AvanceEstimado = (Int32)porcentajeEstimado;
                repcasoPrueba.AvanceReal = (Int32)porcentajeReal;
                repcasoPrueba.EjecutadosEstimado = CantCPEst;
                repcasoPrueba.PorEjecutarEstimado = indice.Total - CantCPEst;
                reporte.Add(repcasoPrueba);
            }
            cabecera.Fecha = DateTime.Now.ToShortDateString();
            cabecera.AvanceEsperado = ((reporte.Select(x => x.AvanceEstimado).Sum()) / reporte.Count()).ToString();
            cabecera.AvanceReal = ((reporte.Select(x => x.AvanceReal).Sum()) / reporte.Count()).ToString();
            return cabecera;
        }
        public List<EntitieReporteEjecutadosPorEjecutar> EjecutadosPendientes()
        {
            List<EntitieReporteEjecutadosPorEjecutar> reporte = new List<EntitieReporteEjecutadosPorEjecutar>();
            DAOCasosPrueba daoCasosPrueba = new DAOCasosPrueba();
            DAOPersonal daoPersoanl = new DAOPersonal();
            DAOSeccion daoSeccion = new DAOSeccion();
            DAOEstatusCP daoEstatus = new DAOEstatusCP();
            List<ModeloCasosPrueba> casosPrueba = daoCasosPrueba.ObtenerTodo();
            var agrupado = casosPrueba.GroupBy(info => info.IdSeccion).Select(group => new
            {
                IdSeccion = group.Key,
                Total = group.Count()
            });
            foreach (var indice in agrupado)
            {
                EntitieReporteEjecutadosPorEjecutar repcasoPrueba = new EntitieReporteEjecutadosPorEjecutar();
                repcasoPrueba.Seccion = daoSeccion.ObtenerById(indice.IdSeccion).Seccion;
                repcasoPrueba.TotalCP = indice.Total;
                var resulSeccion = daoCasosPrueba.ObtenerByIdSeccion(indice.IdSeccion);
                DateTime fechaMin = resulSeccion.Select(x => x.FechaEstimadaInicio).Min();
                DateTime fechaMax = resulSeccion.Select(x => x.FechaEstimadaFin).Max();
                repcasoPrueba.FechaFin = fechaMax.ToShortDateString();
                repcasoPrueba.FechaInicio = fechaMin.ToShortDateString();
                var personalQA= resulSeccion.Select(x => x.persoanlEje).Distinct();
                string responsablesQA = String.Empty;
                foreach (var personaQA in personalQA)
                {
                    responsablesQA += daoPersoanl.ObtenerById(personaQA).Personal + ",";
                }
                repcasoPrueba.ResponsableQA = responsablesQA;
                var idEstatusPendiente = daoEstatus.ObtenerByNombre("Pendiente a ejecutar").Id;
                repcasoPrueba.PorEjecutarReal = resulSeccion.Where(x => x.IdEstatus == idEstatusPendiente).Count();
                var idEstatusEjecutadoExito = daoEstatus.ObtenerByNombre("Ejecutados exitosamente").Id;
                repcasoPrueba.EjecutadosExito = resulSeccion.Where(x => x.IdEstatus.Equals(idEstatusEjecutadoExito)).Count();
                var idEstatusEjecutadoIncidencia = daoEstatus.ObtenerByNombre("Incidencia").Id;
                repcasoPrueba.EjecutadosIncidencia = resulSeccion.Where(x => x.IdEstatus.Equals(idEstatusEjecutadoIncidencia)).Count();
                repcasoPrueba.EjecutadosReal = repcasoPrueba.EjecutadosIncidencia + repcasoPrueba.EjecutadosExito;
                int diasLab = DiasLaborables(fechaMin, fechaMax);
                repcasoPrueba.MediaDia = indice.Total / diasLab;
                DateTime fechaEst = fechaMax;
                if (fechaMax > DateTime.Now)
                    fechaEst = DateTime.Now;
                int diasLabFechaEst = DiasLaborables(fechaMin, fechaEst);
                int CantCPEst = (Int32)(repcasoPrueba.MediaDia * diasLabFechaEst);
                if (fechaMax < DateTime.Now)
                    CantCPEst = indice.Total;
                double porcentajeReal, porcentajeEstimado;
                porcentajeReal = (repcasoPrueba.EjecutadosReal * 100) / indice.Total;
                porcentajeEstimado = (CantCPEst * 100) / indice.Total;
                repcasoPrueba.AvanceEstimado = (Int32)porcentajeEstimado;
                repcasoPrueba.AvanceReal = (Int32)porcentajeReal;
                repcasoPrueba.EjecutadosEstimado = CantCPEst;
                repcasoPrueba.PorEjecutarEstimado = indice.Total - CantCPEst;
                reporte.Add(repcasoPrueba);
            }
            return reporte;
        }
    }
}