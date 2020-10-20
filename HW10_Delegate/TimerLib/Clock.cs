using System;
using System.Threading;
using System.Threading.Tasks;

namespace TimerLib
{
    /// <summary>
    ///     Разработать класс для имитации часов с обратным отсчетом (таймер), реализующий возможность по истечении
    ///     назначенного времени (количество секунд ожидания, поставляются пользователем) передавать сообщение любому
    ///     подписавшемуся на событие типу.
    /// </summary>
    public class Clock
    {
        private const int MillisecondSize = 1000;
        private int _seconds;

        public Clock(int seconds)
        {
            Seconds = seconds;
        }

        public int Seconds
        {
            get => _seconds;
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException(nameof(Seconds));
                _seconds = value;
            }
        }

        //Пользователь может задавать имя таймера.
        public string Title { get; set; }

        // •	Доработать тип делегата, чтобы получатель события мог определить «источник события» и вывести «имя таймера».
        // •	Добавить событие с отсчётом времени, в котором будет передаваться «сколько секунд осталось».
        // •	Предусмотреть возможность подписки на событие в нескольких классах. ? Не понял, что имено имеется в виду. Сделать модификаторы доступа Public?

        public event Action<object, string> OnStart;
        public event Action<object, string> OnStop;
        public event Action<object, int, string> OnEverySecond;

        public Task Start()
        {
            return Task.Run(() =>
            {
                OnStart?.Invoke(this, Title);

                for (var i = 0; i < _seconds; i++)
                {
                    //Для создания эффекта ожидания использовать метод Thread.Sleep пространства имен System.Threading.
                    Thread.Sleep(MillisecondSize);
                    OnEverySecond?.Invoke(this, _seconds - i, Title);
                }

                OnStop?.Invoke(this, Title);
            });
        }
    }
}