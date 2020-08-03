using CoordLibrary.Parsers;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using static CoordLibrary.Parsers.CoordinateParser;

namespace CoordLibrary.InputHandlers
{
    public abstract class InputHandler
    {
        private int _charCounter = 0;
        private int _lineCounter = 1;
        private bool _isSkipLine = false;

        protected CoordinateParser _parser;

        public bool IsStop { get; private set; } = false;
        public Coordinate[] Coordinates => _parser.ReceivedCoordinates;

        public event Action<InputHandler,int, char> OnIgnore;
        public event Action<InputHandler,int, char> OnAccept;
        public event Action<InputHandler,int,int, char> OnIncorrect;
        public event Action<InputHandler,int> OnVeryBigDigit;
        public event Action<InputHandler,Coordinate> OnNewPair;

        public InputHandler(NumberFormatInfo numberFormatInfo, char[] coordinateDelimiters)
        {
            _parser = new CoordinateParser
            {
                Settings = new ParserSettings()
                {
                    NumberFormat = numberFormatInfo,
                    Delimiters = coordinateDelimiters
                }
            };
        }

        protected void EndInput() {
            ProcessInputChar(char.MinValue);
            _parser.Clear();
        }

        protected State ProcessInputChar(char nextChar)
        {
            if (nextChar == '\n')
            {
                _lineCounter++;
                _charCounter = 0;
            }
            else if (nextChar != '\r')
            {
                _charCounter++;
            }

            if (IsSkip(nextChar)) { return State.Ignore; }

            State result = _parser.AddSymbol(nextChar);

            switch (result)
            {
                case State.Ignore:
                    OnIgnore?.Invoke(this,_charCounter, nextChar);
                    break;
                case State.Accept:
                    OnAccept?.Invoke(this,_charCounter, nextChar);
                    break;
                case State.Incorrect:
                    OnIncorrect?.Invoke(this,_lineCounter,_charCounter, nextChar);
                    break;
                case State.VeryBigDigit:
                    OnVeryBigDigit?.Invoke(this,_lineCounter);
                    break;
                case State.PairDone:
                    OnNewPair?.Invoke(this,_parser.ReceivedCoordinates.Last());
                    break;
                default:
                    break;
            }

            return result;
        }

        public void Stop() {
            IsStop = true;
        }

        public void SkipLine() {
            _isSkipLine = true;
            _parser.Clear();
        }

        private bool IsSkip(char symb) {
            if (_isSkipLine && symb == '\n') {
                _isSkipLine = false;
                return true;
            }

            return _isSkipLine;
        }

        public abstract Coordinate[] Parse(object input);
    }
}
