using System;
using System.Diagnostics;

namespace GCDLibrary
{
    public class GCDFinder
    {
        #region Алгоритм Эвклида 
        /// <summary>
        /// Вычисляет НОД с использованием алгоритма Евклида.
        /// Для двух чисел.
        /// </summary>
        /// <param name="digitOne">1-е число</param>
        /// <param name="digitTwo">2-е число</param>
        /// <returns>Вычисленный НОД</returns>
        public static decimal EuclideanAlg(decimal digitOne, decimal digitTwo)
        {
            if (digitOne < 0)
                digitOne = Math.Abs(digitOne);

            if (digitTwo < 0)
                digitTwo = Math.Abs(digitTwo);

            while (digitOne != 0 && digitTwo != 0)
            {
                if (digitOne > digitTwo)
                {
                    digitOne %= digitTwo;
                }
                else
                {
                    digitTwo %= digitOne;
                }
            }

            return digitOne + digitTwo;
        }
        /// <summary>
        /// Вычисляет НОД с использованием алгоритма Евклида.
        /// Для нескольких чисел.
        /// </summary>
        /// <param name="digitOne">1-е число</param>
        /// <param name="digitTwo">2-е число</param>
        /// <param name="otherDigits">Остальные числа</param>
        /// <returns>Вычисленный НОД</returns>
        public static decimal EuclideanAlg(decimal digitOne, decimal digitTwo, params decimal[] otherDigits)
        {
            decimal result = EuclideanAlg(digitOne, digitTwo);

            foreach (var nextDigit in otherDigits)
            {
                result = EuclideanAlg(result, nextDigit);
            }

            return result;
        }
        /// <summary>
        /// Вычисляет НОД с использованием алгоритма Евклида.
        /// Для нескольких чисел.
        /// </summary>
        /// <param name="digitOne">1-е число</param>
        /// <param name="digitTwo">2-е число</param>
        /// <param name="timeSpan">Время затраченное при работае алгоритма</param>
        /// <param name="otherDigits">Остальные числа</param>
        /// <returns>Вычисленный НОД</returns>
        public static decimal EuclideanAlg(decimal digitOne, decimal digitTwo, out TimeSpan timeSpan, params decimal[] otherDigits)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = EuclideanAlg(digitOne, digitTwo, otherDigits);
            stopwatch.Stop();

            timeSpan = stopwatch.Elapsed;

            return result;
        }
        #endregion

        #region Бинарный алгоритм Эвклида
        /// <summary>
        /// Вычисляет НОД с использованием алгоритма Стейна.
        /// Для двух чисел.
        /// </summary>
        /// <param name="digitOne">1-е число</param>
        /// <param name="digitTwo">2-е число</param>
        /// <returns>Вычисленный НОД</returns>
        public static decimal BinaryEuclideanAlg(decimal digitOne, decimal digitTwo)
        {
            if (digitOne < 0)
                digitOne = Math.Abs(digitOne);

            if (digitTwo < 0)
                digitTwo = Math.Abs(digitTwo);
            //подсчитывает «несоразмерность», полученную в результате деления digitOne и digitTwo одновременно
            int k = 1;
            while (digitOne != 0 && digitTwo != 0)
            {
                while (digitOne % 2 == 0 && digitTwo % 2 == 0)
                {
                    digitOne /= 2;
                    digitTwo /= 2;
                    k *= 2;
                }

                while (digitOne != 0 && digitOne % 2 == 0)
                {
                    digitOne /= 2;
                }

                while (digitTwo != 0 && digitTwo % 2 == 0)
                {
                    digitTwo /= 2;
                }

                if (digitOne >= digitTwo)
                {
                    digitOne -= digitTwo;
                }
                else
                {
                    digitTwo -= digitOne;
                }
            }

            return digitTwo * k;
        }
        /// <summary>
        /// Вычисляет НОД с использованием алгоритма Стейна.
        /// Для нескольких чисел.
        /// </summary>
        /// <param name="digitOne">1-е число</param>
        /// <param name="digitTwo">2-е число</param>
        /// <param name="otherDigits">Другие числа</param>
        /// <returns>Вычисленный НОД</returns>
        public static decimal BinaryEuclideanAlg(decimal digitOne, decimal digitTwo, params decimal[] otherDigits)
        {
            decimal result = BinaryEuclideanAlg(digitOne, digitTwo);

            foreach (var nextDigit in otherDigits)
            {
                result = BinaryEuclideanAlg(result, nextDigit);
            }

            return result;
        }
        /// <summary>
        /// Вычисляет НОД с использованием алгоритма Стейна.
        /// Для нескольких чисел.
        /// </summary>
        /// <param name="digitOne">1-е число</param>
        /// <param name="digitTwo">2-е число</param>
        /// <param name="timeSpan">Время затраченное при работае алгоритма</param>
        /// <param name="otherDigits">Другие числа</param>
        /// <returns>Вычисленный НОД</returns>
        public static decimal BinaryEuclideanAlg(decimal digitOne, decimal digitTwo, out TimeSpan timeSpan, params decimal[] otherDigits)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = BinaryEuclideanAlg(digitOne, digitTwo, otherDigits);
            stopwatch.Stop();

            timeSpan = stopwatch.Elapsed;

            return result;
        }
        #endregion
    }
}
