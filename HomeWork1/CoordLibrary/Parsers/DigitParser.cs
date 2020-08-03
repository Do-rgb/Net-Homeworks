using System;
using System.Globalization;
using System.Text;
using static CoordLibrary.Parsers.CoordinateParser;

namespace CoordLibrary.Parsers
{
    /// <summary>
    /// Формирует число из входящих символов
    /// </summary>
    public class DigitParser
    {
        /// <summary>
        /// Хранит входящие символы для последующей конвертации в число
        /// </summary>
        private StringBuilder _digitBuffer = new StringBuilder();
        /// <summary>
        /// Предоставляет сведения для конкретного языка и региональных параметров для числовых значений форматирования и анализа.
        /// </summary>
        public NumberFormatInfo NumberFormatInfo { get; set; }
        /// <summary>
        /// Хранит промежуточное преобразованное строковое представление числа в его эквиваленте типа Decimal.
        /// </summary>
        public decimal ResultDigit { get; private set; }

        /// <summary>
        /// Добавляет очередной символ в буфер и преобразовывает его в число типа Decimal
        /// </summary>
        /// <param name="nextChar">Очередной символ</param>
        /// <returns>Состояние операции преобразования</returns>
        public State AddChar(char nextChar)
        {
            //Добавить очередной символ в буфер
            _digitBuffer.Append(nextChar);

            try
            {
                //Попытаться преобразовать символ в число
                ResultDigit = decimal.Parse(_digitBuffer.ToString(), NumberFormatInfo);
            }
            catch (OverflowException)
            {
                _digitBuffer.Remove(_digitBuffer.Length - 1, 1);
                return State.VeryBigDigit;
            }
            catch
            {
                _digitBuffer.Remove(_digitBuffer.Length - 1, 1);
                return State.Incorrect;
            }

            return State.Accept;
        }
    }
}
