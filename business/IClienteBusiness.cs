using FondoBTG.Models;

namespace FondoBTG.business
{
    public interface IClienteBusiness
    {
        Task<Response> InsertCliente(Cliente cliente);
        Task<Response> GetPrimerCliente();
        Task<Response> GetClienteById(string id);
        Task<Response> AddFondoCliente(string id, string idFondo, double valor);
        //Task<Response> DeleteFondoCliente(string identification, string id);
    }
}
