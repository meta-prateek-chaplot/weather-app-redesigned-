namespace Weather
{
    interface ISubject
    {
        // This interface handles adding, deleting and updating
        // all observers

        void Register(IObserver o);
        void Unregister(IObserver o);
        void NotifyObserver();
    }
}
