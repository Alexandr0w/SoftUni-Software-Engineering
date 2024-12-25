using Logging.Appenders;
using Logging.Interfaces;
using Logging.Interfaces.Factories;

namespace Logging.Factories.Appenders
{
    public class ConsoleAppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(ILayout layout, Func<ILogMessage, bool>? filter = null)
            => new ConsoleAppender(layout, filter);
    }
}
