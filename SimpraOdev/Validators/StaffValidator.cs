using FluentValidation;
using SimpraOdev.Models;

namespace SimpraOdev.Validators
{
    public class StaffValidator : AbstractValidator<Staff>
    {
        public StaffValidator()
        {
            RuleFor(s => s.FirstName).NotEmpty().WithMessage("First name cannot be empty!");
            RuleFor(s => s.LastName).NotEmpty().WithMessage("Last name cannot be empty!");
            RuleFor(s => s.Email).NotEmpty().EmailAddress().WithMessage("Email cannot be empty!");
            RuleFor(s => s.Phone).NotEmpty().WithMessage("Phone cannot be empty!");
            RuleFor(s => s.DateOfBirth).NotEmpty().WithMessage("DOB  cannot be empty!");
            RuleFor(s => s.AddressLine1).NotEmpty().WithMessage("Address cannot be empty!");
            RuleFor(s => s.City).NotEmpty().WithMessage("City cannot be empty!");
            RuleFor(s => s.Country).NotEmpty().WithMessage("Country  cannot be empty!");
            RuleFor(s => s.Province).NotEmpty().WithMessage("Province cannot be empty!");
        }
    }
}
