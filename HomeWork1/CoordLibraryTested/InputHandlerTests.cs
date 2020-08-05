using CoordLibrary.InputHandlers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CoordLibraryTested
{
    class InputHandlerTests
    {
        private readonly static NumberFormatInfo standartNumberFormatInfo = new NumberFormatInfo() { NumberDecimalSeparator = "." };
        private readonly static char[] standartCoordinatesDelimiter = new char[] { ',', '\n' };

        private Mock<InputHandler> _inputMock;

        private string _correctDigitStr = "12.34";
        private decimal _correctDigit = 12.34M;
        private string _correctCoordinates;
        private string _incorrectCoordinates = "123123.sad,213\n";

        [SetUp]
        public void Setup() {
            _inputMock = new Mock<InputHandler>(standartNumberFormatInfo, standartCoordinatesDelimiter);
            _inputMock.Setup(_ => _.Parse(It.IsAny<object>())).Returns((object obj) =>
            {
                var handler = new StringInput(standartNumberFormatInfo,standartCoordinatesDelimiter);
                handler.OnIncorrect += Handler_OnIncorrect;
                handler.OnVeryBigDigit += Handler_OnVeryBigDigit;
                return handler.Parse(obj);
            });

            _correctCoordinates = _correctDigitStr+","+_correctDigitStr;
        }

        private void Handler_OnVeryBigDigit(InputHandler handler, int arg2)
        {
            handler.Stop();
        }

        private void Handler_OnIncorrect(InputHandler handler, int arg2, int arg3, char arg4)
        {
            handler.Stop();
        }

        [Test]
        public void Parse_CorrectInput_CoordinateArray() {
            //Arrange
            var target = _inputMock.Object;
            //Act
            var result = target.Parse(_correctCoordinates);
            //Assert
            Assert.AreEqual(result.Length,1);
            Assert.AreEqual(result[0].X, _correctDigit);
            Assert.AreEqual(result[0].Y, _correctDigit);
        }

        [Test]
        public void Parse_InCorrectInput_EmptyCoordinateArray() {
            //Arrange
            var target = _inputMock.Object;
            //Act
            var result = target.Parse(_incorrectCoordinates);
            //Assert
            Assert.AreEqual(result.Length,0);
        }
    }
}
