using System;
using System.Collections.Generic;
using System.Text;

namespace Slutprojekt
{
    class FIshy : IGotchi
    {
        public string name { get; private set; } = "Fishy";

        public FIshy(string name)
        {
            this.name = name;
        }
    }
}
