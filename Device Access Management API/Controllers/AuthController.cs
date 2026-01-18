using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs;
using Services.Queries.User;

namespace Device_Access_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        public AuthController(IMediator mediator ): base(mediator)
        {
        }

          [HttpPost("login")]
            public async Task<IActionResult> Login(LoginDto dto)
            {
                try
                {
                    var Token= await _Mediator.Send(new LoginUserQuery { Email = dto.Email, Password = dto.Password });
                    return Success(Token, "Login Successfully");
                }
                catch (Exception ex)
                {
                    return Fail(ex.Message);

                }
            }
        }   
    }

