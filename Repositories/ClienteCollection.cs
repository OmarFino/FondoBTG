using FondoBTG.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FondoBTG.Repositories
{
    public class ClienteCollection : IClienteCollection
    {

        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Cliente> Collection;

        public ClienteCollection()
        {
            Collection = _repository.db.GetCollection<Cliente>("Cliente");
        }
        public async Task InsertCliente(Cliente cliente)
        {
            try
            {
                await Collection.InsertOneAsync(cliente);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Cliente> GetClienteById(string id)
        {
            var filter = Builders<Cliente>.Filter.Eq("Identification", id);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<Cliente> GetPrimerCliente()
        {
            return await Collection.Find(new BsonDocument()).FirstOrDefaultAsync();
        }

        public async Task<Boolean> AddFondoCliente(string identification, FondoCliente fondoCliente)
        {

            try
            {
                var filter = Builders<Cliente>.Filter.Eq("Identification", identification);
                var update = Builders<Cliente>.Update.Push("fondos", fondoCliente);
                var result = await Collection.UpdateOneAsync(filter, update);
                return result.ModifiedCount > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public async Task<Boolean> DeleteFondoCliente(string identification, string id)
        {

            try
            {
                var filter = Builders<Cliente>.Filter.And(
                Builders<Cliente>.Filter.Eq("Identification", identification),
                Builders<Cliente>.Filter.ElemMatch(c => c.fondos, Builders<FondoCliente>.Filter.Eq("_id", id)));

                var update = Builders<Cliente>.Update.Set("Fondos.$.State", "I");

                var result = await Collection.UpdateOneAsync(filter, update);

                return result.ModifiedCount > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }


        public async Task<Boolean> UpdateCliente(string id,string nameParamaters, dynamic data)
        {

            try
            {

                var filter = Builders<Cliente>.Filter.Eq("Identification", id);
                var update = Builders<Cliente>.Update.Set(nameParamaters, data);
                var result = await Collection.UpdateOneAsync(filter, update);
                return result.ModifiedCount > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }


    }
}
