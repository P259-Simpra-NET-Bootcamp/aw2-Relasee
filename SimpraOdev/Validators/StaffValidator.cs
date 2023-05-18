using FluentValidation;
using SimpraOdev.Models;

namespace SimpraOdev.Validators
{
    public class StaffValidator : AbstractValidator<Staff>
    {
        public StaffValidator()
        {
            RuleFor(s => s.FirstName).NotEmpty();
            RuleFor(s => s.LastName).NotEmpty();
            RuleFor(s => s.Email).NotEmpty().EmailAddress();
            RuleFor(s => s.Phone).NotEmpty();
            RuleFor(s => s.DateOfBirth).NotEmpty();
            RuleFor(s => s.AddressLine1).NotEmpty();
            RuleFor(s => s.City).NotEmpty();
            RuleFor(s => s.Country).NotEmpty();
            RuleFor(s => s.Province).NotEmpty();
        }
    }
}
