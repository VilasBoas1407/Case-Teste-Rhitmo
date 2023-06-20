using Api.Domain.Model;

namespace Api.Domain.Interfaces.Services
{
    public interface IUserService
    {
        List<UserModel> GetUsers(string name);
        UserModel GetUser(Guid IdUser);
        HttpResponseMessage RegisterUser(InsertUserModel userModel);
        HttpResponseMessage UpdateUser(UpdateUserModel userModel);
        HttpResponseMessage DeleteUser(Guid IdUser);

    }
}
