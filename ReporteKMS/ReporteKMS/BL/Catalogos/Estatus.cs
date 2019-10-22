using ReporteKMS.DAL;
using ReporteKMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReporteKMS.BL.Catalogos
{
    public class Estatus
    {
        public List<ModeloEstatusCP> QA()
        {
            DAOEstatusCP daoEstatusCP = new DAOEstatusCP();
            var todo = daoEstatusCP.ObtenerTodo().Where(x => x.Estatus.Contains("Ejecutados exitosamente") || x.Estatus.Contains("Incidencia"));
            return todo.ToList() ;
        }
    }
}