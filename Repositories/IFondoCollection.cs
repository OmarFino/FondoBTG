using FondoBTG.Models;

namespace FondoBTG.Repositories
{
    public interface IFondoCollection
    {
        Task InsertFondo(Fondo fondo);
        Task<String> UpdateFondoAdd(string id);
        Task<String> UpdateFondoDelete(string id);
        Task<List<Fondo>> GetAllFondo();
        Task<List<Fondo>> GetAllFondoActi();
        Task<Fondo> GetFondoById(string id);
    }
}
