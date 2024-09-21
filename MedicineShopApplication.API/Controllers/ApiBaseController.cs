using MedicineShopApplication.BLL.BaseFormat;
using Microsoft.AspNetCore.Mvc;

namespace MedicineShopApplication.API.Controllers;

[ApiController]
[Microsoft.AspNetCore.Components.Route("api/[controller]")]
public class ApiBaseController : ControllerBase
{
    public IActionResult ToActionResult<T>(ApiResponse<T> result)
    {
        if (!result.IsSuccess)
        {
            if (result.Errors != null)
            {
                return UnprocessableEntity(result);
            }

            return BadRequest(result);
        }

        return Ok(result);
    }
}