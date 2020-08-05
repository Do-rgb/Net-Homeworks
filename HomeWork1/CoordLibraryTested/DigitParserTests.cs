using CoordLibrary.Parsers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoordLibraryTested
{
    class DigitParserTests
    {
        private Mock<DigitParser> _digitParserMock;
        private decimal _correctDigit = 35.23M;
        private string _correctDigitStr;
        private string _veryBigDigitStr = "9999999999999999999999999999999999999999999999999999999999999999999999999999999";
        private string _incorrectDigitStr = "35$#$$5";

        [SetUp]
        public void Setup() {
            _digitParserMock = new Mock<DigitParser>();
            _correctDigitStr = _correctDigit.ToString();
        }
        [Test]
        public void AddChar_CorrectInput_AlwaysStateAccept() {
            //Arrange
            var target = _digitParserMock.Object;
            //Act

            foreach (var digitChar in _correctDigitStr)
            {
                if (target.AddChar(digitChar) != CoordinateParser.State.Accept) {
                    Assert.Fail("State is not equals Accept");
                    return;
                }
            }

            //Assert
            Assert.Pass();
        }

        [Test]
        public void ResultDigit_CorrectInput_ResultDigitEqualsCorrectDigitStr() {
            //Arrange
            var target = _digitParserMock.Object;
            //Act

            foreach (var digitChar in _correctDigitStr)
            {
                if (target.AddChar(digitChar) != CoordinateParser.State.Accept) {
                    Assert.Fail("Input string is not digit");
                    return;
                }
            }
            //Assert
            Assert.AreEqual(target.ResultDigit,_correctDigit);
        }

        [Test]
        public void AddChar_IncorrectInput_StateIncorrect() {
            //Arrange
            var target = _digitParserMock.Object;
            //Act
            foreach (var digitChar in _incorrectDigitStr)
            {
                if (target.AddChar(digitChar) == CoordinateParser.State.Incorrect)
                {
                    Assert.Pass();
                    return;
                }
            }
            //Assert
            Assert.Fail("State is not equals Incorrect");
        }

        [Test]
        public void AddChar_VeryBigDigitInput_StateVeryBigDigit() {
            //Arrange
            var target = _digitParserMock.Object;
            //Act
            foreach (var digitChar in _veryBigDigitStr)
            {
                if (target.AddChar(digitChar) == CoordinateParser.State.VeryBigDigit) {
                    Assert.Pass();
                    return;
                }
            }
            //Assert
            Assert.Fail("State is not equals VeryBigDigit");
        }
    }
}
