using System;
using System.Collections;
using Newtonsoft.Json.Linq;

namespace Weather
{
    // Uses the ISubject interface to update all Observers
    class DataSubject : ISubject
    {
        private ArrayList observers;
        private JObject jaipurJson;

        public DataSubject() =>
            // Creates an ArrayList to hold all observers
            observers = new ArrayList();

        public void Register(IObserver newObserver) =>
            // Adds a new observer to the ArrayList
            observers.Add(newObserver);

        public void Unregister(IObserver deleteObserver)
        {
            // Get the index of the observer to delete
            int observerIndex = observers.IndexOf(deleteObserver);

            // Print out message (Have to increment index to match)
            Console.WriteLine("Observer: " + (observerIndex + 1) + " deleted!");

            // Removes observer from the ArrayList
            observers.RemoveAt(observerIndex);
        }

        public void NotifyObserver()
        {
            // Cycle through all observers and notifies them of
            // price changes
            foreach (IObserver observer in observers)
            {
                observer.Update(jaipurJson);
            }
        }

        public void SetJson(JObject newjaipurJson)
        {
            this.jaipurJson = newjaipurJson;
            NotifyObserver();
        }
    }
}
