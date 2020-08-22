using Microsoft.VisualStudio.TestTools.UnitTesting;
using VectorLib;

namespace VectorLibTests
{
    [TestClass]
    public class MyVectorTests
    {
        private readonly MyVector _vFirst = new MyVector(8, 8, 8);
        private readonly MyVector _vSecond = new MyVector(2, 2, 2);

        private readonly double _vFirstMultipleDigit = 3;

        private readonly (double X, double Y, double Z) _additionAnswer = (X: 10, Y: 10, Z: 10);
        private readonly (double X, double Y, double Z) _multipleAnswer = (X: 16, Y: 16, Z: 16);
        private readonly (double X, double Y, double Z) _multipleOnDigitFirstVectorAnswer = (X: 24, Y: 24, Z: 24);
        private readonly (double X, double Y, double Z) _subtractionAnswer = (X: 6, Y: 6, Z: 6);

        [TestMethod]
        public void Plus_TwoNormalVectors_CorrectAnswer()
        {
            //Act
            var target = _vFirst + _vSecond;

            //Assert
            Assert.AreEqual(_additionAnswer.X, target.X);
            Assert.AreEqual(_additionAnswer.Y, target.Y);
            Assert.AreEqual(_additionAnswer.Z, target.Z);
        }

        [TestMethod]
        public void Minus_TwoNormalVectors_CorrectAnswer()
        {
            //Act
            var target = _vFirst - _vSecond;
            //Assert
            Assert.AreEqual(_subtractionAnswer.X, target.X);
            Assert.AreEqual(_subtractionAnswer.Y, target.Y);
            Assert.AreEqual(_subtractionAnswer.Z, target.Z);
        }

        [TestMethod]
        public void Multiple_TwoNormalVectors_CorrectAnswer()
        {
            //Act
            var target = _vFirst * _vSecond;
            //Assert
            Assert.AreEqual(_multipleAnswer.X, target.X);
            Assert.AreEqual(_multipleAnswer.Y, target.Y);
            Assert.AreEqual(_multipleAnswer.Z, target.Z);
        }

        [TestMethod]
        public void Multiple_Digit_CorrectAnswer()
        {
            //Act
            var target = _vFirst * _vFirstMultipleDigit;
            //Assert
            Assert.AreEqual(_multipleOnDigitFirstVectorAnswer.X, target.X);
            Assert.AreEqual(_multipleOnDigitFirstVectorAnswer.Y, target.Y);
            Assert.AreEqual(_multipleOnDigitFirstVectorAnswer.Z, target.Z);
        }

        [TestMethod]
        public void Length_SimpleVector_CorrectLength()
        {
            //Arrange
            var vector = new MyVector(2, 4, 4);
            var length = 6d;
            //Assert
            Assert.AreEqual(length, vector.Length);
        }
    }
}