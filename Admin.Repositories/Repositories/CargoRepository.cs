using Admin.Entities.Models;
using Admin.Repositories.Base;
using Admin.Interfaces.Repositories;

namespace Admin.Repositories.Repositories
{
    public class CargoRepository : Repository<Cargo>, ICargoRepository
    {
        public CargoRepository(TalentSphereAdminContext context) : base(context)
        {
        }
    }
}
