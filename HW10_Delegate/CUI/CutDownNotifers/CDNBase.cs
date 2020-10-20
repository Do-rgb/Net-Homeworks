using System;
using TimerLib;
using TimerLib.Interfaces;

namespace CUI.CutDownNotifers
{
    /// <summary>
    ///     •	Создайте три пользовательских класса явно реализующие интерфейс ICutDownNotifier с методами Init() (подписывается
    ///     на событие «таймера») и Run(запускает «таймер»):
    /// </summary>
    public abstract class CdnBase : ICutDownNotifier
    {
        /// <summary>
        ///     •	Создайте делегат «Началось время выполнения задания» с параметрами «Название задачи», «Сколько было отведено
        ///     времени».
        /// </summary>
        /// <param name="taskName"></param>
        /// <param name="secondsToComplete"></param>
        public delegate void TaskTimeStart(string taskName, int secondsToComplete);

        private readonly Clock _taskClock;
        private readonly string _taskName;

        private Clock _jobClock;

        // • В итого каждый из пользовательских класссов должен обрабатывать три события:
        // o Старт обратного отсчёта;
        // o Осталось N-секунд;
        // o Обратный отсчёт завершён. 
        // •	Каждый обработчик должен выводить «имя таймера» в обработчиках события.
        protected Action<object, int, string> ClockOnEverySecond;
        protected Action<object, string> ClockOnStart;
        protected Action<object, string> ClockOnStop;

        private readonly Action<string, int> _taskEnd;
        private readonly TaskTimeStart _taskStart;

        /// <summary>
        ///     •	Конструктов каждого из пользовательских классов, реализующих ICutDownNotifier, должен принимать два параметра:
        ///     o	Созданный делегат «Началось время выполнения задания»;
        ///     o	Делегат «Закончилось время выполнения задания» на основе стандартного типа Action с параметрами «Название
        ///     задачи», «Сколько было отведено времени».
        /// </summary>
        /// <param name="taskName"></param>
        /// <param name="taskTime"></param>
        /// <param name="taskTimeStart"></param>
        /// <param name="taskTimeEnd"></param>
        protected CdnBase(string taskName, int taskTime, TaskTimeStart taskTimeStart, Action<string, int> taskTimeEnd)
        {
            _taskStart = taskTimeStart;
            _taskEnd = taskTimeEnd;

            _taskName = taskName;
            _taskClock = new Clock(taskTime);
            _taskClock.OnStart += TaskClock_OnStart;
            _taskClock.OnStop += TaskClock_OnStop;
        }

        public void Init(Clock clock)
        {
            _jobClock = clock;
            _jobClock.OnStop += ClockOnStop;
            _jobClock.OnStart += ClockOnStart;
            _jobClock.OnEverySecond += ClockOnEverySecond;
        }

        public void Run()
        {
            _taskClock.Start();
            _jobClock.Start();
        }

        private void TaskClock_OnStop(object arg1, string arg2)
        {
            _taskEnd?.Invoke($"[{GetType().Name}] {_taskName}", _taskClock.Seconds);
        }

        private void TaskClock_OnStart(object arg1, string arg2)
        {
            _taskStart?.Invoke($"[{GetType().Name}] {_taskName}", _taskClock.Seconds);
        }
    }
}