using Serilog;
using Serilog.Events;
using SerilogTraining;

namespace SeriLogTraining
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start of program");

            string LogOutputTemplate = "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}] [{Level:u4}] {Message:lj}{NewLine}{Exception}";

            //static logger
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()

                .Enrich.WithProperty("test", "enriched message")
                .Destructure.ByTransforming<LogModel>(r => new { Id = r.Id, Name = r.Name })
                .WriteTo.File("log.txt", outputTemplate: LogOutputTemplate, rollingInterval: RollingInterval.Minute, retainedFileCountLimit: 3, shared: true)
                .WriteTo.Console(outputTemplate: LogOutputTemplate)
                .CreateLogger();

            //Logger instance
            using var log2 = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .CreateLogger();

            Console.WriteLine("\nLogger1 >>>>>>>>>>>>>>>>>>>");
            Log.Information("Tes1t information message {test} - log");
            Log.Information("Test2 - display object {LogModel} - log");
            Log.Information("Test3 - display object {LogModel} - log", new LogModel());
            Log.Information("Test4 - display object {Id} - log", (new LogModel() { Id = 1, Name = "JP", Department = "CSE" }).Id);
            Log.Information("Test5 - display object {@LogModel} - log", new LogModel() { Id = 1, Name = "JP", Department = "CSE" });
            Log.Information("Test6 - display object {$LogModel} - log", new LogModel() { Id = 1, Name = "JP", Department = "CSE" });
            Log.Information("{DateTime}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff zzz"));
            Log.Information("current time is {@Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}");
            Log.Warning("This is warning");
            Log.Debug("This is debug");
            Log.Verbose("This is verbose");


            Console.WriteLine("\nLogger2 >>>>>>>>>>>>>>>>>>>");
            log2.Information("Test information message - log 2");

            Console.WriteLine("\nLogger3 >>>>>>>>>>>>>>>>>>>");
            string ConsoleLogOutputTemplate = "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}] [{Level:u4}] {Message:lj}{NewLine}{Exception}";
            bool LogToSplunk = true;

            LoggerConfiguration loggerConfiguration = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            //.WriteTo.Console(new CustomJsonFormatter(), restrictedToMinimumLevel: LogEventLevel.Verbose);
            .WriteTo.Console(outputTemplate: ConsoleLogOutputTemplate, restrictedToMinimumLevel: LogEventLevel.Information);

            if (LogToSplunk)
                loggerConfiguration.WriteTo.File(new CustomJsonFormatter(), "log.json",
                                                rollingInterval: RollingInterval.Day,
                                                retainedFileCountLimit: 7,
                                                shared: true);

            Log.Logger = loggerConfiguration.CreateLogger();

            Log.Debug("Debug message 1");
            Log.Verbose("Verbose message 1");
            Log.Information("Information message 1 >> RequestID = {RequestID}", 1234);
            Log.Information("Information message 2");
            Log.Verbose("Verbose message 2");
            Log.Debug("Debug message 2");

            try { throw new ArgumentException("Hello"); }
            catch (Exception e) { Log.Error(e, "Exception caught"); }


            Log.CloseAndFlushAsync();
            log2.Dispose();
            Console.WriteLine("end of program");
        }
    }
}
