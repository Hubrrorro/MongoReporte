using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReporteKMS.Models
{
    public class ModeloPersonal : ModeloGeneral
    {
        [BsonElement("personal")]
        public string Personal { get; set; }
        [BsonElement("idArea")]
        public ObjectId IdArea { get; set; }
        [BsonElement("correo")]
        public string Correo { get; set; }
        [BsonElement("activo")]
        public bool Activo { get; set; }
    }
}