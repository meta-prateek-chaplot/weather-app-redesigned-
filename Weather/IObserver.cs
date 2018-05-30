using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Weather
{
    interface IObserver
    {
        // The Observers update method is called when the Subject changes
        void Update(JObject jaipurJson);
    }
}
