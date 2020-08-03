using CoordParserConsole.ConsoleInterfaces;
using System;
using System.Diagnostics;

namespace CoordParserConsole
{
    class Program
    {
        public static ConsoleInterface _interface;
        public static void Main(string[] args)
        {
            if (Console.IsInputRedirected)
            {
                _interface = new RedirectInterface();
            }
            else if (args != null && args.Length > 0)
            {
                _interface = new ArgumentsInterface();
            }
            else
            {
                _interface = new SimpleInterface();
            }

            _interface.Main(args);
        }
    }
}
