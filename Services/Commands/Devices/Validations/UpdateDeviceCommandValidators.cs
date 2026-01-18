using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands.Devices.Validations
{
    public class UpdateDeviceCommandValidators : AbstractValidator<UpdateDeviceCommand>
    {
        public UpdateDeviceCommandValidators()
        {
            RuleFor(x => x.name)
                .MaximumLength(50).WithMessage("Device name cannot exceed 50 characters.");
        }
    }
}