using System;
using CarrierRating.Domain.Entities;
using CarrierRating.Data.Repository.Interfaces;
using CarrierRating.Data.ServiceLocator;
using System.Collections.Generic;

namespace CarrierRating.Validation.UserValidation
{
    public class UserValidator : IUserValidator
    {
        private readonly IUserRepository _userRepository;
        public UserValidator()
        {
            var repositoryServiceLocator = new RepositoryServiceLocator();
            _userRepository = repositoryServiceLocator.GetRepositoryService<IUserRepository>();
        }

        public void Validate(User entity)
        {
            var validationResults = new List<ValidationResult>();
            if (IsUserInSystem(entity))
                validationResults.Add(new ValidationResult("User", "user is already added to account"));
            if (IsUserAddedInEntityCollection(entity))
                validationResults.Add(new ValidationResult("User", "user is already added to account"));

            if (validationResults.Count > 0)
                throw new ValidationException(validationResults);
        }

        public bool IsUserInSystem(User entity)
        {
            return _userRepository.GetByEmail(entity) != null;
        }

        public bool IsUserAddedInEntityCollection(User entity)
        {
            return _userRepository.IsUserOfSystem(entity);
        }
    }
}
