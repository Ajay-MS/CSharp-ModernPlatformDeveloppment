using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Packt.Shared
{
    public interface IPlayable
    {
        void play();

        void Pause();

        void stop() {
            WriteLine("Default implementation of the stop.");
        }
    }
}
