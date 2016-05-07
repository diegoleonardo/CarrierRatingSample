using System;
using CarrierRating.Data.Repository.Interfaces;
using CarrierRating.Data.ServiceLocator;
using CarrierRating.Domain.DTO;
using CarrierRating.Domain.Entities;
using CarrierRating.Service.Service.Base;
using CarrierRating.Service.Service.Interfaces;
using CarrierRating.Validation.UserValidation;

namespace CarrierRating.Service.Service.Services
{
    public class UserService: EntityServiceBase<User>,IUserService
    {
        private readonly IRepositoryServiceLocator _serviceLocator;
        private readonly IUserRepository _userRepository;
        private readonly IUserValidator _userValidator;
        public UserService()
        {
            _userValidator = new UserValidator();
            _serviceLocator = new RepositoryServiceLocator();
            _userRepository = _serviceLocator.GetRepositoryService<IUserRepository>();
        }

        public override void Create(User pUser)
        {
            _userValidator.Validate(pUser);
            _userRepository.Create(pUser);
        }

        public UserDTO GetByEmail(UserDTO pUser)
        {
            var user = _userRepository.GetByEmail(pUser);
            return user.GetDTO();
        }

        public bool isUserOfSystem(UserDTO pUser) {
            return _userRepository.IsUserOfSystem(pUser);
        }
    }
}
