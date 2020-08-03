using System;
using System.IO;

namespace CoordParserConsole.ConsoleInterfaces
{
    class ArgumentsInterface : SimpleInterface
    {
        public override void Main(string[] args)
        {
            foreach (var arg in args)
            {
                //Определить тип переданного аргумента (путь до файла/пользовательский ввод)
                try
                {
                    string filePath = Path.GetFullPath(arg);
                    if (File.Exists(filePath)) {
                        FileInput(filePath);
                        continue;
                    }
                }
                catch {
                }
                //Обработка пользовательского ввода
                _stringHandler.Parse(arg);
            }
            base.Main(args);
        }
    }
}
