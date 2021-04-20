using System;
using System.Collections.Generic;
using System.Text;

namespace Slutprojekt
{
    class Gotchi : IGotchi, ITired
    {
        private int maxTiredness = 100;

        public string name { get; private set; } = "Gotchi";
        public int tiredness { get; set; } = 0;

        public Gotchi(string name)
        {
            this.name = name;
        }

        public bool ChangeTiredness(int value)
        {
            tiredness += value;
            return (tiredness > maxTiredness || tiredness < 0);
        }
    }
}
