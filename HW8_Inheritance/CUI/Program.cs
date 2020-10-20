using System;
using ConverterLib;
using ConverterLib.Interface;

namespace CUI
{
    internal class Program
    {
        /// <summary>
        ///     •	Протестировать класс, создав массив объектов ProgramConverter, одни из которых имеют тип ProgramConverter, а
        ///     другие – тип ProgramHelper. Для каждого элемента массива проверить, что он реализуют интерфейс IСodeChecker, или
        ///     нет. Если реализует интерфейс IСodeChecker, то вызвать метод проверки кода, и сответствующий метод метод
        ///     преобразования. Если не реализует интерфейс IСodeChecker, то вызвать два метода преобразования кода.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
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
                    Console.WriteLine($"Найден элемент - наследник {nameof(ICodeChecker)}");
                    if (checker.CheckCodeSyntax(CSharpCode, "CSharp"))
                    {
                        var vbCode = converter.ConvertToVB(CSharpCode);
                        Console.WriteLine("Конвертация прошла успешно.");
                    }
                }
                else
                {
                    Console.WriteLine($"Элемент не является наследником {nameof(ICodeChecker)}");
                    converter.ConvertToCSharp(VBCode);
                    converter.ConvertToVB(CSharpCode);
                    Console.WriteLine("Конвертация прошла успешно.");
                }

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}