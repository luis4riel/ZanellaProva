namespace Zanella.MF7.Dominio.Features.Users
{
    public interface IUserRepository
    {
        User GetByCredentials(string email, string password);
    }
}
