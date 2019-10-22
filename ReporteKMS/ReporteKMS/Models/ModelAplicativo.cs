using MongoDB.Bson.Serialization.Attributes;


namespace ReporteKMS.Models
{
    public class ModelAplicativo : ModeloGeneral
    {
        [BsonElement("aplicativo")]
        public string Aplicativo { get; set; }
        [BsonElement("activo")]
        public bool Activo { get; set; }
    }
}