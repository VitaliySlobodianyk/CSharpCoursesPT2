using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    public delegate void Writer(string input);
    internal class ConsoleWriter
    {
        private Writer _writer;
        public ConsoleWriter() {
            _writer += WriteGreenText;
            _writer += WriteRedText;
        }

        private void WriteGreenText(string text) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private void WriteRedText(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public void Write(string text) { 
          _writer.Invoke(text);
        }
    }
}
