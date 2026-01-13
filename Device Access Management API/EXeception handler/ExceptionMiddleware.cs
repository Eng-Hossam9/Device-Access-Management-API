using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Device_Access_Management_API.ExecptionHandler
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException ex)
            {
                await WriteError(context, ex.Message, HttpStatusCode.NotFound);
            }
            catch (BadRequestException ex)
            {
                await WriteError(context, ex.Message, HttpStatusCode.BadRequest);
            }
            catch (TimeoutException)
            {
                await WriteError(
                    context,
                    "Operation timeout",
                    HttpStatusCode.RequestTimeout);
            }
            catch (Exception)
            {
                await WriteError(
                    context,
                    "Unexpected server error",
                    HttpStatusCode.InternalServerError);
            }
        }

        private static async Task WriteError(
            HttpContext context,
            string message,
            HttpStatusCode statusCode)
        {
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";

            var response = new ApiResponse<object>(
                data: null,
                success: false,
                message: message
            );

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(response));
        }
    }


}
