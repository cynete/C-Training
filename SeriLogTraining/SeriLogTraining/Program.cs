using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using SerilogTraining;

namespace SeriLogTraining
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start of program");

            string LogOutputTemplate = "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}] [{Level:u4}] {@Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {Message:lj}{NewLine}{Exception}";

            //static logger
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.WithProperty("test", "enriched message")
                .Destructure.ByTransforming<LogModel>(r => new { Id = r.Id, Name = r.Name })
                .WriteTo.File("log.txt", outputTemplate: LogOutputTemplate, rollingInterval: RollingInterval.Minute, retainedFileCountLimit: 3, shared:true)
                .WriteTo.Console(outputTemplate: LogOutputTemplate)
                .CreateLogger();

            //Logger instance
            using var log2 = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .CreateLogger();

            Console.WriteLine("\nLogger1 >>>>>>>>>>>>>>>>>>>");
            Log.Information("Test information message {{{test}}} - log");
            Log.Information("Test - display object {LogModel}- log");
            Log.Information("Test - display object {LogModel}- log", new LogModel());
            Log.Information("Test - display object {Id}- log", new LogModel() { Id = 1, Name = "JP", Department = "CSE" });
            Log.Information("Test - display object {@LogModel}- log", new LogModel() { Id = 1, Name = "JP", Department = "CSE" });
            Log.Information("Test - display object {$LogModel}- log", new LogModel() { Id = 1, Name = "JP", Department = "CSE" });
            Log.Information("{DateTime}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff zzz"));
            Log.Information("current time is {@Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}");
            Log.Warning("This is warning");
            Log.Debug("This is debug");
            Log.Verbose("This is verbose");


            Console.WriteLine("\nLogger2 >>>>>>>>>>>>>>>>>>>");
            log2.Information("Test information message - log 2");

            Console.WriteLine("\nLogger3 >>>>>>>>>>>>>>>>>>>");
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.File(new CustomJsonFormatter(),  "log.json", rollingInterval: RollingInterval.Day, retainedFileCountLimit: 7, shared: true)
            .CreateLogger();

            Log.Information("This is a log message.");

            Log.CloseAndFlushAsync();
            Console.WriteLine("end of program");
        }
    }
}
