using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProfileTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string tempStr = "c";

            while (true)
            {
                tempStr += tempStr;
                Console.WriteLine("Длина строки: {0}",tempStr.Length);
            }
        }
    }
}
