﻿using System.Threading;
using System.Threading.Tasks;
using FilmsManagement.Domain.Models;

namespace FilmsManagement.DomainServices.Core
{
    public interface IUserDomainService
    {
        Task<User> GetUserByIdAsync(string userId, CancellationToken cancellationToken);
    }
}
