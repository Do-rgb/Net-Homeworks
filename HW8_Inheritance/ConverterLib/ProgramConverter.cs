using ConverterLib.Interface;

namespace ConverterLib
{
    /// <summary>
    ///     •	Создать класс ProgramConverter, реализующий интерфейс IConvertible. Изменить класс ProgramHelper, наследуя его от
    ///     класса ProgramConverter и интерфейса ICodeChecker.
    /// </summary>
    public class ProgramConverter : IConvertible
    {
        public string ConvertToCSharp(string vbInput)
        {
            return "CSharp code output";
        }

        public string ConvertToVB(string cSharpInput)
        {
            return "VB code output";
        }
    }
}