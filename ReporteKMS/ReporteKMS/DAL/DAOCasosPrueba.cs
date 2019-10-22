using MongoDB.Bson;
using MongoDB.Driver;
using ReporteKMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReporteKMS.DAL
{
    public class DAOCasosPrueba : Conex<ModeloCasosPrueba>
    {
        public DAOCasosPrueba() : base("CasosPrueba")
        {

        }
        public List<ModeloCasosPrueba> ObtenerByIdSeccion(ObjectId id)
        {
            var filter = new BsonDocument("idseccion", id);
            return _collection.Find(filter).ToList();
        }
        public ModeloCasosPrueba ObtenerByNombre(string nombre)
        {
            var filter = new BsonDocument("casoprueba", nombre);
            return _collection.Find(filter).FirstOrDefault();
        }
        public ModeloCasosPrueba ObtenerByNombre(string nombre, ObjectId idSeccion)
        {
            //var filter = new BsonDocument("casoprueba", nombre);
            var filter = new BsonDocument() {
                new BsonElement("casoprueba", nombre),
                new BsonElement("idseccion", idSeccion)
            };
            return _collection.Find(filter).FirstOrDefault();
        }
        public List<ModeloCasosPrueba> ObtenerByEstatus(ObjectId id)
        {
            var filter = new BsonDocument("idEstatus", id);
            return _collection.Find(filter).ToList();
        }
        public List<ModeloCasosPrueba> ObtenerByEstatus(ObjectId idEst, ObjectId idSeccion)
        {
            var filter = new BsonDocument() {
                new BsonElement("idEstatus", idEst),
                new BsonElement("idseccion", idSeccion)
            };
            return _collection.Find(filter).ToList();
        }

    }
}