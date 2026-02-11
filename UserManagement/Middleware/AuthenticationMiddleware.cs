namespace UserManagement.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private const string VALID_TOKEN = "my-secret-token";

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Allow Swagger UI / swagger endpoints
            if (context.Request.Path.StartsWithSegments("/swagger"))
            {
                await _next(context);
                return;
            }

            if (!context.Request.Headers.TryGetValue("Authorization", out var authHeader))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsJsonAsync(new { error = "Unauthorized. Token is missing." });
                return;
            }

            var token = authHeader.ToString();

            // Trim "Bearer " prefix if present (case-insensitive)
            if (token.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                token = token.Substring("Bearer ".Length).Trim();
            }

            // Validate token
            if (token != VALID_TOKEN)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsJsonAsync(new { error = "Unauthorized. Invalid token." });
                return;
            }

            await _next(context);
        }
    }
}
