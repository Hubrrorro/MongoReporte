using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReporteKMS.Models
{
    public class ModeloCasosPrueba: ModeloGeneral
    {
        [BsonElement("casoprueba")]
        public string CasoPrueba { get; set; }
        [BsonElement("fechaEstimadaInicio")]
        public DateTime FechaEstimadaInicio { get; set; }
        [BsonElement("fechaEstimadaFin")]
        public DateTime FechaEstimadaFin { get; set; }
        [BsonElement("fechaEjecucion")]
        public DateTime FechaEjecucion { get; set; }
        [BsonElement("fechaCorreccion")]
        public DateTime FechaCorreccion { get; set; }
        [BsonElement("ciclo")]
        public int Ciclo { get; set; }
        [BsonElement("personalEje")]
        public ObjectId persoanlEje { get; set; }
        [BsonElement("personalCorr")]
        public ObjectId persoanlCorr { get; set; }
        [BsonElement("idEstatus")]
        public ObjectId IdEstatus { get; set; }
        [BsonElement("idseccion")]
        public ObjectId IdSeccion { get; set; }
        [BsonElement("seccion")]
        public string seccion { get; set; }
    }
}