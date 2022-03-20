using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Domain.Models
{
    public class GetUserWithIds :  IRequest<IEnumerable<User>>
    {
        public List<long> UserIds { set; get; }
    }
}
