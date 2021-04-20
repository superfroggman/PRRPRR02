using System;
using System.Collections.Generic;
using System.Text;

namespace Slutprojekt
{
    interface ITired : ITiredness
    {

        public bool ChangeTiredness(int value);
    }
}
