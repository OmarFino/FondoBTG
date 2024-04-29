using FondoBTG.Models;

namespace FondoBTG.Repositories
{
    public interface IClienteCollection
    {
        Task InsertCliente(Cliente cliente);
        Task<Cliente> GetPrimerCliente();
        Task<Cliente> GetClienteById(string id);
        Task<Boolean> AddFondoCliente(string id, FondoCliente fondoCliente);
        Task<Boolean> DeleteFondoCliente(string identification, string id);
        Task<Boolean> UpdateCliente(string id, string nameParamaters, dynamic data);
    }
}
