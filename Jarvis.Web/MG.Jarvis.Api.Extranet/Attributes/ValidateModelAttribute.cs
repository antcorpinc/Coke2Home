using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MG.Jarvis.Api.Extranet.Attributes
{
    public sealed class ValidateModelAttribute : ActionFilterAttribute
    {
        //ValidationAttributes
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = ((ControllerBase)context.Controller).BadRequest(context.ModelState);
            }
        }
    }
}
