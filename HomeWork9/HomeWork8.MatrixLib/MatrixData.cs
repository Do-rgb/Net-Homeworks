using System;

namespace HomeWork8.MatrixLib
{
    public class MatrixData {
        private double[,] _matrix;

        protected MatrixData(int countRow, int countColumn)
        {
            if (countRow < 1) {
                throw new ArgumentOutOfRangeException("countRow",countRow, "Число строк в матрице должно быть больше 0.");
            }
            if (countColumn < 1)
            {
                throw new ArgumentOutOfRangeException("countColumn", countColumn, "Число столбцов в матрице должно быть больше 0.");
            }
            _matrix = new double[countRow, countColumn];
        }

        public int RowCount => _matrix.GetLength(0);
        public int ColumnCount => _matrix.GetLength(1);

        public double this[int row, int column]
        {
            get { return _matrix[row, column]; }
            set { _matrix[row, column] = value; }
        }
    }
}
