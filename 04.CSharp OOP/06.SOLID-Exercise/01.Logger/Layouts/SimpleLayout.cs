using Logging.Interfaces;

namespace Logging.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Format(ILogMessage logMessage)
            => $"{logMessage.Time} - {logMessage.ReportLevel} - {logMessage.Message}";
    }
}
