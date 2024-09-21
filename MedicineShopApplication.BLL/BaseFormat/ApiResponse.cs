using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;

namespace MedicineShopApplication.BLL.BaseFormat;

public class ApiResponse<T>
{
    public T Data { set; get; }
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public IDictionary<string, string[]> Errors { get; set; }

    public ApiResponse(T data, bool isSuccess = true, string message = "")
    {
        Data = data;
        IsSuccess = isSuccess;
        Message = message;
        Errors = null;
    }

    public ApiResponse(List<ValidationFailure> errors)
    {
        IsSuccess = false;
        Message = "validation error happened";
        Errors = errors.GroupBy(e => e.PropertyName).ToDictionary(g =>
            g.Key, g => g.Select(e => e.ErrorMessage).ToArray());
    }

    public ApiResponse(IEnumerable<IdentityError> errors)
    {
        IsSuccess = false;
        Message = "identity error happened";
        Errors = errors
            .GroupBy(e => e.Code) // Group by the 'Code' property or any other property you prefer
            .ToDictionary(
                g => g.Key, // Key of the dictionary will be the 'Code'
                g => g.Select(e => e.Description).ToArray() // Value will be an array of 'Description'
            );
    }
}