﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FilmsManagement.Domain.Models;
using FilmsManagement.DomainServices.Core;
using FilmsManagement.Infrastructure.Core.Repositories;

namespace FilmsManagement.DomainServices
{
    public class UserWatchListDomainService : IUserWatchListDomainService
    {
        private readonly IMovieDomainService _movieDomainService;
        private readonly IUserDomainService _userDomainService;
        private readonly IUserWatchListRepository _userWatchListRepository;

        public UserWatchListDomainService(
            IMovieDomainService movieDomainService
            , IUserDomainService userDomainService
            , IUserWatchListRepository userWatchListRepository
        )
        {
            _movieDomainService = movieDomainService;
            _userDomainService = userDomainService;
            _userWatchListRepository = userWatchListRepository;
        }

        public async Task AddMovieToUserWatchList(string userId, string movieId, CancellationToken cancellationToken)
        {
            var user = await _userDomainService.GetUserByIdAsync(userId, cancellationToken);
            var movie = await _movieDomainService.GetMovieById(movieId, cancellationToken);

            await _userWatchListRepository.AddUserWatchListMovieAsync(user, movie, cancellationToken);
            await _userWatchListRepository.SaveChangesAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<UserWatchListMovie>> GetUserWatchListAsync(string userId, CancellationToken cancellationToken)
        {
            var user = await _userDomainService.GetUserByIdAsync(userId, cancellationToken);

            return await _userWatchListRepository.GetUserWatchListAsync(user, cancellationToken);
        }

        public async Task MarkMovieInWatchListAsync(string userId, string movieId, CancellationToken cancellationToken)
        {
            var user = await _userDomainService.GetUserByIdAsync(userId, cancellationToken);
            var movie = await _movieDomainService.GetMovieById(movieId, cancellationToken);

            await _userWatchListRepository.MarkMovieWatchedAsync(user, movie, cancellationToken);
            await _userWatchListRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
