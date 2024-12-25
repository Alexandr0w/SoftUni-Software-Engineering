using Logging.Interfaces;

namespace Logging.Interfaces.Factories
{
    public interface ILayoutFactory
    {
        ILayout CreateLayout();
    }
}
