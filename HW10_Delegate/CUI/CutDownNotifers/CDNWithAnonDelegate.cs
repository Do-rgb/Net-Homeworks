using System;

namespace CUI.CutDownNotifers
{
    /// <summary>
    ///     •	Создайте три пользовательских класса явно реализующие интерфейс ICutDownNotifier с методами Init() (подписывается
    ///     на событие «таймера») и Run(запускает «таймер»):
    ///     o	Второй обрабатывает события с помощью анонимных делегатов;
    /// </summary>
    internal class CdnWithAnonDelegate : CdnBase
    {
        public CdnWithAnonDelegate(string taskName, int taskTime, TaskTimeStart taskTimeStart,
            Action<string, int> taskTimeEnd) :
            base(taskName, taskTime, taskTimeStart, taskTimeEnd)
        {
            ClockOnEverySecond = delegate(object sender, int seconds, string title)
            {
                Console.WriteLine($"[{nameof(CdnWithAnonDelegate)}] Таймер - {title}. Осталось {seconds} секунд.");
            };

            ClockOnStart = delegate(object sender, string title)
            {
                Console.WriteLine($"[{nameof(CdnWithAnonDelegate)}] Таймер - {title}. Старт обратного отсчета.");
            };

            ClockOnStop = delegate(object sender, string title)
            {
                Console.WriteLine($"[{nameof(CdnWithAnonDelegate)}] Таймер - {title}. Обратный отсчет завершен.");
            };
        }
    }
}