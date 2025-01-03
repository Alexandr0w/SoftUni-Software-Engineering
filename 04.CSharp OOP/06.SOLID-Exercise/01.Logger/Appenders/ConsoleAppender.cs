﻿using Logging.Enums;
using Logging.Interfaces;

namespace Logging.Appenders
{
    public class ConsoleAppender : BaseAppender
    {
        public ConsoleAppender(ILayout layout, Func<ILogMessage, bool>? filter = null)
            : base(layout, filter)
        {
        }

        protected override void Append(string formattedLogMessage)
        {
            Console.WriteLine(formattedLogMessage);
        }
    }
}
