using System;
using System.Dynamic;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace CoordLibrary.Parsers
{
    /// <summary>
    /// Формирует из входящего потока символов координаты
    /// </summary>
    public partial class CoordinateParser
    {
        #region Private area
        /// <summary>
        /// Хранит сформированные координаты
        /// </summary>
        private readonly List<Coordinate> _coordinatesStore = new List<Coordinate>();
        /// <summary>
        /// Временно хранит координаты
        /// </summary>
        private Coordinate _curParsePairCoord;
        /// <summary>
        /// Формирует число из входящего потока символов
        /// </summary>
        private DigitParser _digitParser;
        #endregion
        #region Public area
        /// <summary>
        /// Отдает массив распознанных координат
        /// </summary>
        public Coordinate[] ReceivedCoordinates => _coordinatesStore.ToArray();
        /// <summary>
        /// Хранит настройки парсера координат
        /// </summary>
        public ParserSettings Settings { get; set; }
        #endregion
        /// <summary>
        /// Обрабатывает очередной символ
        /// </summary>
        /// <param name="nextChar">Очередной символ</param>
        /// <returns>Состояние операции преобразования</returns>
        public State AddSymbol(char nextChar)
        {
            //Если обнаружен разделитель или конец файла
            if (Settings.Delimiters.Any(delim => delim.Equals(nextChar)) || nextChar.Equals(char.MinValue))
            {
                //Если до разделителя не обнаружено число
                if (_digitParser == null)
                {
                    return State.Incorrect;
                }

                //Определяет распознанное число как X или Y в паре координат
                if (_curParsePairCoord == null)
                {
                    _curParsePairCoord = new Coordinate
                    {
                        X = _digitParser.ResultDigit
                    };
                }
                else
                {
                    _curParsePairCoord.Y = _digitParser.ResultDigit;
                    //Добавить координаты в хранилище
                    _coordinatesStore.Add(_curParsePairCoord);
                    Clear();
                    return State.PairDone;
                }
                //Очищаем распознанное число
                _digitParser = null;
                return State.Accept;
            }

            //Пропуск незначимых символов
            if (char.IsWhiteSpace(nextChar))
            {
                return State.Ignore;
            }

            if (_digitParser == null)
            {
                _digitParser = new DigitParser() { NumberFormatInfo = Settings.NumberFormat };
            }

            //Формируем число
            return _digitParser.AddChar(nextChar);
        }

        /// <summary>
        /// Сбрасывает состояние парсера координат
        /// </summary>
        public void Clear()
        {
            _curParsePairCoord = null;
            _digitParser = null;
        }
    }
}
