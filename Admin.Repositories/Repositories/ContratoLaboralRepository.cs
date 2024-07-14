using Admin.Entities.Models;
using Admin.Repositories.Base;
using Admin.Interfaces.Repositories;

namespace Admin.Repositories.Repositories
{
    public class ContratoLaboralRepository : Repository<ContratosLaborale>, IContratoLaboralRepository
    {
        public ContratoLaboralRepository(TalentSphereAdminContext context) : base(context)
        {
        }
    }
}