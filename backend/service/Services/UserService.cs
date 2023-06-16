using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Services;
using Api.Domain.Model;

namespace Api.Service.User
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        public List<UserModel> GetUsers(string name)
        {
            return _userRepository.GetUsers(name);
        }
    }
}
