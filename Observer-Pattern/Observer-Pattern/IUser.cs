using System;
using System.Collections.Generic;
using System.Text;

namespace Observer_Pattern
{
    interface IUser
    {
        void Notify(string channel, string content);
    }
}
