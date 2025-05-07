using ContosoMcpServer.Tools;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;

namespace ContosoMcpServer;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);

        // Add MCP server services and register tools
        builder.Services.AddMcpServer().WithStdioServerTransport().WithTools<WeatherTools>();

        var app = builder.Build();

        // Start the host
        await app.RunAsync();
    }
}
