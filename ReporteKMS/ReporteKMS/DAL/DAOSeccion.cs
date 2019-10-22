using MongoDB.Bson;
using MongoDB.Driver;
using ReporteKMS.Models;
using System;
using System.Collections.Generic;
using System.Web;

namespace ReporteKMS.DAL
{
    public class DAOSeccion : Conex<ModeloSeccion>
    {
        public DAOSeccion() : base("Seccion")
        {
        }
        public ModeloSeccion ObtenerByNombre(string seccion)
        {

            var filter = new BsonDocument("seccion", seccion);
            return _collection.Find(filter).FirstOrDefault();
        }
    }
}