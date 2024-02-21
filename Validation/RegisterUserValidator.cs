using FluentValidation;
using p1.DTO;

namespace p1.Validation
{
    public class RegisterUserValidator :AbstractValidator<RegisterDto>
    {
        public RegisterUserValidator()
        {
            RuleFor(x=>x.password).NotEmpty().MinimumLength(8);
            RuleFor(x=>x.rePassword).Equal(x=>x.password);
            RuleFor(x=>x.fName).NotEmpty();
            RuleFor(x=>x.userName).NotEmpty();
            
        }
    }
}
