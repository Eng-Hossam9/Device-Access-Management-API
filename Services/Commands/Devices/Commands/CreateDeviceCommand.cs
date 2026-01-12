using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands.Devices.Commands
{
    public class CreateDeviceCommand : IRequest<Guid>
    {
       public string Name { get; set; }
    }
}
