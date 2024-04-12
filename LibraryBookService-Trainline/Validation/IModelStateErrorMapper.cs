using LibraryBookService_Trainline.Models.Response;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LibraryBookService_Trainline.Validation
{
    public interface IModelStateErrorMapper
    {
        ResponseStatus MapModelStateErrors(ModelStateDictionary modelState, ResponseStatus responseStatus);
    }
}
