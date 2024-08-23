using System.Net;
using System.Net.Sockets;

// Method to find an open port
static int FindOpenPort(int startingPort = 5000)
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

// Find an open port starting from 5000
int port = FindOpenPort(5000);
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.Listen(IPAddress.Any, port);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
