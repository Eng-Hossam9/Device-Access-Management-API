using Domain.Entities;
using MediatR;
using Services.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Queries.Devices.Handler
{
    public class GetDeviceByIdHandler : IRequestHandler<GetDeviceByIdQuery, Domain.Entities.Devices>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDeviceByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Domain.Entities.Devices> Handle(GetDeviceByIdQuery request, CancellationToken cancellationToken)
        {
           var  device= await _unitOfWork.Repository<Guid, Domain.Entities.Devices>().GetByIdAsync(request.Id);
    
            return device;

        }
    }
}
