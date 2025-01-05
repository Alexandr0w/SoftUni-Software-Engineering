using DI.Demo.Interfaces;

namespace DI
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string message) => Console.WriteLine(message);
    }
}
