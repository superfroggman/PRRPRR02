using System;
using System.Collections.Generic;
using System.Text;

namespace Slutprojekt
{
    interface ITiredness
    {
        public int tiredness { get; }

        public bool UpdateTiredness(int value);
    }
}
