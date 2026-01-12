using Domain.Entities;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Devices;
using MediatR;
using Services.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands.Devices.Commands.Handler
{
    public class CreateDeviceHandler: IRequestHandler<CreateDeviceCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateDeviceHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateDeviceCommand request,CancellationToken cancellationToken)
        {
            var device = new Domain.Entities.Devices(request.Name);
            await _unitOfWork.Repository<Guid,Domain.Entities.Devices>().AddAsync(device);
            await _unitOfWork.Commit();
            return device.Id;
        }
    }

}
