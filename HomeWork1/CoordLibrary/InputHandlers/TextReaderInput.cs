using System;
using System.Globalization;
using System.IO;

namespace CoordLibrary.InputHandlers
{
    public class TextReaderInput : InputHandler
    {
        public TextReaderInput(NumberFormatInfo numberFormatInfo, char[] coordinateDelimiters) : base(numberFormatInfo, coordinateDelimiters)
        {
        }

        public override Coordinate[] Parse(object input)
        {
            if (!(input is TextReader)) { throw new System.Exception("Incorrect input type"); }
            TextReader tempInput = input as TextReader;
            while (tempInput.Peek() >= 0)
            {
                if (IsStop) break;
                char symbol = (char)tempInput.Read();
                ProcessInputChar(symbol);
            }
            EndInput();
            return _parser.ReceivedCoordinates;
        }
    }
}
