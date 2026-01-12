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
            var deviceId = await _mediator.Send(command);
            return Ok(deviceId);
        }
        [HttpPost("GetDeviceById")]
        public async Task<IActionResult> GetDeviceById([FromBody] GetDeviceByIdQuery Query)
        {
            var Device = await _mediator.Send(Query);
            return Ok(Device);
        }
    }
}
