using Domain.Entities;
using FluentValidation.Validators;
using MediatR;
using Services.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands.Devices.Handler
{
    public class UpdateDeviceHandler : IRequestHandler<UpdateDeviceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDeviceHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(UpdateDeviceCommand request, CancellationToken cancellationToken)
        {
            var device= await _unitOfWork.Repository<Guid,Domain.Entities.Devices>().GetByIdAsync(request.id);
            if (device == null)
            {
                throw new KeyNotFoundException();
            }
            if(!string.IsNullOrEmpty(request.name))
            device.Name = request.name;
            if (request.isActive.HasValue)
                device.IsActive = request.isActive.Value;

            await _unitOfWork.Commit();

            return Unit.Value;
                
         }
    }
}
