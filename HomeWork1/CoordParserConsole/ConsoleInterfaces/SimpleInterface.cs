using CoordLibrary.InputHandlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace CoordParserConsole.ConsoleInterfaces
{
    partial class SimpleInterface : ConsoleInterface
    {

        private Dictionary<string, Command> _commands = new Dictionary<string, Command>();
        enum UserSkipAnswer
        {
            Yes, No, YesAlways
        }
        private bool _skipAlways = false;
        protected InputHandler _standartHandler = new TextReaderInput(standartNumberFormatInfo, standartCoordinatesDelimiter);
        protected InputHandler _stringHandler = new StringInput(standartNumberFormatInfo, standartCoordinatesDelimiter);

        public SimpleInterface()
        {
            _standartHandler.OnNewPair += OnNewPair;
            _standartHandler.OnIncorrect += _standartHandler_OnIncorrect;
            _standartHandler.OnVeryBigDigit += _standartHandler_OnVeryBigDigit;

            _stringHandler.OnNewPair += OnNewPair;
            _stringHandler.OnIncorrect += _standartHandler_OnIncorrect;
            _stringHandler.OnVeryBigDigit += _standartHandler_OnVeryBigDigit;

            _commands.Add("file", new Command("file", "Format the file", FileHandler));
            _commands.Add("input", new Command("input", "Entering coordinates from the keyboard", EnteringHandler));
            _commands.Add("exit", new Command("exit", "Quit the application", ExitHandler));
            _commands.Add("help", new Command("help", "Display commands", HelpHandler));
        }

        private void _standartHandler_OnVeryBigDigit(InputHandler handler, int line)
        {
            if (_skipAlways) { handler.SkipLine(); return; }
            Console.WriteLine("[ERROR] Line {0}.  VeryBigDigit.", line);
            SkipMessage(handler);
        }

        public override void Main(string[] args)
        {
            Console.WriteLine("Welcome! Type \"help\" to see a list of commands.");
            UserInput();
        }

        private void UserInput()
        {
            string command;
            

            while (true)
            {
                Console.Write(">");
                command = Console.ReadLine();
                command = command.ToLower();
                if (_commands.ContainsKey(command))
                {
                    _commands[command].Act?.Invoke();
                }
                else {
                    Console.WriteLine("Unknown command. Type \"help\" to see the list of commands.");
                }
            }
        }

        private UserSkipAnswer SkipMessage()
        {
            while (true)
            {
                Console.WriteLine("Skip and Continue? y(continue) / n(exit) / ya(continue always)");
                Console.Write(">");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "y":
                        return UserSkipAnswer.Yes;
                    case "n":
                        return UserSkipAnswer.No;
                    case "ya":
                        return UserSkipAnswer.YesAlways;
                    default:
                        break;
                }
                Console.WriteLine("Incorrect input. Try again.");
            }
        }

        private void _standartHandler_OnIncorrect(InputHandler handler, int line, int position, char symbol)
        {
            if (_skipAlways) { handler.SkipLine(); return; }
            Console.WriteLine("[ERROR] Line {0}. Position {1}. Invalid character \"{2}\".", line, position, symbol);
            SkipMessage(handler);
        }

        private void SkipMessage(InputHandler handler)
        {
            switch (SkipMessage())
            {
                case UserSkipAnswer.Yes:
                    handler.SkipLine();
                    break;
                case UserSkipAnswer.No:
                    handler.Stop();
                    break;
                case UserSkipAnswer.YesAlways:
                    _skipAlways = true;
                    handler.SkipLine();
                    break;
                default:
                    break;
            }
        }

        #region Command handlers
        protected void FileHandler()
        {
            string pathToFile;
            while (true) {
                Console.Write("Enter path to file (type \"quit\" for exit): ");
                pathToFile = Console.ReadLine();

                if (pathToFile.ToLower().Equals("quit")) { break; }

                FileInput(pathToFile);
            }
        }

        protected void EnteringHandler()
        {
            string userInput;
            while (true)
            {
                Console.Write("Enter coordinate pairs in the format \"123.45, 123.45, ...\" (type \"quit\" for exit): ");
                userInput = Console.ReadLine();

                if (userInput.ToLower().Equals("quit")) { break; }

                _stringHandler.Parse(userInput);
            }
        }

        protected void ExitHandler()
        {
            Environment.Exit(0);
        }

        protected void HelpHandler()
        {
            Console.WriteLine("Command List");
            foreach (var item in _commands)
            {
                var command = item.Value;

                Console.WriteLine("{0}\t{1}",command.CommandStr,command.Description);

            }
        }
        #endregion

        protected bool FileInput(string filePath)
        {

            try
            {
                filePath = Path.GetFullPath(filePath);

                using (Stream stream = File.OpenRead(filePath))
                {
                    Console.WriteLine("Reading data from a file {0}.", Path.GetFileName(filePath));
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        _standartHandler.Parse(reader);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }
    }
}
