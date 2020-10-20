using ConverterLib;
using ConverterLib.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ProgramConverterTests
    {
        /// <summary>
        ///     •	Протестировать класс, создав массив объектов ProgramConverter, одни из которых имеют тип ProgramConverter,
        ///     а другие – тип ProgramHelper. Для каждого элемента массива проверить, что он реализуют интерфейс IСodeChecker,
        ///     или нет. Если реализует интерфейс IСodeChecker, то вызвать метод проверки кода, и сответствующий метод метод
        ///     преобразования.
        ///     Если не реализует интерфейс IСodeChecker, то вызвать два метода преобразования кода.
        /// </summary>
        [TestMethod]
        public void Run()
        {
            var CSharpCode = "SOME COOL C# CODE";
            var VBCode = "SOME COOL VB CODE";

            var converters = new[]
            {
                new ProgramConverter(),
                new ProgramHelper()
            };

            foreach (var converter in converters)
                if (converter is ICodeChecker checker)
                {
                    if (checker.CheckCodeSyntax(CSharpCode, "CSharp"))
                    {
                        var vbCode = converter.ConvertToVB(CSharpCode);
                    }
                }
                else
                {
                    converter.ConvertToCSharp(VBCode);
                    converter.ConvertToVB(CSharpCode);
                }
        }
    }
}