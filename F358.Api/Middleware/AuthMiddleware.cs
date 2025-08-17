using Microsoft.AspNetCore.Authentication;

namespace F358.Api.Middleware;

internal class AuthMiddleware : IMiddleware
{
    public Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var x = context.Request.HttpContext.Request.Headers["Debug user"];


        return next.Invoke(context);
    }
}