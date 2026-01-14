using Domain.Entities;
using MediatR;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Queries
{
    public class GetAllDevicesQuery:IRequest<List<DeviceDto>>
    {

    }
}
