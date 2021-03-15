using System;
using System.Collections.Generic;
using System.Text;

namespace Observer_Pattern
{
    class Channel : IChannel
    {
        private string _name = "";
        public string GetName()
        {
            return _name;
        }

        public Channel(string name)
        {
            _name = name;
        }

        private List<User> subsribers = new List<User>();
        public void Subscribe(User user)
        {
            subsribers.Add(user);
        }

        public void Unsubscribe(User user)
        {
            subsribers.Remove(user);
        }

        public List<string> contents = new List<string>();
        public void AddContent(string content)
        {
            contents.Add(content);

            foreach(var user in subsribers)
            {
                user.Notify(_name, content);
            }
        }
        
    }
}
