using Zanella.MF7.Dominio.Features.Users;
using Zanella.MF7.Infra.Crypto;

namespace Zanella.MF7.Aplicacao.Features.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Login(string email, string password)
        {
            password = password.GenerateHash();
            return _userRepository.GetByCredentials(email, password);
        }
    }
}
