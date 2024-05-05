using Newtonsoft.Json;
using Serilog.Events;
using Serilog.Formatting;

namespace SerilogTraining
{
    public class CustomJsonFormatter : ITextFormatter
    {
        public void Format(LogEvent logEvent, TextWriter output)
        {
            var splunkLogRecord = new SplunkLogModel()
            {

                Timestamp = logEvent.Timestamp,
                Level = logEvent.Level.ToString(),
                Message = logEvent.RenderMessage(),
                ExceptionMessage = logEvent.Exception?.Message??"",
                ExceptionSource = logEvent.Exception?.Source??"",
                ExceptionStackTrace = logEvent.Exception?.StackTrace ?? "",
                ExceptionInnerException = logEvent.Exception?.InnerException?.ToString()??"",
            };

            output.WriteLine(JsonConvert.SerializeObject(splunkLogRecord));
        }
    }

    public class SplunkLogModel
    {
        [JsonProperty(PropertyName = "@Timestamp")] public DateTimeOffset Timestamp { get; set; }
        [JsonProperty(PropertyName = "@Level")] public string Level { get; set; }
        [JsonProperty(PropertyName = "@Message")] public string Message { get; set; }
        [JsonProperty(PropertyName = "@ExceptionMessage")] public string? ExceptionMessage { get; set; }
        [JsonProperty(PropertyName = "@ExceptionSource")] public string? ExceptionSource { get; set; }
        [JsonProperty(PropertyName = "@ExceptionStackTrace")] public string? ExceptionStackTrace { get; set; }
        [JsonProperty(PropertyName = "@ExceptionInnerException")] public string? ExceptionInnerException { get; set; }
    }
}