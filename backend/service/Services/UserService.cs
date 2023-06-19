using Api.Domain.Entity;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Services;
using Api.Domain.Model;
using Api.Domain.Validator;
using AutoMapper;
using System.Net;
using System.Reflection;

namespace Api.Service.User
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository;
        private IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper _mapper)
        {
            _userRepository = userRepository;
            mapper = _mapper;
        }

        public HttpResponseMessage DeleteUser()
        {
            throw new NotImplementedException();
        }

        public List<UserModel> GetUsers(string name)
        {
            var userEntity = _userRepository.GetUsers(name);
            var listUser = mapper.Map<List<UserModel>>(userEntity);
            return listUser;
        }

        public HttpResponseMessage RegisterUser(InsertUserModel userModel)
        {
            var response = new HttpResponseMessage();

            var validator = new InsertUserValidator();

            var validationResult = validator.Validate(userModel);

            if (validationResult.IsValid)
            {
                
                var userEntity = mapper.Map<UserEntity>(userModel);
                userEntity.ExperirationData = $"{userModel.MonthExpiration}/{userModel.YearExpiration}";
                _userRepository.AddUser(userEntity);

                response.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Content = new StringContent(validationResult.Errors[0].ToString());
            }

            return response;
        }

        public HttpResponseMessage UpdateUser()
        {
            throw new NotImplementedException();
        }
    }
}
