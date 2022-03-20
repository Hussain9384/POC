using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserManagement.Domain.Contracts;
using UserManagement.Domain.Models;

namespace UserManagement.Domain.Handlers
{
    public class CommonHandler : IRequestHandler<GetUserWithIds, IEnumerable<User>>
    {
        private readonly IUserQueryRepository _userQueryRepository;

        public CommonHandler(IUserQueryRepository userQueryRepository)
        {
            _userQueryRepository = userQueryRepository;
        }
        public async Task<IEnumerable<User>> Handle(GetUserWithIds request, CancellationToken cancellationToken)
        {
            return await _userQueryRepository.GetAllUsers();
        }
    }
}
