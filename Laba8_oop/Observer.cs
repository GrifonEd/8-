using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba8_oop
{
    public interface IObserver
    {
        void onSubjectChanged(ISubject subject);
    }

    public interface ISubject
    {
        void addObserver(IObserver observer);

        void removeObserver(IObserver observer);

        void notifyEveryone();
    }
}
