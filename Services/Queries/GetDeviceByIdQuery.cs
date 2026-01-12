using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Queries
{
    public class GetDeviceByIdQuery :IRequest<Domain.Entities.Devices>
    {
        public Guid Id { get; set; }
    }
}
