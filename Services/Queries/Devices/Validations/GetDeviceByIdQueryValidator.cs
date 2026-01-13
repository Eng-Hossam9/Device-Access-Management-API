using FluentValidation;
using Services.Commands.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Queries.Devices.Validations
{
    public class GetDeviceByIdQueryValidator : AbstractValidator<GetDeviceByIdQuery>
    {
        public GetDeviceByIdQueryValidator() {
            RuleFor(x => x.Id)
                             .NotEmpty()
                             .WithMessage("Device Id is required");
        
    }
    }
}
