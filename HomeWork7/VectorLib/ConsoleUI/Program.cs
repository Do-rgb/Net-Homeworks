using InputCheckerLibrary;
using System;
using System.Collections.Generic;
using VectorLib;

namespace ConsoleUI
{
    class Program
    {
        static bool ParseCoords(string input,out MyVector vector,out string message) {
            vector = null;
            //Содержит числа введенные пользователем
            List<double> digits = new List<double>();

            string[] splitInput = input.Split(';', StringSplitOptions.RemoveEmptyEntries);

            if (splitInput.Length != 3)
            {
                message = "Неверное количество введенных чисел. Пожалуйста, введите 3 числа.";
                return false;
            }

            foreach (var digitStr in splitInput)
            {
                if (!double.TryParse(digitStr, out var digit))
                {
                    message = $"Не удалось распознать число.\nПозиция: {input.IndexOf(digitStr) + 1}\nВвод: {digitStr}";
                    digits.Clear();
                    return false;
                }
                digits.Add(digit);
            }

            message = null;
            vector = new MyVector(digits[0],digits[1],digits[2]);

            return true;
        }
        static void Main(string[] args)
        {
            MyVector vector1 = null;
            MyVector vector2 = null;
            double digit = 0;
            //Просим пользователя ввести координаты вектора
            Checker.UserInputVerifiable("Пожалуйста, введите координаты 1-го вектора, разделяя ввод символом ';'", input =>
            {
                if (!ParseCoords(input, out vector1, out var message)) {
                    Checker.ErrorWriteLine(message);
                    return false;
                }
                return true;
            });

            Checker.UserInputVerifiable("Пожалуйста, введите координаты 2-го вектора, разделяя ввод символом ';'", input =>
            {
                if (!ParseCoords(input, out vector2, out var message))
                {
                    Checker.ErrorWriteLine(message);
                    return false;
                }
                return true;
            });

            Checker.UserInputVerifiable("Пожалуйста, введите число на которое необходимо умножить вектор:", input =>
            {
                if (!double.TryParse(input,out digit))
                {
                    Checker.ErrorWriteLine("Не удалось распознать число.");
                    return false;
                }
                return true;
            });

            Console.WriteLine("\nВы ввели 2 вектора:");
            Console.WriteLine($"{vector1}\tДлина:{vector1.Length}");
            Console.WriteLine($"{vector2}\tДлина:{vector2.Length}");

            Console.WriteLine($"{vector1} + {vector2} = {vector1 + vector2}");
            Console.WriteLine($"{vector1} * {vector2} = {vector1 * vector2}");
            Console.WriteLine($"{vector1} * {digit} = {vector1 * digit}");
            Console.WriteLine($"{vector1} - {vector2} = {vector1 - vector2}");
        }
    }
}
