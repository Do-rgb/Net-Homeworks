using System;

namespace InputCheckerLibrary
{
    public class Checker
    {
        /// <summary>
        /// Бесконечное приглашение ввода для пользователя, пока введеные данные не будут корректными
        /// </summary>
        /// <param name="promptMessage">Сообщение приглашающее пользователя к вводу</param>
        /// <param name="verifiableFunc">Функция проверающая на корректность строку</param>
        public static void UserInputVerifiable(string promptMessage, Func<string, bool> verifiableFunc)
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
        private static string InputPrompt()
        {
            Console.Write(">");
            return Console.ReadLine();
        }
        /// <summary>
        /// Выводит отфармотированную строку о возникшей ошибке
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        public static void ErrorWriteLine(string message)
        {
            Console.WriteLine("[ОШИБКА] {0}", message);
        }
    }
}
