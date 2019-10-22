using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using ReporteKMS.Models;
using MongoDB.Driver.Linq;
using MongoDB;
using System.Linq;
using System;
namespace ReporteKMS.DAL
{
    public class Conex<T> where T: ModeloGeneral
    {
        private IMongoClient _client;
        private IMongoDatabase _database;
        public IMongoCollection<T> _collection;
        public Conex(string coleccion)
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _database = _client.GetDatabase("ReporteDB");
            _collection = _database.GetCollection<T>(coleccion);
        }
        public List<T> ObtenerTodo()
        {
            return  _collection.Find(new BsonDocument()).ToList();
        }
        public void Agregar(T modelo)
        {
            _collection.InsertOne(modelo);
        }
        public void AgregarMuchos(List<T> modelo)
        {
            _collection.InsertMany(modelo);
        }
        public void Actualizar(ObjectId id, T modelo)
        {
            var filtro = Builders<T>.Filter.Eq(s => s.Id, id);
            _collection.ReplaceOne(filtro, modelo);
        }
        public T ObtenerById(ObjectId id)
        {
            //var filter = new BsonDocument("Id", id);
            var filter = Builders<T>.Filter.Eq(x => x.Id, id);
            return _collection.Find(filter).FirstOrDefault();
        }
    }
}