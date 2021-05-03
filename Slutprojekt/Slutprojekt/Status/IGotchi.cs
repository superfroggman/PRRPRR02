using System;
using System.Collections.Generic;
using System.Text;

namespace Slutprojekt
{
    interface IGotchi
    {
        string name { get; }

        public bool UpdateStatuses(int value);

        public List<int> GetStatuses();
    }
}
