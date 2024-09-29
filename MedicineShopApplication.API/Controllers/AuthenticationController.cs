using MedicineShopApplication.BLL.Service;
using MedicineShopApplication.BLL.ViewModel.Request;
using Microsoft.AspNetCore.Mvc;

namespace MedicineShopApplication.API.Controllers;

public class AuthenticationController : ApiBaseController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserRequestViewModel request)
    {
        return ToActionResult(await _authenticationService.RegistrationProcess(request));
    }
    
}