using System.Net;

namespace WebApplication2.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> logger1;
        private readonly RequestDelegate requestDelegate;

        public ExceptionHandlerMiddleware(ILogger <ExceptionHandlerMiddleware> logger1,RequestDelegate requestDelegate)
        {
            this.logger1 = logger1;
            this.requestDelegate = requestDelegate;
        }



        public async Task InvokeAsync(HttpContext context)
        {

            try
            {
                await requestDelegate(context);

            }
            catch (Exception ex)
            {
                //Log this exception
                var errorID=Guid.NewGuid();

                logger1.LogError(ex,$"{errorID} : {ex.Message}");

                context.Response.StatusCode=(int)HttpStatusCode.InternalServerError;
                context.Response.ContentType="application/json";

                var error = new
                {
                    Id = errorID,
                    Message = "we will resolve it soooooon"

                };

                await context.Response.WriteAsJsonAsync(error);

                //throw;

            }
          
        }
    }
}
