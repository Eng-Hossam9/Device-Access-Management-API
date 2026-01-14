using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapping
{
    public class DeviceProfile:Profile
    {
        public DeviceProfile()
        {
            CreateMap<Devices, DeviceDto>().ReverseMap();

        }

    }
}
