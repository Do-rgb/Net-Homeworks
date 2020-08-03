using System.Globalization;

namespace CoordLibrary.Parsers
{
    public partial class CoordinateParser
    {
        /// <summary>
        /// Хранит настройки парсера чисел
        /// </summary>
        public class ParserSettings
        {
            /// <summary>
            /// Разделители координат
            /// </summary>
            public char[] Delimiters { get; set; }
            /// <summary>
            /// Предоставляет сведения для конкретного языка и региональных параметров для числовых значений форматирования и анализа.
            /// </summary>
            public NumberFormatInfo NumberFormat;
        }
    }
}
