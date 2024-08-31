using System.Text.Json;
using System.Text;

namespace MossadSimulationDemoAPIServer.Middlewares
{
    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private static readonly object consoleLock = new object();

        public RequestLoggerMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Log the HTTP method and path
            var method = context.Request.Method;
            var path = context.Request.Path;

            // Log the body for POST and PUT requests
            if (context.Request.ContentLength > 0 && (method == HttpMethods.Post || method == HttpMethods.Put))
            {
                context.Request.EnableBuffering(); // Enable buffering to allow reading the body multiple times

                using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8, leaveOpen: true))
                {
                    var body = await reader.ReadToEndAsync();
                    context.Request.Body.Position = 0; // Reset the stream position so the body can be read by the next middleware

                    lock (consoleLock)
                    {
                        if (_configuration["requestLogger"] != null && _configuration["requestLogger"].Equals("detail"))
                        {
                            Console.WriteLine($"- {method.PadRight(5)} {path}");

                            // Log the headers
                            Console.WriteLine("\tHeaders:");
                            foreach (var header in context.Request.Headers)
                            {
                                Console.WriteLine($"\t\t{header.Key}: {header.Value}");
                            }

                            if (!string.IsNullOrEmpty(body))
                            {
                                Console.WriteLine("\tBody:");
                                Console.WriteLine("\t\t" + JsonSerializer.Serialize(JsonDocument.Parse(body).RootElement, new JsonSerializerOptions { WriteIndented = false }));
                            }
                        } else if (_configuration["requestLogger"] != null && _configuration["requestLogger"].Equals("brief"))
                        {
                            Console.Write($"- {method.PadRight(5)} {path}");
                            if (!string.IsNullOrEmpty(body))
                            {
                                Console.WriteLine("\t-- " + JsonSerializer.Serialize(JsonDocument.Parse(body).RootElement, new JsonSerializerOptions { WriteIndented = false }));
                            } else
                            {
                                Console.WriteLine();
                            }
                        }
                    }
                }
            } else
            {
                lock (consoleLock)
                {
                    Console.WriteLine($"- {method} {path}");

                    if (_configuration["requestLogger"] != null && _configuration["requestLogger"].Equals("detail"))
                    {
                        // Log the headers
                        Console.WriteLine("\tHeaders:");
                        foreach (var header in context.Request.Headers)
                        {
                            Console.WriteLine($"\t\t{header.Key}: {header.Value}");
                        }
                    }
                }
            }

            // Call the next middleware in the pipeline
            await _next(context);
        }
    }
}
