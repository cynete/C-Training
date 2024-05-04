using Newtonsoft.Json;
using Serilog.Events;
using Serilog.Formatting;

namespace SerilogTraining
{
    public class CustomJsonFormatter : ITextFormatter
    {
        public void Format(LogEvent logEvent, TextWriter output)
        {
            //var log = new
            //{
            //    Timestamp = logEvent.Timestamp,
            //    Level = logEvent.Level,
            //    Message = logEvent.RenderMessage(),
            //    Exception = logEvent.Exception?.ToString()
            //};
            //output.Write(SerializeJson(log));

            var splunkLogRecord = new SplunkLogModel()
            {

                Timestamp = logEvent.Timestamp,
                Level = logEvent.Level.ToString(),
                Message = logEvent.RenderMessage(),
                Exception = logEvent.Exception?.ToString()
            };

            output.WriteLine(SerializeJson(splunkLogRecord));
        }

        private string SerializeJson(object obj)
        {
            // Here you can use your preferred JSON serialization library
            // For simplicity, I'm using Newtonsoft.Json in this example
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }
    }

    public class SplunkLogModel
    {
        [JsonProperty(PropertyName = "@Timestamp")] public DateTimeOffset Timestamp { get; set; }
        [JsonProperty(PropertyName = "@Level")] public string Level { get; set; }
        [JsonProperty(PropertyName = "@Message")] public string Message { get; set; }
        [JsonProperty(PropertyName = "@Exception")] public string? Exception { get; set; }
    }
}