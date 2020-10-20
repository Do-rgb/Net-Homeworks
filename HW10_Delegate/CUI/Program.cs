using System;
using System.Threading.Tasks;
using CUI.CutDownNotifers;
using TimerLib;
using TimerLib.Interfaces;

namespace CUI
{
    internal class Program
    {
        private static readonly string _taskName = "Домашняя работа";
        private static readonly int _taskTime = 5;

        private static void Main()
        {
            Clock[] clocks =
            {
                new Clock(5) {Title = "Чтение задания"},
                new Clock(5) {Title = "Выполнение задания"},
                new Clock(5) {Title = "Проверка задания перед отправкой"}
            };

            ICutDownNotifier[] notifiers =
            {
                new CdnWithMethod(_taskName, _taskTime, TaskStart, TaskEnd),
                new CdnWithAnonDelegate(_taskName, _taskTime, TaskStart, TaskEnd),
                new CdnWithLambda(_taskName, _taskTime, TaskStart, TaskEnd)
            };

            for (var i = 0; i < notifiers.Length && i < clocks.Length; i++) notifiers[i].Init(clocks[i]);

            Parallel.For(0, notifiers.Length, i => { notifiers[i].Run(); });

            Console.WriteLine("Нажмите любую клавишу, чтобы выйти.");
            Console.ReadKey();
        }

        //•	Создайте в приложении методы, который будет информировать о начале и завершении времени выполнения заданий, и передавайте их в конструкторы «пользовательских классов».
        private static void TaskEnd(string taskName, int taskTime)
        {
            Console.WriteLine(
                $"{taskName}. Закончилось время выполнения задания. Было отведено времени: {taskTime} секунд.");
        }

        private static void TaskStart(string taskName, int taskTime)
        {
            Console.WriteLine($"{taskName}. Началось время выполнения задания. Отведено времени: {taskTime} секунд.");
        }
    }
}