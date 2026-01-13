using Device_Access_Management_API.ExecptionHandler;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Commands.Devices;
using Services.Queries;

namespace Device_Access_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DeviceController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddDevice([FromBody] CreateDeviceCommand command)
        {
            try
            {
                var deviceId = await _mediator.Send(command);
                return Ok( new ApiResponse<object>(
                    data: new { deviceId },
                    message: "Device Added Successfuly and deviceId Info retrieved",
                    success: true
                ));
            }
            catch(Exception ex)
            {
             return StatusCode(500, new ApiResponse<object>(
             data: null,
             success: false,
             message: ex.Message));
            }
        }
        [HttpPost("GetDeviceById")]
        public async Task<IActionResult> GetDeviceById([FromBody] GetDeviceByIdQuery Query)
        {
            try
            {
                var Device = await _mediator.Send(Query);
                return Ok(new ApiResponse<object>(
                                  data: new { Device },
                                  message: "Device Info retrieved",
                                  success: true
                              ));

            }
            catch(Exception ex)
            {
                return StatusCode(500, new ApiResponse<object>(
                         data: null,
                         success: false,
                         message: ex.Message));
            }
        }
    }
}
