using System;

namespace CoordParserConsole.ConsoleInterfaces
{
    partial class SimpleInterface
    {
        class Command {
            private event Action _act;

            public Action Act => _act;
            public string Description { get; private set; }
            public string CommandStr { get; private set; }

            public Command(string command,string description, Action act) {
                CommandStr = command;
                Description = description;
                _act += act;
            }
        }
    }
}
