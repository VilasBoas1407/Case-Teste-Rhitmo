using Api.Domain.Model;

namespace Api.Domain.Interfaces.Services
{
    public interface IUserService
    {
        List<UserModel> GetUsers(string name);
        UserModel GetUser(Guid IdUser);
        HttpResponseMessage RegisterUser(InsertUserModel userModel);
        HttpResponseMessage UpdateUser();
        HttpResponseMessage DeleteUser(Guid IdUser);

    }
}
