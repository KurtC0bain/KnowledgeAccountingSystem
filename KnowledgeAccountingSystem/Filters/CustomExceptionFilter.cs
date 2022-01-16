using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace KnowledgeAccountingSystem.Filters
{
    public class CustomExceptionFilter : Attribute, IAsyncExceptionFilter
    {
        public async Task OnExceptionAsync(ExceptionContext context)
        {
            string action = context.ActionDescriptor.DisplayName;
            string callStack = context.Exception.StackTrace;
            string exceptionMessage = context.Exception.Message;
            context.Result = new ContentResult
            {
                Content = $"Calling {action} failed, because: {exceptionMessage}. Callstack: {callStack}.",
                StatusCode = 500
            };
            context.ExceptionHandled = true;
        }
    }
}
