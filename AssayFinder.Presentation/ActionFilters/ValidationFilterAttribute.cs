using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssayFinder.Presentation.ActionFilters
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public ValidationFilterAttribute()
        {
            
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var action = context.RouteData.Values["action"];
            var controller = context.RouteData.Values["controller"];

            var param = context.ActionArguments.SingleOrDefault(x => x.Value.ToString().Contains("DTO")).Value;

            // Check DTO is not null
            if (param is null)
            {
                context.Result = new BadRequestObjectResult($"Object is null. Controller: { controller }, action: { action }");
                return;
            }
            // Check model state is valid
            if (context.ModelState.IsValid == false)
            {
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
            }
                
        }
    }
}
