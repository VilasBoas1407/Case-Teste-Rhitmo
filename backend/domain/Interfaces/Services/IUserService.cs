using Api.Domain.Model;

namespace Api.Domain.Interfaces.Services
{
    public interface IUserService
    {
        List<UserModel> GetUsers(string name);
    }
}
