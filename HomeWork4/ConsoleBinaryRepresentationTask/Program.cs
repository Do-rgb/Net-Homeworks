using BinaryRepresentationLibrary;
using System;

namespace ConsoleBinaryRepresentationTask
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
            //Десятичное число, которое необходимо конвертировать в двоичное представление
            uint digit = 0;
            
            //Пользователь вводит десятичное число
            UserInputVerifiable("Пожалуйста, введите целое, положительное, десятичное число:", (string numberStr) =>
            {
                if (!uint.TryParse(numberStr, out digit))
                {
                    ErrorWriteLine("Не верный формат числа.");
                    return false;
                }

                return true;
            });

            //Вывод получившихся значений
            Console.WriteLine("Двоичное значение, используя стандартные классы:\t{0}", BinaryRepresentator.ConvertStandart(digit));
            Console.WriteLine("Двоичное значение, используя собственный алгоритм:\t{0}", BinaryRepresentator.ConvertMyAlg(digit));
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
