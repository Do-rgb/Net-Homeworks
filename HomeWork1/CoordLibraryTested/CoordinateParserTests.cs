using CoordLibrary.Parsers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CoordLibraryTested
{
    class CoordinateParserTests
    {
        private readonly static NumberFormatInfo standartNumberFormatInfo = new NumberFormatInfo() { NumberDecimalSeparator = "." };
        private readonly static char[] standartCoordinatesDelimiter = new char[] { ',', '\n' };

        private Mock<CoordinateParser> _coordinateParserMock;

        private string _correctDigitStr = "35.23";
        private string _correctCoordinateStr;
        private string[] _incorrectCoordinates = new string[] {
            "12.34.56.78",
            "$Dsad,3434",
            "34.23,ldl",
            "999999999999999999999999999999999999999999999999999999999999999,lpasd",
            "35.23,999999999999999999999999999999999999999999999999999999999999999"
        };

        [SetUp]
        public void Setup() {
            _coordinateParserMock = new Mock<CoordinateParser>();
            _coordinateParserMock.Object.Settings = new CoordinateParser.ParserSettings() {
                Delimiters = standartCoordinatesDelimiter, 
                NumberFormat = standartNumberFormatInfo };

            _correctCoordinateStr = _correctDigitStr +","+_correctDigitStr;
        }

        [Test]
        public void AddSymbol_CorrectInput_AlwaysStateCorrect() {
            //Arrange
            var target = _coordinateParserMock.Object;
            //Act

            foreach (var digitChar in _correctCoordinateStr)
            {
                if (target.AddSymbol(digitChar) != CoordinateParser.State.Accept) {
                    Assert.Fail("Input string is not coordinate format");
                    target.Clear();
                    return;
                }
            }

            Assert.Pass();
        }

        [Test]
        public void AddSymbol_IncorrectInput_StateIncorrect() {
            //Arrange
            var target = _coordinateParserMock.Object;
            //Act
            foreach (var coordinate in _incorrectCoordinates)
            {
                bool isSkip = false;
                foreach (var coordChar in coordinate)
                {
                    if (target.AddSymbol(coordChar) != CoordinateParser.State.Accept) {
                        isSkip = true;
                        target.Clear();
                        break;
                    }
                }

                if (!isSkip) {
                    Assert.Fail("Incorrect string was parse how Correct");
                    return;
                }
            }
            var state = target.AddSymbol(char.MinValue);
            target.Clear();
            Assert.AreNotEqual(state, CoordinateParser.State.Accept);
        }

        [Test]
        public void AddSymbol_IncorrectInput_CountPairCoordinateEquals0() {
            //Arrange
            var target = _coordinateParserMock.Object;
            //Act
            foreach (var coordinate in _incorrectCoordinates)
            {
                foreach (var coordChar in coordinate)
                {
                    if (target.AddSymbol(coordChar) != CoordinateParser.State.Accept)
                    {
                        target.Clear();
                        break;
                    }
                }
                
            }
            target.AddSymbol(char.MinValue);
            target.Clear();

            Assert.IsTrue(target.ReceivedCoordinates.Length<1);
        }
    }
}
