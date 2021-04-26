using System;
using System.Collections.Generic;
using System.Text;

namespace Slutprojekt
{
    class Dog : IGotchi, ITired
    {
        public int maxTiredness { get; set; } = 100;

        public string name { get; private set; } = "Gotchi";
        public int tiredness { get; set; } = 0;

        public Dog(string name)
        {
            this.name = name;
        }

        public bool UpdateStatuses(int value)
        {
            return ChangeTiredness(value);
        }

        public bool ChangeTiredness(int value)
        {
            tiredness += value;
            return (tiredness > maxTiredness || tiredness < 0);
        }
    }
}
