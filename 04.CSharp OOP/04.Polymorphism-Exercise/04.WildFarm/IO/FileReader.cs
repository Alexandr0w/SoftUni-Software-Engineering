using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.IO.Interfaces;

namespace WildFarm.IO
{
    public class FileReader : IReader
    {
        private StreamReader _reader;

        public FileReader(string filePath)
        {
            _reader = new StreamReader(filePath);
        }

        public string ReadLine()
        {
            return _reader.ReadLine();
        }

        public void Close()
        {
            _reader?.Close();
        }
    }
}
