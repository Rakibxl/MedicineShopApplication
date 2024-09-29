using MedicineShopApplication.BLL.BaseFormat;
using MedicineShopApplication.BLL.Validation;
using MedicineShopApplication.BLL.ViewModel.Request;
using MedicineShopApplication.DLL.Model;
using Microsoft.AspNetCore.Identity;

namespace MedicineShopApplication.BLL.Service;

public interface IAuthenticationService
{
    Task<ApiResponse<string>> RegistrationProcess(RegisterUserRequestViewModel request);
}

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AuthenticationService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ApiResponse<string>> RegistrationProcess(RegisterUserRequestViewModel request)
    {
        var validator = new RegisterUserRequestViewModelValidator();
        var result = await validator.ValidateAsync(request);


        if (!result.IsValid)
        {
            return new ApiResponse<string>(result.Errors);
        }

        var user = new ApplicationUser()
        {
            Email =  request.Email,
            UserName = request.Email
        };

        var userResult = await _userManager.CreateAsync(user, request.Password);

        if (!userResult.Succeeded)
        {
            return new ApiResponse<string>(userResult.Errors);
        }

        var roleAssign = await _userManager.AddToRoleAsync(user, "customer");

        if (!roleAssign.Succeeded)
        {
            return new ApiResponse<string>(roleAssign.Errors);
        }

        return new ApiResponse<string>("welcome to our system", true, "welcome to our system");
    }
}
