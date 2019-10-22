using ReporteKMS.DAL;
using ReporteKMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReporteKMS.BL.Catalogos
{
    public class Seccion
    {
        public List<ModeloSeccion> Obtener()
        {
            DAOSeccion daoSeccion = new DAOSeccion();
            var todo = daoSeccion.ObtenerTodo();
            return todo.ToList();
        }
    }
}