using System;
using System.Collections.Generic;
using System.Text;

namespace Slutprojekt
{
    interface IGotchi
    {
        string name { get; }

        string iconLocation { get; }

        public bool UpdateStatuses(int value);

        public List<int> GetStatuses();
    }
}
