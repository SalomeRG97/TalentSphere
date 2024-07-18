using Auth.Repositories.Base;
using Auth.Entities.Models;
using Auth.Interfaces.Repositories.Repositories;

namespace Auth.Repositories.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(TalentSphereAuthContext context) : base(context)
        {
        }
    }
}
