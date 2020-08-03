using CoordLibrary;
using CoordLibrary.InputHandlers;
using System;
using System.Globalization;

namespace CoordParserConsole.ConsoleInterfaces
{
    abstract class ConsoleInterface
    {
        protected readonly static NumberFormatInfo standartNumberFormatInfo = new NumberFormatInfo() { NumberDecimalSeparator = "." };
        protected readonly static char[] standartCoordinatesDelimiter = new char[] { ',','\n'};

        public abstract void Main(string[] args);

        protected void OnNewPair(InputHandler handler,Coordinate coordinate)
        {
            Console.WriteLine(coordinate.ToFormatedString());
        }
    }
}
