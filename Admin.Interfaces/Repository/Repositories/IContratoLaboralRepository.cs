using Admin.Entities.Models;
using Admin.Interfaces.Repositories.Base;


namespace Admin.Interfaces.Repositories
{
   public interface IContratoLaboralRepository : IRepository<ContratosLaborale>
    {
        Task<ContratosLaborale> GetByDocument(string numeroDocumento);
    }
}
