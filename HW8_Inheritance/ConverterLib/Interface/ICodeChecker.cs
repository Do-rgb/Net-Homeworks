namespace ConverterLib.Interface
{
    /// <summary>
    ///     •	Создать новый интерфейс ICodeChecker, определив в нем метод CheckCodeSyntax, принимающий две строки: строка для
    ///     проверки и используемый язык. Метод должен возвращать тип bool. Добавить в класс ProgramHelper функциональность
    ///     нового интерфейса IСodeChecker
    /// </summary>
    public interface ICodeChecker
    {
        bool CheckCodeSyntax(string inputCode, string lang);
    }
}