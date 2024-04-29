using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FondoBTG.Models
{
    public class Cliente
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Identification { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public List<FondoCliente>? fondos { get; set; }
        
    }
}
