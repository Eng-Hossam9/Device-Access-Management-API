using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands.Devices
{
    public class UpdateDeviceCommand : IRequest
    {
        public Guid id { get; set; }
        public string? name { get; set; }
        public bool? isActive { get; set; }
    
    public UpdateDeviceCommand(Guid id, string name, bool? isActive)
        {
            this.id = id;
            this.name = name;
            this.isActive = isActive;
        }
        public UpdateDeviceCommand()
        {

        } 
    }
}
