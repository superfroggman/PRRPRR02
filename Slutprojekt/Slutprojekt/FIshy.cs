using System;
using System.Collections.Generic;
using System.Text;

namespace Slutprojekt
{
    class Fishy : IGotchi
    {
        public string name { get; private set; } = "Fishy";

        public Fishy(string name)
        {
            this.name = name;
        }

        public bool UpdateStatuses(int value)
        {
            return false;
        }
    }
}
