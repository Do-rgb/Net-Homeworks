namespace ConverterLib.Interface
{
    /// <summary>
    ///     •	Определить интерфейс IConvertible, указывающий, что реализующий его класс может конвертировать блок кода в С# или
    ///     VB код. В интерфейсе определить два метода ConvertToCSharp и ConvertToVB, каждый из которых принимает и возвращает
    ///     строку.
    /// </summary>
    public interface IConvertible
    {
        string ConvertToCSharp(string vbInput);
        string ConvertToVB(string cSharpInput);
    }
}