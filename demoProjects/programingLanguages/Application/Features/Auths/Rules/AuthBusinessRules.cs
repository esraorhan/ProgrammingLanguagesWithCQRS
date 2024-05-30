using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Rules
{
    public  class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EmailCanNotBeDuplicatedWhenRegistered(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user != null) throw new BusinessException("Mail Already exists");
        }
        public Task UserPasswordShouldBeMatch(User user, string password)
        {
            bool isMatched = HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);
            if (isMatched == false)
                throw new BusinessException("User password not match.");
            return Task.CompletedTask;
        }
        public Task UserShouldBeExists(User user)
        {
            if (user == null)
                throw new BusinessException("User Should be not exist.");
            return Task.CompletedTask;
        }
    }
}
