using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FondoBTG.Models
{
    public class FondoCliente
    {
        [BsonId]
        public String Id { get; set; }
        public String Nombre { get; set; }
        public Double Valor { get; set; }
        public DateTime FechaRegistro { get; set; }
        public String State { get; set; }

    }
}
