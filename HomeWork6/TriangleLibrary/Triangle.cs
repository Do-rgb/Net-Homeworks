using System;

namespace TriangleLibrary
{
    /// <summary>
    /// Описывает треугольник имеющий стороны A,B,C. Его площадь и периметр.
    /// </summary>
    public class Triangle
    {
        /// <summary>
        /// Сторона A
        /// </summary>
        public decimal A { get; }
        /// <summary>
        /// Сторона B
        /// </summary>
        public decimal B { get; }
        /// <summary>
        /// Сторона C
        /// </summary>
        public decimal C { get; }
        /// <summary>
        /// Периметр
        /// </summary>
        public decimal Perimeter { get; }
        /// <summary>
        /// Площадь
        /// </summary>
        public decimal Area { get; }

        /// <summary>
        /// Проверяет переданные аргументы на корректность и создает экземпляр класса Triangle
        /// </summary>
        /// <param name="aSide">Сторона A</param>
        /// <param name="bSide">Сторона B</param>
        /// <param name="cSide">Сторона C</param>
        /// <param name="triangle">Экземпляр класса Triangle</param>
        /// <returns>Результат проверки переданных сторон треугольника на корректность</returns>
        public static bool TryCreate(decimal aSide, decimal bSide, decimal cSide, out Triangle triangle)
        {
            if (aSide > 0
                && bSide > 0
                && cSide > 0
                && aSide + bSide > cSide
                && aSide + cSide > bSide
                && bSide + cSide > aSide)
            {
                triangle = new Triangle(aSide, bSide, cSide);
                return true;
            }

            triangle = null;
            return false;
        }

        private Triangle(decimal aSide, decimal bSide, decimal cSide)
        {
            A = aSide;
            B = bSide;
            C = cSide;

            Perimeter = A + B + C;

            //Площадь треугольника считается по формуле Герона
            //p - полупериметр
            var p = Perimeter / 2;
            Area = (decimal)Math.Sqrt(decimal.ToDouble(p * (p-A) * (p-B) * (p-C)));
        }
    }
}
