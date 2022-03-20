using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Contracts;
using UserManagement.Domain.Models;
using UserManagement.Infrastructure.Data;
using Entity = UserManagement.Infrastructure.Entities;

namespace UserManagement.Infrastructure.Repository
{
    public class UserCommandRepository : IUserCommandRepository
    {
        private readonly UserDbContext _userDbContext;
        private readonly IMapper _mapper;

        public UserCommandRepository(UserDbContext userDbContext,IMapper mapper)
        {
            _userDbContext = userDbContext;
            _mapper = mapper;
        }
        public async Task<List<User>> CreateUsers(List<User> users)
        {
           var entities = _mapper.Map<List<Entity.User>>(users);
           await _userDbContext.Users.AddRangeAsync(entities);
           await _userDbContext.SaveChangesAsync();
           return _mapper.Map<List<User>>(entities);
        }

        public async Task<int> DeleteUsers(List<User> users)
        {
            var entities = _userDbContext.Users.Where(s=> users.Select(s=>s.Id).Contains(s.Id));
            _userDbContext.Users.RemoveRange(entities);
            int res =await _userDbContext.SaveChangesAsync();
            return res;
        }

        public async Task<int> UpdateUsers(List<User> users)
        {
            var entities = _mapper.Map<List<Entity.User>>(users);
                _userDbContext.Users.AttachRange(entities);
            int res = await _userDbContext.SaveChangesAsync();
            return res;

        }
    }
}
