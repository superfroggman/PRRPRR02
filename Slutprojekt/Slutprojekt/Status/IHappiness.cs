using System;
using System.Collections.Generic;
using System.Text;

namespace Slutprojekt
{
    interface IHappiness
    {
        public int happiness { get; }

        public bool UpdateHappiness(int value);
    }
}
