using Admin.Entities.Models;
using Admin.Repositories.Base;
using Admin.Interfaces.Repositories;

namespace Admin.Repositories.Repositories
{
    public class TipoContratoRepository : Repository<TiposContrato>, ITipoContratoRepository
    {
        public TipoContratoRepository(TalentSphereAdminContext context) : base(context)
        {
        }
    }
}
