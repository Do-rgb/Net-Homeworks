using System;

namespace CUI.CutDownNotifers
{
    /// <summary>
    ///     •	Создайте три пользовательских класса явно реализующие интерфейс ICutDownNotifier с методами Init() (подписывается
    ///     на событие «таймера») и Run(запускает «таймер»):
    ///     o	Один обрабатывает события с помощью методов;
    /// </summary>
    public class CdnWithMethod : CdnBase
    {
        public CdnWithMethod(string taskName, int taskTime, TaskTimeStart taskTimeStart,
            Action<string, int> taskTimeEnd) :
            base(taskName, taskTime, taskTimeStart, taskTimeEnd)
        {
            ClockOnEverySecond = OnEverySecond;
            ClockOnStart = OnStart;
            ClockOnStop = OnStop;
        }

        private static void OnEverySecond(object sender, int seconds, string title)
        {
            Console.WriteLine($"[{nameof(CdnWithMethod)}] Таймер - {title}. Осталось {seconds} секунд.");
        }

        private static void OnStart(object sender, string title)
        {
            Console.WriteLine($"[{nameof(CdnWithMethod)}] Таймер - {title}. Старт обратного отсчета.");
        }

        private static void OnStop(object sender, string title)
        {
            Console.WriteLine($"[{nameof(CdnWithMethod)}] Таймер - {title}. Обратный отсчет завершен.");
        }
    }
}