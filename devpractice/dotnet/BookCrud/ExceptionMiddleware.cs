using System.Net;
using System.Text.Json;

namespace BookCrud
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        public ExceptionMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }
        private Task HandleException(HttpContext context, Exception ex)
        {
            var response = new
            {
                Message = "custom exception",
                Detail = ex.Message
            };
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            context.Response.ContentType = "application/json";
            var json = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(json);
        }
    }
}
