using System;

namespace HomeWork8.MatrixLib
{
    public class MatricesSizeException : Exception
    {
        public readonly Matrix FirstMatrix = null;
        public readonly Matrix SecondMatrix = null;

        public MatricesSizeException(string message) : base(message) { }

        public MatricesSizeException(string message, Exception innerException) : base(message, innerException) { }

        public MatricesSizeException() : this("Матрицы имеют неверные размеры.") { }

        public MatricesSizeException(Matrix mFirst, Matrix mSecond)
    : this("Матрицы имеют неверные размеры.", mFirst, mSecond)
        { }

        public MatricesSizeException(Matrix mFirst, Matrix mSecond, Exception innerException)
: this("Матрицы имеют неверные размеры.", mFirst, mSecond, innerException)
        { }

        public MatricesSizeException(string message, Matrix mFirst, Matrix mSecond)
            : this(message + $"\nМатрица 1: {mFirst.RowCount}x{mFirst.ColumnCount}.\nМатрица 2: {mSecond.RowCount}x{mSecond.ColumnCount}/")
        {
            FirstMatrix = mFirst;
            SecondMatrix = mSecond;
        }

        public MatricesSizeException(string message, Matrix mFirst, Matrix mSecond, Exception innerException)
    : this(message + $"\nМатрица 1: {mFirst.RowCount}x{mFirst.ColumnCount}.\nМатрица 2: {mSecond.RowCount}x{mSecond.ColumnCount}/", innerException)
        {
            FirstMatrix = mFirst;
            SecondMatrix = mSecond;
        }
    }
}
