using System;
using Newtonsoft.Json.Linq;

namespace Weather
{
    // Represents each Observer that is monitoring changes in the subject
    class DataObserver : IObserver
    {
        private JObject jaipurJson;

        // Will hold reference to the StockGrabber object
        private ISubject dataSubject;

        public DataObserver(ISubject dataSubject)
        {
            // Store the reference to the dataSubject object so
            // I can make call to its methods
            this.dataSubject = dataSubject;

            // Add the observer to the Subjects ArrayList
            dataSubject.Register(this);
        }

        public void Update(JObject jaipurJson)
        {
            this.jaipurJson = jaipurJson;

            // printThePrices();
            AsyncPush();
        }

        async static void AsyncPush()
        {
            //await
        }

        public void printThePrices()
        {
            Console.WriteLine("\nJaipur Temp: " + jaipurJson["main"]["temp"]
                                + "\nJaipur Pressure: " + jaipurJson["main"]["pressure"]
                                + "\nJaipur Humidity: " + jaipurJson["main"]["humidity"]);
        }
    }
}
