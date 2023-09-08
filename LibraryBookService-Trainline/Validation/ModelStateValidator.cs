using LibraryBookService_Trainline.Models.Response;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LibraryBookService_Trainline.Validation
{
    public interface IModelStateValidator
    {
        ResponseStatus MapModelStateErrors(ModelStateDictionary modelState, ResponseStatus responseStatus);
    }

    public class ModelStateValidator : IModelStateValidator
    {
        public ResponseStatus MapModelStateErrors(ModelStateDictionary modelState, ResponseStatus responseStatus)
        {
            IEnumerable<ModelError> allErrors = modelState.Values.SelectMany(v => v.Errors);
            responseStatus.Code = -101;
            responseStatus.Message = string.Join(", ", allErrors.Select(x => x.ErrorMessage));

            return responseStatus;
        }
    }
}
