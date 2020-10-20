using System;
using HomeWork8.MatrixLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeWork8.Tests
{
    [TestClass]
    public class MatrixDataTests
    {
        private class Matrix :MatrixData {
            public Matrix(int countRow, int countColumn) : base(countRow,countColumn) { 
            }
        }

        [TestMethod]
        public void Constructor_CorrectData_CreateObject()
        {
            //Arrange
            Matrix matrix;
            //Act
            matrix = new Matrix(5, 2);
            //Assert
            Assert.IsNotNull(matrix);
        }
        [TestMethod]
        public void Constructor_InCorrectData_ArgumentOutOfRangeException()
        {
            //Arrange
            Matrix matrix;
            //Act
            Assert.ThrowsException<ArgumentOutOfRangeException>(()=> {
                matrix = new Matrix(-5, 2);
            });
        }

        [TestMethod]
        public void RowCount_CorrectConstructorData_CorrectRowCount()
        {
            //Arrange
            Matrix matrix;
            int row = 5;
            int column = 3;
            //Act
            matrix = new Matrix(row, column);
            //Assert
            Assert.AreEqual(matrix.RowCount,row);
        }

        [TestMethod]
        public void ColumnCount_CorrectConstructorData_CorrectColumnCount()
        {
            //Arrange
            Matrix matrix;
            int row = 5;
            int column = 3;
            //Act
            matrix = new Matrix(row, column);
            //Assert
            Assert.AreEqual(matrix.ColumnCount, column);
        }

        [TestMethod]
        public void Indexator_SetGetData_CorrectSetGet()
        {
            //Arrange
            Matrix matrix;
            int row = 5;
            int column = 3;
            double exceptedReturn = 9;

            int indFirst = 3;
            int indSecond = 2;

            //Act
            matrix = new Matrix(row, column);
            matrix[indFirst,indSecond] = exceptedReturn;
            //Assert
            Assert.AreEqual(matrix[indFirst,indSecond], exceptedReturn);
        }
    }
}
