using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Queries.User.Handler
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, string>
    {
        private readonly AuthService _userService;
        public LoginUserQueryHandler(AuthService userService)
        {
            _userService = userService;
        }
        public async Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
           return await _userService.Login(request);
        }
    }
}
