using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerEvent
{
    public interface ICutDownNotifier
    {
        void Init();
        void Run();
    }
}
