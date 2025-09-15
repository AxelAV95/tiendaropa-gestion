using FluentValidation;
using System.Net;
using System.Text.Json;

namespace TIENDAROPA.Api.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                // Intenta ejecutar el resto del pipeline
                await _next(context);
            }
            catch (Exception ex)
            {
                // Si ocurre CUALQUIER excepción, la atrapa y la maneja
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = HttpStatusCode.InternalServerError; // Por defecto, es un error 500
            object responseBody = null;

           
            // Comprueba si la excepción es de tipo ValidationException
            if (exception is ValidationException validationException)
            {
                statusCode = HttpStatusCode.BadRequest; // Si es así, el código es 400
                // Crea un objeto anónimo con los errores para serializarlo a JSON
                responseBody = validationException.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
            }
            else
            {
                // Para cualquier otra excepción, devuelve un error 500 genérico
                responseBody = new { message = "Ha ocurrido un error inesperado en el servidor." };
            }

            context.Response.ContentType = "application/json; charset=utf-8";
            context.Response.StatusCode = (int)statusCode;

            // Escribe la respuesta JSON
            return context.Response.WriteAsync(JsonSerializer.Serialize(responseBody));
        }
    }
}
