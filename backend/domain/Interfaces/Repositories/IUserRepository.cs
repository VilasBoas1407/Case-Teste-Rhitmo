using Api.Domain.Entity;
using Api.Domain.Model;

namespace Api.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        List<UserEntity> GetUsers(string name);
        void AddUser(UserEntity user);
    }
}
