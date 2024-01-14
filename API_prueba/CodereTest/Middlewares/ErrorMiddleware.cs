using ISF.FAF_RF.Domain.Common;

namespace CodereTest.API.Middleware
{
    public class ErrorMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorMiddleware> _logger;

        public ErrorMiddleware(RequestDelegate next, ILogger<ErrorMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (AppException ex)
            {
                var message = $"Application error: {ex.Error.Code} - {ex.Error.Message}";
                await GenerateLogAndSendResponse(context, StatusCodes.Status400BadRequest, ex, ex.Error, message);
            }
            catch (Exception ex)
            {
                var message = $"Unhandle Exception: {ex.Message}";
                await GenerateLogAndSendResponse(context, StatusCodes.Status500InternalServerError, ex, CustomError.UnhandledError, message);
            }
        }

        private async Task GenerateLogAndSendResponse(HttpContext context, int status, Exception ex, CustomError error, string message)
        {
            string? path = context.Request.Path.ToString();
            _logger.LogError(new Exception($" {message}\n request path: {path}", ex), "");
            context.Response.StatusCode = status;
            await context.Response.WriteAsJsonAsync(error);
        }
    }
}
