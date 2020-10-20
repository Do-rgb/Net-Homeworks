using System;

namespace CUI.CutDownNotifers
{
    /// <summary>
    ///     •	Создайте три пользовательских класса явно реализующие интерфейс ICutDownNotifier с методами Init() (подписывается
    ///     на событие «таймера») и Run(запускает «таймер»):
    ///     o	Третий обрабатывает события с помощью лямбда выражений.
    /// </summary>
    internal class CdnWithLambda : CdnBase
    {
        public CdnWithLambda(string taskName, int taskTime, TaskTimeStart taskTimeStart,
            Action<string, int> taskTimeEnd) :
            base(taskName, taskTime, taskTimeStart, taskTimeEnd)
        {
            ClockOnEverySecond = (sender, seconds, title) =>
            {
                Console.WriteLine($"[{nameof(CdnWithLambda)}] Таймер - {title}. Осталось {seconds} секунд.");
            };

            ClockOnStart = (sender, title) =>
            {
                Console.WriteLine($"[{nameof(CdnWithLambda)}] Таймер - {title}. Старт обратного отсчета.");
            };

            ClockOnStop = (sender, title) =>
            {
                Console.WriteLine($"[{nameof(CdnWithLambda)}] Таймер - {title}. Обратный отсчет завершен.");
            };
        }
    }
}