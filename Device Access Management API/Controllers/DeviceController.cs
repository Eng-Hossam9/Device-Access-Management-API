using Device_Access_Management_API.ExecptionHandler;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Commands.Devices;
using Services.Queries;

namespace Device_Access_Management_API.Controllers
{
    [Authorize]

    [Route("api/[controller]")]
    public class DeviceController : BaseController
    {

        public DeviceController(IMediator mediator):base(mediator)
        {
        }
        [HttpPost("AddNewDevice")]
        public async Task<IActionResult> AddDevice([FromBody] CreateDeviceCommand command)
        {
            try
            {

                var deviceId = await _Mediator.Send(command);
                return Success(new { deviceId }, "Device Added Successfully");

            }
            catch (Exception ex)
            {
                return Fail(ex.Message);

            }
        }

        [HttpPost("GetDeviceById")]
        public async Task<IActionResult> GetDeviceById([FromBody] GetDeviceByIdQuery Query)
        {
            try
            {
                var Device = await _Mediator.Send(Query);
                return Success(new { Device }, "Device Added Successfully");


            }
            catch (Exception ex)
            {
                return Fail(ex.Message);

            }
        }

        [HttpGet("GetAllDevices")]
        public async Task<IActionResult> GetAllDevices()
        {
            try
            {
                var Device = await _Mediator.Send(new GetAllDevicesQuery());
          
                return Success(new { Device }, "Devices retrieved");

            }
            catch (Exception ex)
            {
                return Fail(ex.Message);

            }
        }

        [HttpPost("UpdateDevice")]
        public async Task<IActionResult> UpdateDevice([FromBody] UpdateDeviceCommand command)
        {
            try
            {
                var Device = await _Mediator.Send(command);

                return Success(new { Device }, "Device Updated Successfuly");
                
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);

            }
        }
    }
}
