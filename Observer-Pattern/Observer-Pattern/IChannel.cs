using System;
using System.Collections.Generic;
using System.Text;

namespace Observer_Pattern
{
    interface IChannel
    {
        void Subscribe(User user);

        void Unsubscribe(User user);

        void AddContent(string content);
    }
}
