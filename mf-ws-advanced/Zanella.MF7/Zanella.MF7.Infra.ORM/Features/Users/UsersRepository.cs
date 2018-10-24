using System.Linq;
using System.Security.Authentication;
using Zanella.MF7.Dominio.Features.Users;
using Zanella.MF7.Infra.ORM.Contexto;

namespace Zanella.MF7.Infra.ORM.Features.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly ZanellaDbContext _context;

        public UserRepository(ZanellaDbContext context)
        {
            _context = context;
        }

        public User GetByCredentials(string email, string password)
        {
            var user = this._context.Users.FirstOrDefault(u => u.Email.Equals(email) && u.Password == password) ?? throw new InvalidCredentialException();

            return user;
        }
    }
}
