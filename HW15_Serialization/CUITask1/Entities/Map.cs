using System.Collections.Generic;

namespace CUITask1.Entities
{
    /// <summary>
    ///     Какая-либо игровая карта
    /// </summary>
    public class Map
    {
        /// <summary>
        ///     Название карты
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Маркеры отображающиеся только на определенном сервере
        /// </summary>
        public IEnumerable<ServerMarker> ServerMarkers { get; set; }

        /// <summary>
        ///     Маркеры отображающиеся на всех серверах
        /// </summary>
        public IEnumerable<Marker> Global { get; set; }
    }
}