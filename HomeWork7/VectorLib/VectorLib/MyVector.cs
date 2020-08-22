using System;

namespace VectorLib
{
    /// <summary>
    /// Класс «вектор» для работы с трехмерными векторами
    /// </summary>
    public class MyVector : IMyVector
    {
        public MyVector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
            Length = Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        /// <summary>
        /// Длина вектора
        /// </summary>
        public double Length { get; }
        /// <summary>
        /// X координата вектора
        /// </summary>
        public double X { get; }
        /// <summary>
        /// Y координата вектора
        /// </summary>
        public double Y { get; }
        /// <summary>
        /// Z координата вектора
        /// </summary>
        public double Z { get; }

        /// <summary>
        /// Строковое представление вектора
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"({X},{Y},{Z})";
        }

        /// <summary>
        /// Сложение векторов
        /// </summary>
        /// <param name="vFirst">Первый вектор</param>
        /// <param name="vSecond">Второй вектор</param>
        /// <returns>Результат сложения векторов</returns>
        public static IMyVector operator +(MyVector vFirst, MyVector vSecond)
        {
            return new MyVector(vFirst.X + vSecond.X, vFirst.Y + vSecond.Y, vFirst.Z + vSecond.Z);
        }
        /// <summary>
        /// Вычитание векторов
        /// </summary>
        /// <param name="vFirst">Первый вектор</param>
        /// <param name="vSecond">Второй вектор</param>
        /// <returns>Результат вычитания векторов</returns>
        public static IMyVector operator -(MyVector vFirst, MyVector vSecond)
        {
            return new MyVector(vFirst.X - vSecond.X, vFirst.Y - vSecond.Y, vFirst.Z - vSecond.Z);
        }
        /// <summary>
        /// Умножение векторов
        /// </summary>
        /// <param name="vFirst">Первый вектор</param>
        /// <param name="vSecond">Второй вектор</param>
        /// <returns>Результат умножения векторов</returns>
        public static IMyVector operator *(MyVector vFirst, MyVector vSecond)
        {
            return new MyVector(vFirst.X * vSecond.X, vFirst.Y * vSecond.Y, vFirst.Z * vSecond.Z);
        }

        /// <summary>
        /// Умножение вектора на число
        /// </summary>
        /// <param name="vFirst">Вектор</param>
        /// <param name="digit">Число</param>
        /// <returns>Вектор умноженный на число</returns>
        public static IMyVector operator *(MyVector vFirst, double digit)
        {
            return new MyVector(vFirst.Z * digit, vFirst.Y * digit, vFirst.Z * digit);
        }
    }
}