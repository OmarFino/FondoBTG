using FondoBTG.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FondoBTG.Repositories
{
    public class FondoCollection : IFondoCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Fondo> Collection;

        public FondoCollection() 
        {
            Collection = _repository.db.GetCollection<Fondo>("Fondos");
        }
        public async Task<List<Fondo>> GetAllFondo()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<List<Fondo>> GetAllFondoActi()
        {
            var filter = Builders<Fondo>.Filter.Eq("state", "A");
            return await Collection.FindAsync(filter).Result.ToListAsync();
           
        }

        public async Task<Fondo> GetFondoById(string id)
        {
            var filter = Builders<Fondo>.Filter.Eq("code", id);
            return await Collection.Find(filter).FirstOrDefaultAsync(); ;
        }

        public async Task InsertFondo(Fondo fondo)
        {
            await Collection.InsertOneAsync(fondo);
        }

        public async Task<String> UpdateFondoAdd(string id)
        {
            var filter = Builders<Fondo>.Filter.Eq("code", id);
            var update = Builders<Fondo>.Update.Set("state", "A");

            var result = await Collection.UpdateOneAsync(filter, update);
            if (result.ModifiedCount > 0)
            {
                return "Fondo agregado correctamente";
            }
            return "No se encontró ningún fondo para agregar";

        }

        public async Task<String> UpdateFondoDelete(string id)
        {
            var filter = Builders<Fondo>.Filter.Eq("code", id);
            var update = Builders<Fondo>.Update.Set("state", "I");

            var result = await Collection.UpdateOneAsync(filter, update);
            if (result.ModifiedCount > 0)
            {
                return "Fondo eliminado correctamente";
            }
            return "No se encontró ningún fondo para eliminar";

        }
    }
}
