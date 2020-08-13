using NUnit.Framework;
using System;
using TriangleLibrary;

namespace TriangleLibraryTested
{
    public class TriangleTests
    {
        static readonly decimal _aSide = 3;
        static readonly decimal _bSide = 3;
        static readonly decimal _cSide = 3;
        static readonly decimal _perimetr = _aSide + _bSide + _cSide;
        //Площадь считается методом Герона
        static readonly decimal _area = (decimal)Math.Sqrt(decimal.ToDouble(_perimetr/ 2 * (_perimetr/2 - _aSide) * (_perimetr/2 - _bSide) * (_perimetr/2 - _cSide)));

        [Test]
        public void TryCreate_CorrectInput_TrueAndObject()
        {
            //Arrange
            Triangle target;
            //Act
            var isCreate = Triangle.TryCreate(_aSide,_bSide,_cSide,out target);
            //Assert
            Assert.IsNotNull(target);
            Assert.IsTrue(isCreate);
        }

        [Test]
        public void TryCreate_ZeroSides_FalseAndNullObject()
        {
            //Arrange
            Triangle target;
            //Act
            var isCreate = Triangle.TryCreate(0, 0, 0, out target);
            //Assert
            Assert.IsNull(target);
            Assert.IsFalse(isCreate);
        }

        [Test]
        public void TryCreate_InCorrectInput_FalseAndNullObject()
        {
            //Arrange
            Triangle target;
            //Act
            var isCreate = Triangle.TryCreate(1, 5, 3, out target);
            //Assert
            Assert.IsNull(target);
            Assert.IsFalse(isCreate);
        }

        [Test]
        public void TryCreate_NegativeInput_FalseAndNullObject()
        {
            //Arrange
            Triangle target;
            //Act
            var isCreate = Triangle.TryCreate(-1, -5, -3, out target);
            //Assert
            Assert.IsNull(target);
            Assert.IsFalse(isCreate);
        }

        [Test]
        public void Perimetr_CorrectInput_CorrectPerimeter() {
            //Arrange
            Triangle triangle;
            //Act
            Triangle.TryCreate(_aSide,_bSide,_cSide,out triangle);
            //Assert
            Assert.AreEqual(_perimetr,triangle.Perimeter);
        }

        [Test]
        public void Area_CorrectInput_CorrectArea()
        {
            //Arrange
            Triangle triangle;
            //Act
            Triangle.TryCreate(_aSide, _bSide, _cSide, out triangle);
            //Assert
            Assert.AreEqual(_area, triangle.Area);
        }
    }
}