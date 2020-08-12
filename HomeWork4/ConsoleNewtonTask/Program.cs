using NewtonLibrary;
using System;

namespace ConsoleNewtonTask
{
    class Program
    {
        /// <summary>
        /// Функция проверающая на корректность строку
        /// </summary>
        /// <param name="numberStr">Строка, которую необходимо проверить</param>
        /// <returns>Успешность проверки строки</returns>
        delegate bool VerifiableFunc(string numberStr);
        static void Main(string[] args)
        {
            //Подкоренное выражение
            double number = 0;
            //Степень корня
            int rootDegree = 0;
            //Точность
            double epsilon = SquareRoot.STANDART_EPSILON_VALUE; 

            //Пользователь вводит подкоренное выражение
            UserInputVerifiable("Пожалуйста, введите подкоренное выражение:", (string numberStr) =>
            {
                if (!double.TryParse(numberStr, out number))
                {
                    ErrorWriteLine("Не удалось распознать число.");
                    return false;
                }

                if (number < 0)
                {
                    ErrorWriteLine("Подкоренное выражение не может быть отрицательным числом.");
                    return false;
                }

                return true;
            });

            //Пользователь вводит степень корня
            UserInputVerifiable("Пожалуйста, введите степень корня:", (string numberStr) =>
            {
                if (!int.TryParse(numberStr, out rootDegree))
                {
                    ErrorWriteLine("Не удалось распознать число. Показатель корня (степень) должен быть натуральным числом.");
                    return false;
                }
                if (rootDegree <= 0)
                {
                    ErrorWriteLine("Неверный показатель (степень) корня. Степень должна быть одним из натуральных чисел, исключая ноль.");
                    return false;
                }
                return true;
            });

            //Пользователь вводит точность
            UserInputVerifiable("Пожалуйста, введите требуемую точность или оставьте поле пустым:", (string numberStr) =>
            {
                if (string.IsNullOrWhiteSpace(numberStr)) {
                    return true;
                }
                if (!double.TryParse(numberStr, out epsilon)) {
                    Console.WriteLine("Не удалось распознать число.");
                    return false;
                }
                return true;
            });

            //Вычисленный корень n-ой степени методом Ньютона
            var newtonAnswer = SquareRoot.Newton(number, rootDegree, epsilon);
            //Вычисленный корень n-ой степени с помощью Math.Pow
            var mathPowAnswer = Math.Pow(number,1.0/rootDegree);

            //Вывод получившихся значений
            Console.WriteLine("Число = {0}\nСтепень корня = {1}\nТочность = {2}\nКорень числа:",number,rootDegree,epsilon);
            Console.WriteLine("{0,-20}\t{1,-20}\t{2,-20}","Методом Ньютона","Методом Math.Pow","Разница");
            Console.WriteLine("{0,-20}\t{1,-20}\t{2,-20}",newtonAnswer,mathPowAnswer,newtonAnswer-mathPowAnswer);
        }

        /// <summary>
        /// Бесконечное приглашение ввода для пользователя, пока введеные данные не будут корректными
        /// </summary>
        /// <param name="promptMessage">Сообщение приглашающее пользователя к вводу</param>
        /// <param name="verifiableFunc">Функция проверающая на корректность строку</param>
        static void UserInputVerifiable(string promptMessage, VerifiableFunc verifiableFunc)
        {
            Console.WriteLine(promptMessage);
            string inputStr;
            do
            {
                inputStr = InputPrompt();
            } while (!verifiableFunc(inputStr));
        }

        /// <summary>
        /// Приглашение ввода
        /// </summary>
        /// <returns>Строка символов считанных из входного потока</returns>
        static string InputPrompt()
        {
            Console.Write(">");
            return Console.ReadLine();
        }

        /// <summary>
        /// Выводит отфармотированную строку о возникшей ошибке
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        static void ErrorWriteLine(string message)
        {
            Console.WriteLine("[ОШИБКА] {0}", message);
        }
    }
}
