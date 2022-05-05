using System;
using System.Threading;
using System.Threading.Tasks;
using FilmsManagement.Domain.Models;
using FilmsManagement.DomainServices.Core;
using FilmsManagement.Infrastructure.Core.Exceptions;
using FilmsManagement.Infrastructure.Core.Repositories;

namespace FilmsManagement.DomainServices
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUserRepository _userRepository;

        public UserDomainService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> GetUserByIdAsync(string userId, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(userId, out var userGuid))
            {
                throw new ArgumentException("Incorrect user id passed");
            }

            var user = _userRepository.GetUserByIdAsync(userGuid, cancellationToken) 
                ?? throw new UserNotFoundException();

            return user;
        }

        public Task<User> GetUserByMailAsync(string userMail, CancellationToken cancellationToken)
        {
            return _userRepository.GetUserByMailAsync(userMail, cancellationToken)
                ?? throw new UserNotFoundException($"User with email {userMail} was not found");
        }
    }
}
