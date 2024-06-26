﻿using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.Login
{
    public  class LoginCommand :IRequest<LoginDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }
        public string IpAddress { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IAuthService _authService;
            private readonly AuthBusinessRules _authBusinessRules;

            public LoginCommandHandler(IUserRepository userRepository, IAuthService authService, AuthBusinessRules authBusinessRules)
            {
                _userRepository = userRepository;
                _authService = authService;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<LoginDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                User? loginUser = await _userRepository.GetAsync(x => x.Email == request.UserForLoginDto.Email);
                await _authBusinessRules.UserShouldBeExists(loginUser);

                await _authBusinessRules.UserPasswordShouldBeMatch(loginUser, request.UserForLoginDto.Password);
                AccessToken createdAccessToken = await _authService.CreateAccessToken(loginUser);
                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(loginUser, request.IpAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

                LoginDto loginDto = new()
                {
                    RefreshToken = addedRefreshToken,
                    AccessToken = createdAccessToken,
                };
                return loginDto;
            }
        }
    }
}
