using System;
using System.Linq;

namespace BinaryRepresentationLibrary
{
    public class BinaryRepresentator
    {
        /// <summary>
        /// Конвертирует неотрицательное десятичное значение целого числа в строку, содержащую двоичное представление этого значения.
        /// Используя стандартные классы и методы для конвертирования.
        /// </summary>
        /// <param name="digit">Неотрицательное десятичное целое число, конвертируемое в двоичное представление</param>
        /// <returns>Строка содержащая двоичное представление десятичного числа</returns>
        public static string ConvertStandart(uint digit) {
            return Convert.ToString(digit,2);
        }

        /// <summary>
        /// Конвертирует неотрицательное десятичное значение целого числа в строку, содержащую двоичное представление этого значения.
        /// Используя свой алгоритм конвертирования.
        /// </summary>
        /// <param name="digit">Неотрицательное десятичное целое число, конвертируемое в двоичное представление</param>
        /// <returns>Строка содержащая двоичное представление десятичного числа</returns>
        public static string ConvertMyAlg(uint digit) {
            if (digit == 0) return "0";

            //Стандартный "школьный" алгоритм нахождения двоичного представления числа из десятичного

            string result = "";

            while (digit > 0) {
                result += digit % 2;
                digit /= 2;
            }

            //Согласно "школьному" алгоритму получившийся набор необходимо перевернуть
            result = new string(result.Reverse().ToArray());

            return result;
        }
    }
}
