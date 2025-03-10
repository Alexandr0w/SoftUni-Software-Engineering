﻿using Logging.Appenders;
using Logging.Interfaces;
using Logging.Interfaces.Factories;

namespace Logging.Factories.Appenders
{
    public class FileAppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(ILayout layout, Func<ILogMessage, bool>? filter = null)
            => new FileAppender("../../../logs.txt", layout, filter);
    }
}
