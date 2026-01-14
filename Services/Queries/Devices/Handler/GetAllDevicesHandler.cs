using AutoMapper;
using MediatR;
using Services.DTOs;
using Services.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Queries.Devices.Handler
{
    public class GetAllDevicesHandler : IRequestHandler<GetAllDevicesQuery, List<DeviceDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllDevicesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<List<DeviceDto>> Handle(GetAllDevicesQuery request, CancellationToken cancellationToken)
        {
            var devices = _unitOfWork.Repository<Guid, Domain.Entities.Devices>().GetAll();

            var deviceMapped = _mapper.Map<List<DeviceDto>>(devices);

            return Task.FromResult(deviceMapped);
        }

    }
}
    