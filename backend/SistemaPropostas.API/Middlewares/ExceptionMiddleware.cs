using System.Net;
using System.Text.Json;

namespace SistemaPropostas.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        // Construtor
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // Método principal que intercepta tudo
        public async Task Invoke(HttpContext context)
        {
            try
            {
                // deixa a requisição seguir normalmente
                await _next(context);
            }
            catch (Exception ex)
            {
                // se der erro, cai aqui
                await HandleException(context, ex);
            }
        }

        private static Task HandleException(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            // status padrão
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var response = new
            {
                erro = exception.Message
            };

            var json = JsonSerializer.Serialize(response);

            return context.Response.WriteAsync(json);
        }
    }
}