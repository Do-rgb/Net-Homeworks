namespace VectorLib
{
    public interface IMyVector
    {
        /// <summary>
        /// Длина вектора
        /// </summary>
        double Length { get; }
        /// <summary>
        /// X координата вектора
        /// </summary>
        double X { get; }
        /// <summary>
        /// Y координата вектора
        /// </summary>
        double Y { get; }
        /// <summary>
        /// Z координата вектора
        /// </summary>
        double Z { get; }
    }
}