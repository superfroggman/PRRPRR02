using System;
using System.Collections.Generic;
using System.Text;

namespace Slutprojekt
{
    class Dog : IGotchi, ITiredness
    {
        public int maxStatus { get; set; } = 100;

        public string name { get; private set; } = "Gotchi";
        public int tiredness { get; set; } = 0;

        public Dog(string name)
        {
            this.name = name;
        }

        public bool UpdateStatuses(int value)
        {
            bool die = false;

            tiredness += value;
            die |= CheckValue(tiredness);

            return die;
        }

        public List<int> GetStatuses()
        {
            List<int> list = new List<int>();
            list.Add(tiredness);
            return list;
        }

        private bool CheckValue(int value)
        {
            return (value > maxStatus || value < 0);
        }
    }
}
