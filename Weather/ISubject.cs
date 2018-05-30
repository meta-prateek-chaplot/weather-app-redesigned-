using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
