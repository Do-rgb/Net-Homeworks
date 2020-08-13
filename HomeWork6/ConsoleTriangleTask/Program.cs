using InputCheckerLibrary;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using TriangleLibrary;

namespace ConsoleTriangleTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = null;

            //Приглашения пользователя к вводу
            Checker.UserInputVerifiable("Введите стороны треугольника, разделяя ввод символом ';'", (string input) =>
            {
                string[] inputSplit = input.Split(';',StringSplitOptions.RemoveEmptyEntries);

                if (inputSplit.Length != 3) {
                    Checker.ErrorWriteLine("Неверное количество сторон треугольника. Пожалуйста введите 3 стороны.");
                    return false;
                }

                List<decimal> sizes = new List<decimal>(3);

                foreach (var digitStr in inputSplit)
                {
                    if (!decimal.TryParse(digitStr, out var digit)) {
                        Checker.ErrorWriteLine($"Не удалось распознать число.\nПозиция: {input.IndexOf(digitStr) + 1}\nВвод: {digitStr}");
                        sizes.Clear();
                        return false;
                    }
                    sizes.Add(digit);
                }

                if (!Triangle.TryCreate(sizes[0], sizes[1], sizes[2], out triangle)) {
                    Checker.ErrorWriteLine("Треугольник с такими сторонами существовать не может. Пожалуйста введите корректные данные.");
                    return false;
                }

                return true;
            });

            Console.WriteLine($"Сторона A:{triangle.A}\n" +
                $"Сторона B:{triangle.B}\n" +
                $"Сторона C:{triangle.C}\n" +
                $"Периметр: {triangle.Perimeter}\n" +
                $"Площадь: {triangle.Area}");
        }
    }
}
