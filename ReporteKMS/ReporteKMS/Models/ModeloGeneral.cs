using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ReporteKMS.Models
{
    public class ModeloGeneral
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}