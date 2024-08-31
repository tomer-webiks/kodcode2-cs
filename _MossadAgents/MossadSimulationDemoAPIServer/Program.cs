using System.Net;
using System.Net.Sockets;
using Microsoft.AspNetCore.HttpsPolicy;
using MossadSimulationDemoAPIServer.Middlewares;
using MossadSimulationDemoAPIServer.Services;
using static System.Net.Mime.MediaTypeNames;


// Method to find an open port
static int FindOpenPort(int startingPort = 5149)
{
    int port = startingPort;
    bool isAvailable = false;

    while (!isAvailable)
    {
        try
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Any, port);
            tcpListener.Start();
            tcpListener.Stop();
            isAvailable = true;
        }
        catch (SocketException)
        {
            port++;
        }
    }

    return port;
}

var builder = WebApplication.CreateBuilder(args);

// Generic command-line argument parsing
var commandLineArgs = args
    .Where(arg => arg.Contains('='))
    .Select(arg => arg.Split('='))
    .ToDictionary(splitArg => splitArg[0].TrimStart('-'), splitArg => splitArg[1]);

if (commandLineArgs.Any())
{
    builder.Configuration.AddInMemoryCollection(commandLineArgs);
}

// Find an open port starting from 5149
int port = FindOpenPort(5149);
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.Listen(IPAddress.Any, port);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Other service configurations
builder.Services.AddSingleton<IGridService, GridService>();
builder.Services.AddSingleton<IAuthService, AuthService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

// Pre-Controllers Middlewares
if (builder.Configuration["output"] != null && !builder.Configuration["output"].Equals("grid"))
{
    app.UseMiddleware<RequestLoggerMiddleware>();
}

if (builder.Configuration["authTokenType"] != null && !((AUTH_TOKEN_TYPE)int.Parse(builder.Configuration["authTokenType"]) == AUTH_TOKEN_TYPE.NONE))
{
    app.UseMiddleware<AuthMiddleware>();
}

app.MapControllers();

// Post-Controllers Middlewares
if (builder.Configuration["output"] != null && builder.Configuration["output"].Equals("grid"))
{
    // Use Post Endpoint Middleware
    app.UseMiddleware<GridLoggerMiddleware>();
}


app.Run();
