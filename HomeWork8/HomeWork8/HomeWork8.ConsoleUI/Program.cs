using HomeWork8.MatrixLib;
using InputCheckerLibrary;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace HomeWork8.ConsoleUI
{
    class Program
    {
        class MatrixReader {
            class ErrorInputHandler {
                private int _topPosition;
                private int _maxMessageSize = 0;
                public ErrorInputHandler() {
                    Console.WriteLine();
                    _topPosition = Console.CursorTop-1;
                }

                public void WriteError(string message) {
                    ClearError();
                    SetErrorMessage("[Ошибка] "+message);
                }

                public void ClearError() {
                    if (_maxMessageSize < 1) { return; }
                    StringBuilder clearMessage = new StringBuilder();

                    for (int i = 0; i < _maxMessageSize; i++)
                    {
                        clearMessage.Append(' ');
                    }

                    SetErrorMessage(clearMessage.ToString());
                    _maxMessageSize = 0;
                }

                private void SetErrorMessage(string message) {
                    if (message.Length > _maxMessageSize) {
                        _maxMessageSize = message.Length;
                    }

                    int prevLeft = Console.CursorLeft;
                    int prevTop = Console.CursorTop;
                    Console.SetCursorPosition(0, _topPosition);
                    Console.Write(message);
                    Console.SetCursorPosition(prevLeft, prevTop);
                }
            }

            private bool IsCancel = false;

            public Matrix ReadSize() {
                Console.WriteLine("Введите размер матрицы:");

                Matrix result = null;
                char nextChar;
                StringBuilder digitBuf = new StringBuilder();
                ErrorInputHandler errorInputHandler = new ErrorInputHandler();

                while (!IsCancel) {
                    var consoleKey = Console.ReadKey(true);
                    nextChar = consoleKey.KeyChar;

                    if (nextChar.Equals((char)ConsoleKey.Backspace) && digitBuf.Length >0) {
                        Console.CursorLeft -= 1;
                        Console.Write(' ');
                        Console.CursorLeft -= 1;
                        digitBuf.Remove(digitBuf.Length-1,1);
                        errorInputHandler.ClearError();
                        continue;
                    }

                    digitBuf.Append(nextChar);

                    if (int.TryParse(digitBuf.ToString(), out var digit) && digit > 0)
                    {
                        errorInputHandler.ClearError();
                        Console.Write(nextChar);
                    }
                    else {
                        digitBuf.Remove(digitBuf.Length - 1, 1);
                        
                        if (char.IsDigit(nextChar) && digitBuf.Length>0)
                        {
                            errorInputHandler.WriteError("Указано максимально большое, возможное число.");
                        }
                        else {
                            errorInputHandler.WriteError("Неразрешенный символ " + (((int)nextChar < 33) ? consoleKey.Key.ToString() : nextChar.ToString()) + " Код: " + (int)nextChar);
                        }

                    }

                }

                return result;
            }

            //public void ReadMatrix() {
            //    char nextCh;
            //    while ((nextCh = Console.ReadKey().KeyChar) != EscCode) {
            //        _digitBuffer.Append(nextCh);

            //        if (double.TryParse(_digitBuffer.ToString(), out var digit))
            //        {
            //            if (digit >= double.MaxValue) {
            //                Console.WriteLine("\nВАУ! Вот это число! К сожалению компьютер имеет некоторые ограничения. Приносим извенения. Запись такого большого числа невозможна в этой версии программы.");
            //            }
            //            _consoleBuffer.Append(nextCh);
            //        }
            //        else {
            //            Console.Clear();
            //            Console.Write(_consoleBuffer);
            //            _digitBuffer.Remove(_digitBuffer.Length-1,1);
            //        }
                    
            //        if (nextCh.Equals(WhiteSpaceCode)) {
            //        }
            //    }
            //    Console.WriteLine("END");
            //}

        }
        static void Main(string[] args)
        {
            MatrixReader matrixReader = new MatrixReader();
            matrixReader.ReadSize();
            return;
            ////Просим пользователя ввести матрицу
            //Checker.UserInputVerifiable("Введите 1-ую матрицу, разделяя ввод пробелом (чтобы закончить оставьте строку пустой):", input =>
            //{

            //});
        }
    }
}
