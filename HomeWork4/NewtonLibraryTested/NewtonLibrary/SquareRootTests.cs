using NewtonLibrary;
using NUnit.Framework;
using System;

namespace HomeWork4Tested
{
    public class SquareRootTests
    {
        [Test]
        public void Newton_NormalInput_CorrectAnswer()
        {
            //Arrange
            var expectedAnswer = 3d;
            //Act
            var target = SquareRoot.Newton(number: 9, rootDegree: 2);
            //Assert
            Assert.AreEqual(expectedAnswer, target);
        }

        [Test]
        public void Newton_NegativeNumber_NanAnswer()
        {
            //Arrange
            var expectedAnswer = double.NaN;
            //Act
            var target = SquareRoot.Newton(number: -9, rootDegree: 2);
            //Assert
            Assert.AreEqual(expectedAnswer, target);
        }

        [Test]
        public void Newton_ZeroNumber_ZeroAnswer()
        {
            //Arrange
            var expectedAnswer = 0d;
            //Act
            var target = SquareRoot.Newton(number: 0, rootDegree: 2);
            //Assert
            Assert.AreEqual(expectedAnswer, target);
        }

        [Test]
        public void Newton_ZeroRootDegree_NanAnswer()
        {
            //Arrange
            var expectedAnswer = double.NaN;
            //Act
            var target = SquareRoot.Newton(number: 3, rootDegree: 0);
            //Assert
            Assert.AreEqual(expectedAnswer, target);
        }

        [Test]
        public void Newton_NegativeRootDegree_NanAnswer()
        {
            //Arrange
            var expectedAnswer = double.NaN;
            //Act
            var target = SquareRoot.Newton(number: 3, rootDegree: -1);
            //Assert
            Assert.AreEqual(expectedAnswer, target);
        }
    }
}