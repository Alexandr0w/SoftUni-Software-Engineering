using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesExtension.IO.Interfaces;

namespace VehiclesExtension.IO
{
    public class FileWriter : IWriter
    {
        private readonly StreamWriter _writer;

        public FileWriter(string filePath)
        {
            _writer = new StreamWriter(filePath); 
        }

        public void WriteLine(string str)
        {
            _writer.WriteLine(str);
        }

        public void Close()
        {
            _writer?.Close(); 
        }
    }
}
