using System;
using System.Collections.Generic;
using System.Text;

namespace Observer_Pattern
{
    class User : IUser
    {
        private string _name = "";
        public string GetName()
        {
            return _name;
        }
        public User(string name)
        {
            _name = name;
        }

        public void Notify(string channel, string content)
        {
            Console.WriteLine("Hey " + _name + "! " + channel + ", uploaded content: " + content);
        }
    }
}
