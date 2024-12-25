using Logging.Enums;

namespace Logging.Interfaces
{
    public interface ILogMessage
    {
        ReportLevel ReportLevel { get; }
        string Message { get; }
        DateTime Time { get; }
    }
}
