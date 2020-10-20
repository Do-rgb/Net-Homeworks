using ConverterLib.Interface;

namespace ConverterLib
{
    /// <summary>
    ///     •	Создать класс ProgramHelper, реализующий интерфейс IConvertible. При написании методов вместо преобразования
    ///     строки использовать простые строковые сообщения для имитации преобразования.
    /// </summary>
    public class ProgramHelper : ProgramConverter, IConvertible, ICodeChecker
    {
        public bool CheckCodeSyntax(string inputCode, string lang)
        {
            return true;
        }
    }
}