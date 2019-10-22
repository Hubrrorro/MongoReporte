using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReporteKMS.Models
{
    public class ModeloModulo : ModeloGeneral
    {
        [BsonElement("modulo")]
        public string Modulo { get; set; }
        [BsonElement("idAplicativo")]
        public ObjectId idAplicativo { get; set; }
        [BsonElement("activo")]
        public bool Activo { get; set; }
    }
}