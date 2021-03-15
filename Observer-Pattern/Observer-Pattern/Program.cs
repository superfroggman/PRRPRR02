using System;
using System.Collections.Generic;

namespace Observer_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Channel> channels = new List<Channel>();
            //channels.Add(new Channel("pewdiepie"));

            Channel pewdiepie = new Channel("pewdiepie");

            User anton = new User("anton");
            User svant = new User("svant");

            pewdiepie.Subscribe(anton);

            pewdiepie.AddContent("Happy wheels #731 GONE WRONG");
            
        }
    }
}
