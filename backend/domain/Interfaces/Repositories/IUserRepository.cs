using Api.Domain.Model;

namespace Api.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        List<UserModel> GetUsers(string name);
    }
}
