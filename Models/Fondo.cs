using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FondoBTG.Models
{
    public class Fondo
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public int code { get; set; }
        public string Name { get; set; }
        public double Minimum_amount { get; set; }
        public string category { get; set;}
        public string state { get; set;}
    }
}
