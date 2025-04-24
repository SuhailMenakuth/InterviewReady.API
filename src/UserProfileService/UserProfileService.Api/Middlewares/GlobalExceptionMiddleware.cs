

using UserProfileService.Application.Exceptions;

namespace UserProfileService.Api.Middlewares
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException ex)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await WriteErrorResponse(context, ex.Message, false);
            }
            catch (ApplicationException ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await WriteErrorResponse(context, ex.Message, false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await WriteErrorResponse(context, "An unexpected error occurred.", false);
            }
        }

        private static async Task WriteErrorResponse(HttpContext context, string message, bool success)
        {
            context.Response.ContentType = "application/json";
            var response = new
            {
                Success = success,
                Message = message
            };
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
