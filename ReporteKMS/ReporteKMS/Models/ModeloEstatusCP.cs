using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReporteKMS.Models
{
    public class ModeloEstatusCP : ModeloGeneral
    {
        [BsonElement("estatus")]
        public string Estatus { get; set; }
        [BsonElement("activo")]
        public bool Activo { get; set; }
    }
}