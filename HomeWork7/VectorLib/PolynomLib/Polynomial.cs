using System;
using System.Collections.Generic;
using System.Text;

namespace PolynomialLib
{
    /// <summary>
    ///     Класс «многочлен» для работы с многочленами от одной переменной
    /// </summary>
    public class Polynomial
    {
        /// <summary>
        ///     Коэффициенты полинома
        /// </summary>
        private readonly List<double> _coefficients;

        public Polynomial(params double[] coefficients)
        {
            _coefficients = new List<double>(coefficients);
        }

        /// <summary>
        ///     Старшая степень полинома
        /// </summary>
        public int HighestDegree => _coefficients.Count;

        /// <summary>
        ///     Доступ к коэффициенту полинома
        /// </summary>
        /// <param name="i">Индекс коэффициента в полиноме</param>
        /// <returns>Коэффициент полинома</returns>
        public double this[int i]
        {
            get
            {
                if (i < 0 || i >= _coefficients.Count) throw new IndexOutOfRangeException();
                return _coefficients[i];
            }
            private set
            {
                if (i < 0 || i >= _coefficients.Count) throw new IndexOutOfRangeException();
                _coefficients[i] = value;
            }
        }

        /// <summary>
        ///     Преобразует полином в строку
        /// </summary>
        /// <returns>Текстовой представление полинома</returns>
        public override string ToString()
        {
            if (HighestDegree < 1) return "0";

            var result = new StringBuilder();

            result.Append(this[0]);

            for (var i = 1; i < HighestDegree; i++)
            {
                if (this[i] == 0) continue;

                result.Append($" + {this[i]}*x^{i}");
            }

            return result.ToString();
        }

        /// <summary>
        ///     Решение полинома с подстановкой x
        /// </summary>
        /// <param name="x">Подставляемое значение</param>
        /// <returns>Получаемый ответ</returns>
        public double GetAnswer(double x)
        {
            var result = this[0];

            for (var i = 1; i < HighestDegree; i++)
                result += this[i] * Math.Pow(x, i);

            return result;
        }

        /// <summary>
        ///     Сравнение степень полиномов
        /// </summary>
        /// <param name="pFirst">Первый полином</param>
        /// <param name="pSecond">Второй полином</param>
        /// <param name="maxPolynomial">Полином с наибольшей степенью</param>
        /// <param name="minPolynomial">Полином с наименьшей степенью</param>
        private static void ComparePolynomials(Polynomial pFirst, Polynomial pSecond, out Polynomial maxPolynomial,
            out Polynomial minPolynomial)
        {
            if (pFirst.HighestDegree > pSecond.HighestDegree)
            {
                maxPolynomial = pFirst;
                minPolynomial = pSecond;
            }
            else
            {
                maxPolynomial = pSecond;
                minPolynomial = pFirst;
            }
        }

        /// <summary>
        ///     Сложение полиномов
        /// </summary>
        /// <param name="pFirst">Первый полином</param>
        /// <param name="pSecond">Второй полином</param>
        /// <returns>Результат сложения двух полиномов</returns>
        public static Polynomial operator +(Polynomial pFirst, Polynomial pSecond)
        {
            ComparePolynomials(pFirst, pSecond, out var maxPolynomial, out var minPolynomial);

            var result = new Polynomial(maxPolynomial._coefficients.ToArray());

            for (var i = 0; i < minPolynomial.HighestDegree; i++) result[i] = minPolynomial[i] + maxPolynomial[i];

            return result;
        }

        /// <summary>
        ///     Вычитание полиномов
        /// </summary>
        /// <param name="pFirst">Первый полином</param>
        /// <param name="pSecond">Второй полином</param>
        /// <returns>Результат вычитания двух полиномов</returns>
        public static Polynomial operator -(Polynomial pFirst, Polynomial pSecond)
        {
            ComparePolynomials(pFirst, pSecond, out var maxPolynomial, out var minPolynomial);

            var result = new Polynomial(maxPolynomial._coefficients.ToArray());

            for (var i = 0; i < minPolynomial.HighestDegree; i++) result[i] = minPolynomial[i] - maxPolynomial[i];

            return result;
        }

        /// <summary>
        ///     Умножение полиномов
        /// </summary>
        /// <param name="pFirst">Первый полином</param>
        /// <param name="pSecond">Второй полином</param>
        /// <returns>Результат умножения полиномов</returns>
        public static Polynomial operator *(Polynomial pFirst, Polynomial pSecond)
        {
            var itemsCount = pFirst._coefficients.Count + pSecond._coefficients.Count - 1;

            var result = new double[itemsCount];

            for (var i = 0; i < pFirst._coefficients.Count; i++)
            for (var j = 0; j < pSecond._coefficients.Count; j++)
                result[i + j] += pFirst[i] * pSecond[j];

            return new Polynomial(result);
        }

        /// <summary>
        ///     Умножение полинома на константу
        /// </summary>
        /// <param name="polynomial">Полином</param>
        /// <param name="multiplier">Константа</param>
        /// <returns>Полином умноженный на константу</returns>
        public static Polynomial operator *(Polynomial polynomial, double multiplier)
        {
            var result = new Polynomial(polynomial._coefficients.ToArray());

            result._coefficients.ForEach(c => c *= multiplier);

            return result;
        }
    }
}