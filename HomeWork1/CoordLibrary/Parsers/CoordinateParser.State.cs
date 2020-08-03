namespace CoordLibrary.Parsers
{
    public partial class CoordinateParser
    {
        /// <summary>
        /// Состояние обработки очередного символа
        /// </summary>
        public enum State
        {
            /// <summary>
            /// Символ был пропущен
            /// </summary>
            Ignore,
            /// <summary>
            /// Символ удачно преобразован
            /// </summary>
            Accept,
            /// <summary>
            /// Некорректный символ
            /// </summary>
            Incorrect,
            /// <summary>
            /// Очередной символ делает число не преобразуемым
            /// </summary>
            VeryBigDigit,
            /// <summary>
            /// Новая пара координат 
            /// </summary>
            PairDone
        }
    }
}
