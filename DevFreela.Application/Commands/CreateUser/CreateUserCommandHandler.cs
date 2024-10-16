﻿using DevFreela.Core.Entities;
using DevFreela.Core.Services;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly IAuthService _authService;
        public CreateUserCommandHandler(DevFreelaDbContext dbContext, IAuthService authService) 
        { 
            _dbContext = dbContext;
            _authService = authService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var project = new User(request.Username, request.Email, request.BirthDate, passwordHash, request.Role);

            await _dbContext.Users.AddAsync(project);
            await _dbContext.SaveChangesAsync();

            return project.Id;
        }
    }
}
