using Admin.Entities.Models;
using Admin.Interfaces;

namespace Admin.Repositories
{
    public class CargoRepository : Repository<Cargo>, ICargoRepository
    {
        public CargoRepository(TalentSphereAdminContext context) : base(context)
        {
        }
    }
}
