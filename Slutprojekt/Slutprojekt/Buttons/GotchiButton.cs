using System;
using System.Collections.Generic;
using System.Text;

namespace Slutprojekt
{
    class GotchiButton : IButton
    {
        public string iconLocation { get; }

        public GotchiButton(string location)
        {
            iconLocation = location;
        }
    }
}
