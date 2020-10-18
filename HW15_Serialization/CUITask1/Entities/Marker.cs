using CUITask1.Enums;

namespace CUITask1.Entities
{
    /// <summary>
    ///     Маркер игрока
    /// </summary>
    public class Marker
    {
        /// <summary>
        ///     Название маркера
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Координаты маркера
        /// </summary>
        public MarkerCoordinate Coordinates { get; set; }

        /// <summary>
        ///     Тип маркера
        /// </summary>
        public MarkerType Type { get; set; }

        /// <summary>
        ///     Размер маркера
        /// </summary>
        public MarkerSize Size { get; set; }
    }
}