using System;
using System.Collections.Generic;
using System.Text;

namespace Slutprojekt
{
    interface IGotchi
    {
        string name { get; }
        public int maxStatus { get; set; }

        string iconLocation { get; }

        public bool UpdateStatuses(int value);

        public bool UpdateStatus(int value, int index);

        public List<int> GetStatuses();
    }
}
