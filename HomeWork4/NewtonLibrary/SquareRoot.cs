using System;
using System.Runtime.CompilerServices;

namespace NewtonLibrary
{
    public class SquareRoot
    {
        /// <summary>
        /// Точность используемая по умолчанию.
        /// </summary>
        public const double STANDART_EPSILON_VALUE = 0.000001;
        /// <summary>
        /// Вычисляет корень n-ой степени из числа методом Ньютона с заданной точностью.
        /// </summary>
        /// <param name="number">Подкоренное выражение</param>
        /// <param name="rootDegree">Степень корня</param>
        /// <param name="epsilon">Точность</param>
        /// <returns>Корень n-ой степени из числа</returns>
        public static double Newton(double number, int rootDegree, double epsilon = STANDART_EPSILON_VALUE)
        {
            if (rootDegree <= 0) return double.NaN;
            if (number < 0) return double.NaN;

            double Xk = default;
            double XkNext = number;

            /*
            Т.к. метод касательных имеет квадратичную сходимость 
            большое количество итераций будет свидетельствовать о
            лишних операциях проводимых при указании слишком маллых
            значений степени корня или подкоренного выражения.
            Обычно 6 итераций достаточно для увеличения точности с 1 до 64 разрядов.
             */
            int maxIterCount = 100;


            for (int iterCounter = 0; Math.Abs(Xk - XkNext) >= epsilon; iterCounter++)
            {
                //Выход из бесконечного цикла
                if (iterCounter > maxIterCount)
                {
                    return double.PositiveInfinity;
                }

                Xk = XkNext;
                XkNext = 1.0 / rootDegree * ((rootDegree - 1) * Xk + number / Math.Pow(Xk, rootDegree - 1));
            }

            return XkNext;
        }
    }
}
