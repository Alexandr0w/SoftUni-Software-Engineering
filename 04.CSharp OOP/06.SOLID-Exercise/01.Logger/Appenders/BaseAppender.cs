using Logging.Enums;
using Logging.Interfaces;

namespace Logging.Appenders
{
    public abstract class BaseAppender : IAppender
    {
        private readonly ILayout _layout;
        private readonly Func<ILogMessage, bool>? _filter;
        private ILayout layout;
        private Func<string, ReportLevel, string, bool>? filter;

        protected BaseAppender(ILayout layout, Func<ILogMessage, bool>? filter = null)
        {
            this._layout = layout;
            this._filter = filter;
        }

        protected BaseAppender(ILayout layout, Func<string, ReportLevel, string, bool>? filter)
        {
            this.layout = layout;
            this.filter = filter;
        }

        public int AppendedMessagesCount { get; private set; }

        public void Append(ILogMessage logMessage)
        {
            if (this._filter is not null && !this._filter(logMessage)) return;

            var formattedLogMessage = this._layout.Format(logMessage);

            this.Append(formattedLogMessage);

            this.AppendedMessagesCount++;
        }

        protected abstract void Append(string formattedLogMessage);
    }
}
