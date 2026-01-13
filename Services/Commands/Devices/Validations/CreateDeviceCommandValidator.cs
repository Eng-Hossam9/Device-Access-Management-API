using Services.Commands.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;


namespace Services.Validations
{
    public class CreateDeviceCommandValidator: AbstractValidator<CreateDeviceCommand>
    {
        public CreateDeviceCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Device name is required.")
                .MaximumLength(50).WithMessage("Device name cannot exceed 50 characters.");
        }
    }
}
