using Api.Domain.Entity;

namespace Api.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        List<UserEntity> GetUsers(string name);
        UserEntity GetUser(Guid id);
        void UpdateUser(UserEntity user);
        void DeleteUser(UserEntity user);
        Guid AddUser(UserEntity user);
    }
}
