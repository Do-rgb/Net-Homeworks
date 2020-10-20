using System;
using HomeWork8.MatrixLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeWork8.Tests
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void EqualSize_TwoDifferentSizeMatrix_False()
        {
            //Arrange
            Matrix one = Matrix.GetEmpty(5, 5);
            Matrix two = Matrix.GetEmpty(6, 5);
            //Act
            var target = one.EqualSize(two);
            //Assert
            Assert.IsFalse(target);
        }

        [TestMethod]
        public void EqualSize_TwoEqualSizeMatrix_True()
        {
            //Arrange
            Matrix one = Matrix.GetEmpty(5, 5);
            Matrix two = Matrix.GetEmpty(5, 5);
            //Act
            var target = one.EqualSize(two);
            //Assert
            Assert.IsTrue(target);
        }

        [TestMethod]
        public void GetEmpty_CorrectInput_EmptyMatrix()
        {
            //Arrange
            int countRow = 5;
            int countColumn = 5;
            Matrix matrix = Matrix.GetEmpty(countRow, countColumn);
            //Act
            for (int row = 0; row < countRow; row++)
            {
                for (int column = 0; column < countColumn; column++)
                {
                    if (matrix[row, column] != 0) {
                        Assert.Fail();
                    }
                }
            }
        }

        [TestMethod]
        public void Addition_TwoEqualSizeMatrix_NotThrow()
        {
            //Arrange
            Matrix one = Matrix.GetEmpty(5, 5);
            Matrix two = Matrix.GetEmpty(5, 5);
            //Act
            var target = one + two;
            //Assert
        }

        [TestMethod]
        public void Addition_TwoNotEqualSizeMatrix_MatricesSizeException()
        {
            //Arrange
            Matrix one = Matrix.GetEmpty(5, 5);
            Matrix two = Matrix.GetEmpty(50, 50);
            //Act
            Assert.ThrowsException<MatricesSizeException>(()=> {
                var target = one + two;
            });
            //Assert
        }

        [TestMethod]
        public void Addition_TwoNormalMatrix_CorrectAddition()
        {
            //Arrange
            double exceptedAnswer = 2;
            int rowCount = 5;
            int columnCount = 5;
            Matrix one = Matrix.GetEmpty(rowCount, columnCount);
            for (int row = 0; row < rowCount; row++)
            {
                for (int column = 0; column < columnCount; column++)
                {
                    one[row, column] = exceptedAnswer;
                }
            }
            Matrix two = Matrix.GetEmpty(rowCount, columnCount);
            //Act
            var target = one + two;
            //Assert
            for (int row = 0; row < rowCount; row++)
            {
                for (int column = 0; column < columnCount; column++)
                {
                    if (target[row, column] != exceptedAnswer) {
                        Assert.Fail();
                    }
                }
            }
        }

        [TestMethod]
        public void Negative_TwoEqualSizeMatrix_NotThrow()
        {
            //Arrange
            Matrix one = Matrix.GetEmpty(5, 5);
            Matrix two = Matrix.GetEmpty(5, 5);
            //Act
            var target = one - two;
            //Assert
        }

        [TestMethod]
        public void Negative_TwoNotEqualSizeMatrix_MatricesSizeException()
        {
            //Arrange
            Matrix one = Matrix.GetEmpty(5, 5);
            Matrix two = Matrix.GetEmpty(50, 50);
            //Act
            Assert.ThrowsException<MatricesSizeException>(() => {
                var target = one - two;
            });
            //Assert
        }

        [TestMethod]
        public void Negative_TwoNormalMatrix_CorrectNegative()
        {
            //Arrange
            double exceptedAnswer = 9;
            int rowCount = 5;
            int columnCount = 5;

            Matrix one = Matrix.GetEmpty(rowCount, columnCount);
            for (int row = 0; row < rowCount; row++)
            {
                for (int column = 0; column < columnCount; column++)
                {
                    one[row, column] = exceptedAnswer;
                }
            }
            Matrix two = Matrix.GetEmpty(rowCount, columnCount);
            //Act
            var target = one - two;
            //Assert
            for (int row = 0; row < rowCount; row++)
            {
                for (int column = 0; column < columnCount; column++)
                {
                    if (target[row, column] != exceptedAnswer)
                    {
                        Assert.Fail();
                    }
                }
            }
        }

        [TestMethod]
        public void Multiple_TwoEqualSizeMatrix_NotThrow()
        {
            //Arrange
            Matrix one = Matrix.GetEmpty(2, 5);
            Matrix two = Matrix.GetEmpty(5, 1);
            //Act
            var target = one * two;
            //Assert
        }

        [TestMethod]
        public void Multiple_TwoNotEqualSizeMatrix_MatricesSizeException()
        {
            //Arrange
            Matrix one = Matrix.GetEmpty(5, 5);
            Matrix two = Matrix.GetEmpty(50, 50);
            //Act
            Assert.ThrowsException<MatricesSizeException>(() => {
                var target = one * two;
            });
            //Assert
        }

        [TestMethod]
        public void Multiple_TwoNormalMatrix_CorrectMultiple()
        {
            //Arrange
            double exceptedAnswer = 0;
            int rowCount = 5;
            int columnCount = 5;

            Matrix one = Matrix.GetEmpty(rowCount, columnCount);
            for (int row = 0; row < rowCount; row++)
            {
                for (int column = 0; column < columnCount; column++)
                {
                    one[row, column] = 55;
                }
            }
            Matrix two = Matrix.GetEmpty(rowCount, columnCount);
            //Act
            var target = one * two;
            //Assert
            for (int row = 0; row < rowCount; row++)
            {
                for (int column = 0; column < columnCount; column++)
                {
                    if (target[row, column] != exceptedAnswer)
                    {
                        Assert.Fail();
                    }
                }
            }
        }
    }
}
