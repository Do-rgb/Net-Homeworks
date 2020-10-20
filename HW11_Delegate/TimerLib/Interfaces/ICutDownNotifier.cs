namespace TimerLib.Interfaces
{
    /// <summary>
    ///     •	интерфейс ICutDownNotifier с методами Init() (подписывается на событие «таймера») и Run(запускает «таймер»):
    /// </summary>
    public interface ICutDownNotifier
    {
        void Init(Clock clock);
        void Run();
    }
}