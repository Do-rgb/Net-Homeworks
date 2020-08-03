using System.Globalization;

namespace CoordLibrary.InputHandlers
{
    public class StringInput : InputHandler
    {
        public StringInput(NumberFormatInfo numberFormatInfo, char[] coordinateDelimiters) : base(numberFormatInfo, coordinateDelimiters)
        {
        }

        public override Coordinate[] Parse(object input)
        {
            if (!(input is string)) { throw new System.Exception("Incorrect input type"); }

            string tempInput = input as string;

            foreach (var inputChar in tempInput)
            {
                if (IsStop) break;
                ProcessInputChar(inputChar);
            }
            EndInput();

            return _parser.ReceivedCoordinates;
        }
    }
}
