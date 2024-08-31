using MossadSimulationDemoAPIServer.Services;
using System.Text.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace MossadSimulationDemoAPIServer.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public AuthMiddleware(RequestDelegate next, IAuthService authService, IConfiguration configuration)
        {
            _next = next;
            _authService = authService;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var endpoint = context.GetEndpoint();
            var requiresAuth = endpoint?.Metadata.GetMetadata<RequiresAuthAttribute>() != null;

            if (requiresAuth)
            {
                string token = null;

                // 1. Check for JWT token in the Authorization header
                if (_configuration["authTokenType"] != null && !_configuration["authTokenType"].Equals(AUTH_TOKEN_TYPE.HEADER) && context.Request.Headers.TryGetValue("Authorization", out var authHeader))
                {
                    if (authHeader.ToString().StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                    {
                        token = authHeader.ToString().Substring("Bearer ".Length).Trim();
                    }
                } else if (_configuration["authTokenType"] != null && !_configuration["authTokenType"].Equals(AUTH_TOKEN_TYPE.BODY) && context.Request.Method != HttpMethods.Get)
                {
                    if (context.Request.ContentLength > 0)
                    {
                        context.Request.EnableBuffering();

                        using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8, leaveOpen: true))
                        {
                            var body = await reader.ReadToEndAsync();
                            context.Request.Body.Position = 0; // Reset the stream position

                            if (!string.IsNullOrEmpty(body))
                            {
                                var jsonBody = JsonDocument.Parse(body);
                                if (jsonBody.RootElement.TryGetProperty("token", out var tokenElement))
                                {
                                    token = tokenElement.GetString();
                                }
                            }
                        }
                    }
                }

                // 3. Validate the token (for example, a simple JWT validation)
                if (!string.IsNullOrEmpty(token) && _authService.ValidateToken(token))
                {
                    // If token is valid, proceed to the next middleware
                    await _next(context);
                }
                else
                {
                    // If token is invalid or missing, return a 401 Unauthorized
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Unauthorized: Token is missing or invalid.");
                }
            } else
            {
                // If no attribute or the token is valid, continue processing
                await _next(context);
            }
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class RequiresAuthAttribute : Attribute
    {
        // You can add additional properties or logic if needed
    }
}
