using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using Zanella.MF7.WebAPI.Exceptions;

namespace Zanella.MF7.WebAPI.Extensions
{
    public static class ExceptionHandlingExtensions
    {
        public static HttpResponseMessage HandleExecutedContextException(this HttpActionExecutedContext context)
        {
            return context.Request.CreateResponse(HttpStatusCode.InternalServerError, ExceptionPayload.New(context.Exception));
        }
    }
}