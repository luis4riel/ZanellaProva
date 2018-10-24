using Zanella.MF7.Dominio.Features.Users;

namespace Zanella.MF7.Aplicacao.Features.Authentication
{
    public interface IAuthenticationService
    {
        User Login(string email, string password);
    }
}
