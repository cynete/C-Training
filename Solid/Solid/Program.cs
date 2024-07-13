using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace Solid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console(theme: AnsiConsoleTheme.Sixteen)
                .CreateLogger();

            Log.Information("hello");
            MenuExecutor.Execute();
        }
    }
}
