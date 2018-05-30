using System;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace Weather
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Create the Subject object
            // It will handle updating all observers
            // as well as deleting and adding them
            DataSubject dataSubject = new DataSubject();

            // Create an Observer that will be sent updates from Subject
            DataObserver observer1 = new DataObserver(dataSubject);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
