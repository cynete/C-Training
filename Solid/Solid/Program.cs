using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using Solid.AmtActions;
using Solid.Menu_Executions;

namespace Solid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console(theme: AnsiConsoleTheme.Sixteen)
                .CreateLogger();

            Log.Information("Hello, World!");


            var serviceProvider = new ServiceCollection()
                .AddScoped<IMenu, MenuExecutor>()
                .BuildServiceProvider();

            var service = serviceProvider.GetService<IMenu>();
            service.Execute();
        }
    }
}
