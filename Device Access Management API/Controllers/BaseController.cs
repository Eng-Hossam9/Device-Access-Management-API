using Device_Access_Management_API.ExecptionHandler;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Device_Access_Management_API.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        public readonly IMediator _Mediator;

        protected BaseController(IMediator mediator)
        {
            _Mediator = mediator;
        }

        protected IActionResult Success(object data, string message = "")
        {
            return Ok(new ApiResponse<object>(
                data: data,
                success: true,
                message: message
            ));
        }
        protected IActionResult Fail ( string message = "")
        {
            return Ok(new ApiResponse<object>(
                data: null,
                success: false,
                message: message
            ));
        }
    }

}
