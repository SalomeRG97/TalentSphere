using Admin.Entities.Models;
using Admin.Interfaces;

namespace Admin.Repositories
{
    public class TipoContratoRepository : Repository<TiposContrato>, ITipoContratoRepository
    {
        public TipoContratoRepository(TalentSphereAdminContext context) : base(context)
        {
        }
    }
}
