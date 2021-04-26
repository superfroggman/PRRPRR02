using System;
using System.Collections.Generic;
using System.Text;

namespace Slutprojekt
{
    interface ITired : ITiredness
    {
        int maxTiredness { get; set; }

        public bool ChangeTiredness(int value);
    }
}
