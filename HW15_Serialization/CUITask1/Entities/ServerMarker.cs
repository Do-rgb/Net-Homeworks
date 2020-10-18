using System.Collections.Generic;

namespace CUITask1.Entities
{
    /// <summary>
    ///     Маркеры принадлежащие определенному серверу
    /// </summary>
    public class ServerMarker
    {
        /// <summary>
        ///     Адресс сервера
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        ///     Маркеры сервера
        /// </summary>
        public IEnumerable<Marker> Markers { get; set; }
    }
}