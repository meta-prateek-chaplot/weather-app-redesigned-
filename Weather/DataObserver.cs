using System;
using Newtonsoft.Json.Linq;

namespace Weather
{
    // Represents each Observer that is monitoring changes in the subject
    class DataObserver : IObserver
    {
        private JObject jaipurJson;

        // Static used as a counter
        private static int observerIdTracker = 0;

        // Used to track the observers
        private int observerId;

        // Will hold reference to the StockGrabber object
        private ISubject dataSubject;

        public DataObserver(ISubject dataSubject)
        {
            // Store the reference to the dataSubject object so
            // I can make call to its methods
            this.dataSubject = dataSubject;

            // Assign an observer ID and increment the static counter
            this.observerId = ++observerIdTracker;

            // Message notifies user of new observer
            Console.WriteLine("New Observer: " + this.observerId);

            // Add the observer to the Subjects ArrayList
            dataSubject.Register(this);
        }

        public void Update(JObject jaipurJson)
        {
            this.jaipurJson = jaipurJson;

            printThePrices();
        }

        public void printThePrices()
        {
            Console.WriteLine(observerId + "\nJaipur Temp: " + jaipurJson["main"]["temp"]
                                + "\nJaipur Pressure: " + jaipurJson["main"]["pressure"]
                                + "\nJaipur Humidity: " + jaipurJson["main"]["humidity"]);
        }
    }
}
