using System.Net;

namespace Diploma.PredictionApi.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
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
            catch (Exception ex) when (ex is ArgumentException or ArgumentNullException)
            {
                _logger.LogWarning(ex, "Client error occurred");

                await GenerateResultWithProblemAsync(
                    context,
                    StatusCodes.Status400BadRequest);
            }
            catch (Exception ex) when (ex is InvalidOperationException)
            {
                _logger.LogWarning(ex, "Client error occurred");

                await GenerateResultWithProblemAsync(
                    context,
                    StatusCodes.Status400BadRequest,
                    ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled server error");

                await GenerateResultWithProblemAsync(
                    context,
                    StatusCodes.Status500InternalServerError);
            }
        }

        private async Task GenerateResultWithProblemAsync(HttpContext context, int statusCode, string? message = null)
        {
            await Results
                .Problem(statusCode: statusCode, detail: message)
                .ExecuteAsync(context);
        }
    }
}
