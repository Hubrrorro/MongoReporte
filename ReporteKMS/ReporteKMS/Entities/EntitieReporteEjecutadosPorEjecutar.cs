using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReporteKMS.Entities
{
    public class EntitieReporteEjecutadosPorEjecutar
    {
        public string Seccion { get; set; }
        public int  TotalCP { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public double MediaDia { get; set; }
        public int EjecutadosReal { get; set; }
        public int EjecutadosExito { get; set; }
        public int EjecutadosIncidencia { get; set; }
        public int PorEjecutarReal { get; set; }
        public int EjecutadosEstimado { get; set; }
        public int PorEjecutarEstimado { get; set; }
        public string ResponsableQA { get; set; }
        public List<string> Desarrollador { get; set; }
        public int AvanceReal { get; set; }
        public int AvanceEstimado { get; set; }

    }
}