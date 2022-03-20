using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserManagement.Domain.Contracts;
using UserManagement.Domain.Interfaces;
using UserManagement.Domain.Models;

namespace UserManagement.Domain.Processors
{
    public class UserProcessor : IUserProcessor
    {
        private readonly IUserCommandRepository _userCommandRepository;
        private readonly IUserQueryRepository _userQueryRepository;

        public UserProcessor(IUserCommandRepository userCommandRepository, IUserQueryRepository userQueryRepository)
        {
            _userCommandRepository = userCommandRepository;
            _userQueryRepository = userQueryRepository;
        }
        public async Task<List<User>> CreateUsers(List<User> users)
        {
            return await _userCommandRepository.CreateUsers(users);
        }
        public async Task<int> UpdateUsers(List<User> users)
        {
            return await _userCommandRepository.UpdateUsers(users);
        }

        public async Task<int> DeleteUsers(List<User> users)
        {
            return await _userCommandRepository.DeleteUsers(users);
        }

        public async Task<List<User>> GetUsers()
        {
            return await _userQueryRepository.GetAllUsers();
        }

        public TokenResult ValidateUser()
        {

            var tokenHandler = new JwtSecurityTokenHandler();

            // 2. Create Private Key to Encrypted
            var tokenKey = Encoding.ASCII.GetBytes("HellowHellowHellowHellowHellowHellow");

            //3. Create JETdescriptor
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, "Himam"),
                        new Claim("Aud","Service1")
                    }),
                
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            //4. Create Token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // 5. Return Token from method
            return new TokenResult() { Token = tokenHandler.WriteToken(token) };
        }



    }
}
