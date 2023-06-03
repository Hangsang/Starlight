using Serilog.Core;
using Serilog.Events;

namespace Server.Utils;

public class ContextEnricher : ILogEventEnricher
{
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        const int max = 20;
        var beginning = string.Empty;
        var empty = true;
        var val = logEvent.Properties.FirstOrDefault(x => x.Key == "SourceContext");
        if (val.Value != null)
        {
            beginning += val.Value.ToString().Replace("\"", string.Empty);
            if (beginning.Length > max - 2)
                beginning = beginning[..(max - 2)];
            empty = false;
        }

        var newx = string.Empty;
        if (beginning.Length < max)
        {
            var l = (max - beginning.Length) / 2;
            for (var i = 0; i < l; i++) newx += " ";
        }

        if (empty)
            newx = new string(' ', max - 1);
        else
            newx = newx + beginning + newx;

        if (newx.Length >= max) newx = newx[1..];

        var eventType = propertyFactory.CreateProperty("SrcContext", newx);
        logEvent.AddPropertyIfAbsent(eventType);
    }
}