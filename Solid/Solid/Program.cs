using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.SystemConsole.Themes;
using Solid.AMTSimulation;
using Solid.AMTSimulation.Interface;
using Solid.Menu_Executions;

namespace Solid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                //you can use with interface
                .AddScoped<IComscript, Comscript>()
                .AddScoped<ILogger, Logger>(x =>
                                                new LoggerConfiguration()
                                                            .MinimumLevel.Debug()
                                                            .WriteTo.Console(theme: AnsiConsoleTheme.Sixteen)
                                                            .CreateLogger()
                )
                //you can use without interface
                .AddScoped<MenuExecutor>()
                .BuildServiceProvider();
            
            while (true)
            {
                var service = serviceProvider.GetService<MenuExecutor>();
                if (!service.Execute())
                {
                    break;
                }
            }
        }
    }
}
