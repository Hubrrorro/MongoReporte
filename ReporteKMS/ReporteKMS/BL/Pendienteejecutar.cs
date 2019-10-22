using ReporteKMS.DAL;
using ReporteKMS.Entities;
using ReporteKMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReporteKMS.BL
{
    public class Pendienteejecutar
    {
        public List<ModeloCasosPrueba> Obtener(string seccion)
        {
            DAOSeccion daoSeccion = new DAOSeccion();
            DAOCasosPrueba daoCasosPrueba = new DAOCasosPrueba();
            DAOEstatusCP daoEstatus = new DAOEstatusCP();
            var idSeccion = daoSeccion.ObtenerByNombre(seccion).Id;
            var idPendientes = daoEstatus.ObtenerByNombre("Pendiente a ejecutar").Id;
            var casosprueba = daoCasosPrueba.ObtenerByEstatus(idPendientes,idSeccion);
            return casosprueba.ToList();
        }
        public void CambiarStatus(EntitiesCPEstatus modelo)
        {
            DAOCasosPrueba daoCasosPrueba = new DAOCasosPrueba();
            DAOEstatusCP daoEstatus = new DAOEstatusCP();
            DAOSeccion daoSeccion = new DAOSeccion();
            foreach (string nombre in modelo.cp)
            {
                
                ModeloEstatusCP modeloestatus = daoEstatus.ObtenerByNombre(modelo.estatus);
                ModeloSeccion modeloseccion = daoSeccion.ObtenerByNombre(modelo.seccion);
                ModeloCasosPrueba modelupdate = daoCasosPrueba.ObtenerByNombre(nombre, modeloseccion.Id);
                modelupdate.IdEstatus = modeloestatus.Id;
                modelupdate.FechaEjecucion = DateTime.Now;
                var idupdate = modelupdate.Id;
                daoCasosPrueba.Actualizar(idupdate, modelupdate);
            }
        }
    }
}