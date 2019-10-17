using MongoDB.Bson.Serialization.Attributes;


namespace ReporteKMS.Models
{
    public class ModelAplicativo : ModeloGeneral
    {
        [BsonElement("Aplicativo")]
        public string Aplicativo { get; set; }
        [BsonElement("Activo")]
        public int Activo { get; set; }
    }
}