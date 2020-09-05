using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Text;

namespace HomeWork8.MatrixLib
{

    public class Matrix : MatrixData
    {
        private Matrix(int countRow, int countColumn) : base(countRow, countColumn) { }
        public bool EqualSize(Matrix other)
        {
            return ColumnCount.Equals(other.ColumnCount) && RowCount.Equals(other.RowCount);
        }
        private void ForEach(Action<int, int,double> func)
        {
            for (int row = 0; row < RowCount; row++)
            {
                for (int column = 0; column < ColumnCount; column++)
                {
                    func(row, column,this[row,column]);
                }
            }
        }
        private void ForEach(Func<int,int,double> func) {
            for (int row = 0; row < RowCount; row++)
            {
                for (int column = 0; column < ColumnCount; column++)
                {
                    this[row,column] = func(row, column);
                }
            }
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            int prevRow = 0;

            this.ForEach((row,column,element) => {
                if (prevRow != row) {
                    result.AppendLine();
                    prevRow=row;
                }

                result.Append($"{element} ");
            });

            return result.ToString();
        }
        public static Matrix GetEmpty(int countRow, int countColumn)
        {
            return new Matrix(countRow, countColumn);
        }
        public static Matrix operator +(Matrix mFirst,Matrix mSecond) {
            if (!mFirst.EqualSize(mSecond)) {
                throw new MatricesSizeException("Матрицы имеют не одинаковые размеры.", mFirst, mSecond);
            }

            Matrix result = Matrix.GetEmpty(mFirst.RowCount,mFirst.ColumnCount);

            result.ForEach((row,column)=> {
                return mFirst[row, column] + mSecond[row, column];
            });

            return result;
        }
        public static Matrix operator -(Matrix mFirst, Matrix mSecond)
        {
            if (!mFirst.EqualSize(mSecond))
            {
                throw new MatricesSizeException("Матрицы имеют не одинаковые размеры.",mFirst, mSecond);
            }

            Matrix result = Matrix.GetEmpty(mFirst.RowCount, mFirst.ColumnCount);

            result.ForEach((row, column) => {
                return mFirst[row, column] - mSecond[row, column];
            });

            return result;
        }
        public static Matrix operator *(Matrix mFirst, Matrix mSecond)
        {
            if (mFirst.ColumnCount != mSecond.RowCount)
            {
                throw new MatricesSizeException("Число столбцов первой матрицы не равняется числу строк второй матрицы.", mFirst, mSecond);
            }

            Matrix result = Matrix.GetEmpty(mFirst.RowCount, mSecond.ColumnCount);

            result.ForEach((row, column) => {

                double addResult = 0;

                for (int i = 0; i < mSecond.RowCount; i++)
                {
                    addResult += mFirst[row,i] * mSecond[i,column];
                }

                return addResult;
            });

            return result;
        }
    }
}
