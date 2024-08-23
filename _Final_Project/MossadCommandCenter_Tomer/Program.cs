using MossadCommandCenter_Tomer.Services;

var builder = WebApplication.CreateBuilder(args);
var baseUrl = builder.Configuration["apiServer"] ?? "https://default-api-endpoint.com";

// Register HttpClient and AgentService
builder.Services.AddHttpClient<AgentService>(client =>
{
    client.BaseAddress = new Uri(baseUrl);
});

var app = builder.Build();

// Start AgentService
var agentService = app.Services.GetRequiredService<AgentService>();
agentService.Start();

app.Run();
