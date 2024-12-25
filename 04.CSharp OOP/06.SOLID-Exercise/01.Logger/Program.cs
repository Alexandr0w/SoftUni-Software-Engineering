using Logging.Appenders;
using Logging.Enums;
using Logging.Factories.Appenders;
using Logging.Factories.Layouts;
using Logging.Interfaces;
using Logging.Interfaces.Factories;
using Logging.Layouts;
using Logging.Loggers;
using System.Globalization;

namespace Logging
{
    internal class Program
    {
        private static readonly Dictionary<string, ILayoutFactory> _layoutFactories = CreateLayoutFactories();
        private static readonly Dictionary<string, IAppenderFactory> _appenderFactories = CreateAppenderFactories();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()!);

            IAppender[] appenders = new IAppender[n];
            for (var i = 0; i < n; i++)
            {
                string[] appenderData = Console.ReadLine()!.Split();
                appenders[i] = BuildAppender(appenderData);
            }

            ILogger logger = new Logger(appenders);

            string logMessageInput = Console.ReadLine()!;
            while (logMessageInput != "END")
            {
                string[] logMessageData = logMessageInput.Split('|');

                ReportLevel reportLevel = Enum.Parse<ReportLevel>(logMessageData[0], true);
                DateTime time = DateTime.Parse(logMessageData[1], CultureInfo.InvariantCulture);
                string message = logMessageData[2];

                logger.Log(reportLevel, message, time);

                logMessageInput = Console.ReadLine()!;
            }

            Console.WriteLine("Logger info");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Appender #{i + 1} -> Messages count: {appenders[i].AppendedMessagesCount}");
            }
        }

        private static Dictionary<string, ILayoutFactory> CreateLayoutFactories()
            => new Dictionary<string, ILayoutFactory>
            {
                [nameof(SimpleLayout)] = new SimpleLayoutFactory(),
                [nameof(XmlLayout)] = new XmlLayoutFactory()
            };

        private static Dictionary<string, IAppenderFactory> CreateAppenderFactories()
            => new Dictionary<string, IAppenderFactory>
            {
                [nameof(ConsoleAppender)] = new ConsoleAppenderFactory(),
                [nameof(FileAppender)] = new FileAppenderFactory()
            };

        private static IAppender BuildAppender(string[] data)
        {
            string layoutType = data[1];
            ILayout layout = _layoutFactories[layoutType].CreateLayout();

            string appenderType = data[0];
            Func<ILogMessage, bool>? filter = null;

            if (data.Length == 3)
            {
                ReportLevel reportLevelThreshold = Enum.Parse<ReportLevel>(data[2], true);
                filter = (lm) => lm.ReportLevel >= reportLevelThreshold;
            }

            return _appenderFactories[appenderType].CreateAppender(layout, filter);
        }
    }
}