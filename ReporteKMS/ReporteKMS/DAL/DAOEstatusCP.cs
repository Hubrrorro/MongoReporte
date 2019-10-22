using MongoDB.Bson;
using MongoDB.Driver;
using ReporteKMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReporteKMS.DAL
{
    public class DAOEstatusCP : Conex<ModeloEstatusCP>
    {
        public DAOEstatusCP() : base("EstatusCP")
        {

        }
        public ModeloEstatusCP ObtenerByNombre(string estatus)
        {
            var filter = new BsonDocument("estatus", estatus);
            return _collection.Find(filter).FirstOrDefault();
        }
    }
}