using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using ReporteKMS.Models;

namespace ReporteKMS.DAL
{
    public class Conex<T> where T: ModeloGeneral
    {
        private IMongoClient _client;
        private IMongoDatabase _database;
        private IMongoCollection<T> _usersCollection;
        public Conex(string coleccion)
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _database = _client.GetDatabase("ReporteDB");
            _usersCollection = _database.GetCollection<T>(coleccion);
        }
        public List<T> ObtenerTodo()
        {
            return  _usersCollection.Find(new BsonDocument()).ToList();
        }
        public void Agregar(T modelo)
        {
            _usersCollection.InsertOne(modelo);
        }
        public void AgregarMuchos(List<T> modelo)
        {
            _usersCollection.InsertMany(modelo);
        }
    }
}