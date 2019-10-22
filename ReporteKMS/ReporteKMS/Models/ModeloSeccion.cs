using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReporteKMS.Models
{
    public class ModeloSeccion : ModeloGeneral
    {
        [BsonElement("seccion")]
        public string Seccion { get; set; }
        [BsonElement("idmodulo")]
        public ObjectId IdModulo { get; set; }
        [BsonElement("desarrolladores")]
        public List<ObjectId> Desarrolladores { get; set; }

        [BsonElement("activo")]
        public bool Activo { get; set; }
    }
}