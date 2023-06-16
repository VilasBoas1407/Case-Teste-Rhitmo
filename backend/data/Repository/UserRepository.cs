using Api.Data.Context;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.Domain.Repository
{
    public class UserRepository : IUserRepository
    {
        private DbSet<UserModel> _user;

        public UserRepository(ApiContext context)
        {
            _user = context.User;
            var users = new List<UserModel>() { new UserModel(){
                Id =new Guid(),
                Name = "Lucas Vilas Boas",
                Cpf = "123.456.789-09",
                Email = "test@email.com"
            } };
            _user.AddRange(users);
            context.SaveChanges();

        }

        public List<UserModel> GetUsers(string name)
        {
            var users = new List<UserModel>();

            if (string.IsNullOrEmpty(name))
                users = _user.ToList();
            else
                users = _user.Where(_user => _user.Name.Contains(name)).ToList();

            return users;
        }
    }
}
