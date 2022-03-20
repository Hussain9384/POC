using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Models;

namespace UserManagement.Domain.Contracts
{
    public interface IUserQueryRepository
    {
       Task<List<User>> GetAllUsers();
    }
}
