using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Models;

namespace UserManagement.Domain.Interfaces
{
    public interface IUserProcessor
    {
        Task<List<User>> CreateUsers(List<User> users);
        Task<int> DeleteUsers(List<User> users);
        Task<List<User>> GetUsers();
        Task<int> UpdateUsers(List<User> users);
        TokenResult ValidateUser();
    }
}
