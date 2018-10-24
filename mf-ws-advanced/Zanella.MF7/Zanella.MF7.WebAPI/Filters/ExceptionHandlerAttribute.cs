using System.Web.Http.Filters;
using Zanella.MF7.WebAPI.Extensions;

namespace Zanella.MF7.WebAPI.Filters
{
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            context.Response = context.HandleExecutedContextException();
        }
    }
}