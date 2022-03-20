using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Contracts;
using UserManagement.Domain.Models;
using UserManagement.Infrastructure.Data;

namespace UserManagement.Infrastructure.Repository
{
    public class UserQueryRepository : IUserQueryRepository
    {
        private readonly UserDbContext _userDbContext;
        private readonly IMapper _mapper;

        public UserQueryRepository(UserDbContext userDbContext,IMapper mapper)
        {
            _userDbContext = userDbContext;
            _mapper = mapper;
        }
        public async Task<List<User>> GetAllUsers()
        {
            var users = await _userDbContext.Users.ToListAsync();
            return _mapper.Map<List<User>>(users);             
        }
    }
}
