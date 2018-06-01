using Newtonsoft.Json.Linq;

namespace Weather
{
    interface IObserver
    {
        // The Observers update method is called when the Subject changes
        void Update(JObject jaipurJson);
    }
}
