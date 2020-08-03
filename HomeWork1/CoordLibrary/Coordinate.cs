namespace CoordLibrary
{
    /// <summary>
    /// Хранит координаты X и Y
    /// </summary>
    public class Coordinate
    {
        /// <summary>
        /// Координата X
        /// </summary>
        public decimal X { get; set; }
        /// <summary>
        /// Координата Y
        /// </summary>
        public decimal Y { get; set; }

        /// <summary>
        /// Форматирует координаты в нужый вид
        /// </summary>
        /// <returns>Строка содержащая отформатированные координаты</returns>
        public string ToFormatedString() {
            return string.Format("X: {0} Y: {1}",X,Y);
        }
    }
}
