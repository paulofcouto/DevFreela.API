﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DevFreela.API.Filters
{
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var messages = context.ModelState
                    .SelectMany(t => t.Value.Errors)
                    .Select(s => s.ErrorMessage)
                    .ToList();

                context.Result = new BadRequestObjectResult(messages);
            }
        }
    }
}
