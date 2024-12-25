using Logging.Interfaces.Factories;
using Logging.Interfaces;
using Logging.Layouts;

namespace Logging.Factories.Layouts
{
    public class XmlLayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout() => new XmlLayout();
    }
}
