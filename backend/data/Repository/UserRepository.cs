using Api.Data.Context;
using Api.Domain.Entity;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.Domain.Repository
{
    public class UserRepository : IUserRepository
    {
        private DbSet<UserEntity> _user;
        private ApiContext _context;

        public UserRepository(ApiContext context)
        {
            _user = context.Set<UserEntity>();
            _context = context;
        }

        public Guid AddUser(UserEntity user)
        {
            _user.Add(user);
            _context.SaveChanges();
            return user.Id;

        }

        public UserEntity GetUser(Guid id)
        {
            return _user.Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public void UpdateUser(UserEntity user)
        {
            _user.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(UserEntity user) { 
            _user.Remove(user);
            _context.SaveChanges();
        }

        public List<UserEntity> GetUsers(string name)
        {
            var users = new List<UserEntity>();

            if (string.IsNullOrEmpty(name))
                users = _user.ToList();
            else
                users = _user.Where(_user => _user.Name.Contains(name)).ToList();

            return users;
        }

        public bool ExistUser(Guid id)
        {
            return _user.Any(x => x.Id == id);
        }
    }
}
