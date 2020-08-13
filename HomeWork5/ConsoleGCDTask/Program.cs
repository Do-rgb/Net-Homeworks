using GCDLibrary;
using InputCheckerLibrary;
using System;
using System.Collections.Generic;

namespace ConsoleGCDTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //Содержит числа введенные пользователем
            List<decimal> digits = new List<decimal>();

            //Приглашение пользователя к вводу чисел
            Checker.UserInputVerifiable("Пожалуйста, введите числа для поиска НОД, разделяя их символом ';'", (string input) =>
            {
                string[] inputSplited = input.Split(';', StringSplitOptions.RemoveEmptyEntries);

                foreach (var digitStr in inputSplited)
                {
                    if (!decimal.TryParse(digitStr, out var digit))
                    {
                        Checker.ErrorWriteLine($"Не удалось распознать число.\nПозиция: {input.IndexOf(digitStr) + 1}\nВвод: {digitStr}");
                        digits.Clear();
                        return false;
                    }
                    digits.Add(digit);
                }
                if (digits.Count < 2)
                {
                    digits.Clear();
                    Checker.ErrorWriteLine("Слишком мало чисел. Пожалуйста введит по крайне мере 2 числа.");
                    return false;
                }
                return true;
            });

            //Первое введенное число
            var digitOne = digits[0];
            digits.RemoveAt(0);

            //Второе введенное число
            var digitTwo = digits[0];
            digits.RemoveAt(0);

            //Время затрачиваемое при работе алгоритма Евклида
            TimeSpan euclideanTime;

            //Время затрачиваемое при работе бинарного алгоритма Евклида
            TimeSpan binaryEuclideanTime;

            var euclideanGCD = GCDFinder.EuclideanAlg(digitOne, digitTwo, out euclideanTime, digits.ToArray());
            var binaryEuclideanGCD = GCDFinder.BinaryEuclideanAlg(digitOne, digitTwo, out binaryEuclideanTime, digits.ToArray());

            Console.WriteLine("{0,-20}\t{1,-20}\t{2}", "Алгоритм", "НОД", "Время");
            Console.WriteLine("{0,-20}\t{1,-20}\t{2} мс", "Евклид", euclideanGCD, euclideanTime.TotalMilliseconds);
            Console.WriteLine("{0,-20}\t{1,-20}\t{2} мс", "Стейна", binaryEuclideanGCD, binaryEuclideanTime.TotalMilliseconds);
            Console.WriteLine("Разница по времени: {0} мс", Math.Abs(euclideanTime.TotalMilliseconds - binaryEuclideanTime.TotalMilliseconds));
        }
    }
}
