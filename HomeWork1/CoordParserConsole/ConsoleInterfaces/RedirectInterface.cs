using CoordLibrary;
using CoordLibrary.InputHandlers;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace CoordParserConsole.ConsoleInterfaces
{
    class RedirectInterface : ConsoleInterface
    {
        private InputHandler _handler;

        public RedirectInterface()
        {
            _handler = new TextReaderInput(standartNumberFormatInfo, standartCoordinatesDelimiter);
            _handler.OnNewPair += OnNewPair;
            _handler.OnIncorrect += _handler_OnIncorrect;
            _handler.OnVeryBigDigit += _handler_OnVeryBigDigit;
        }

        private void _handler_OnVeryBigDigit(InputHandler handler,int line)
        {
            Console.WriteLine("[ERROR] Line {0}. The number is too large.", line);
            handler.Stop();
        }

        private void _handler_OnIncorrect(InputHandler handler, int line,int position, char symbol)
        {
            Console.WriteLine("[ERROR] Line {0}. Position {1}. Invalid character \"{2}\".", line,position,symbol);
            handler.Stop();
        }

        public override void Main(string[] args)
        {
            _handler.Parse(Console.In);
        }
    }
}
