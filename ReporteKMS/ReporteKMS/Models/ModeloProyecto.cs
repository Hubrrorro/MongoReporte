using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReporteKMS.Models
{
    public class ModeloProyecto : ModeloGeneral
    {
        [BsonElement("proyecto")]
        public string Proyecto { get; set; }
        [BsonElement("activo")]
        public bool Activo { get; set; }
    }
}