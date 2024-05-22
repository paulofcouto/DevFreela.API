﻿using MediatR;

namespace DevFreela.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
