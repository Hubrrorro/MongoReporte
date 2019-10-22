using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReporteKMS.Models
{
    public class ModeloArea : ModeloGeneral
    {
        [BsonElement("area")]
        public string Area { get; set; }
        [BsonElement("activo")]
        public bool Activo { get; set; }
    }
}
