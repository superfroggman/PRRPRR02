using System;
using System.Collections.Generic;
using System.Text;

namespace Slutprojekt
{
    interface IHunger
    {
        public int hunger { get; }

        public bool UpdateHunger(int value);
    }
}
