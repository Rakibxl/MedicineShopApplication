using FluentValidation;
using MedicineShopApplication.BLL.ViewModel.Request;

namespace MedicineShopApplication.BLL.Validation;

public class RegisterUserRequestViewModelValidator : AbstractValidator<RegisterUserRequestViewModel>
{
    public RegisterUserRequestViewModelValidator()
    {
        RuleFor(u => u.Email)
            .NotNull()
            .NotEmpty()
            .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
            .WithMessage("Please provide a valid email address with proper format like 'example@domain.com'.");
        
        RuleFor(u => u.Password).NotNull().NotEmpty()
            .MinimumLength(5).MaximumLength(5).Matches(@"^\d{5}$")
            .WithMessage("password must be 5 character number only");

    }
    
    
}