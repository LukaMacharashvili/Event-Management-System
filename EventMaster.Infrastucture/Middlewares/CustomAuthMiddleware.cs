using System.Net;
using System.Security.Claims;
using EventMaster.Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace EventMaster.Infrastructure.Middlewares;

public class CustomAuthMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IAuthProvider _authProvider;

    public CustomAuthMiddleware(RequestDelegate next,
        IAuthProvider authProvider)
    {
        _next = next;
        _authProvider = authProvider;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        string? authHeader = context.Request?.Headers?.Authorization;
        if (authHeader != null && authHeader.StartsWith("Bearer"))
        {
            string token = authHeader.Substring("Bearer ".Length).Trim();

            try
            {
                var id = await _authProvider.ValidateToken(token);
                if (id is null or "")
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    return;
                }

                context.User.AddIdentity(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, id),
                }));
            }
            catch
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return;
            }
        }

        await _next(context);
    }
}