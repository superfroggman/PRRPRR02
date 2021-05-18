using System;
using System.Collections.Generic;
using System.Text;

namespace Slutprojekt
{
    class Fish : IGotchi, ITiredness, IHunger
    {
        public int maxStatus { get; set; } = 150;
        public string name { get; private set; } = "Fishy";

        public string iconLocation { get; } = "GFX/fish.png";

        public int tiredness { get; private set; } = 0;
        public int hunger { get; private set; } = 0;


        public bool UpdateStatus(int value, int index)
        {
            switch (index)
            {
                case 0:
                    return UpdateTiredness(value);
                case 1:
                    return UpdateHunger(value);
                default:
                    return false;
            }
        }

        public List<int> GetStatuses()
        {
            List<int> list = new List<int>();
            list.Add(tiredness);
            list.Add(hunger);
            return list;
        }

        public Fish(string name)
        {
            this.name = name;
        }

        public bool UpdateStatuses(int value)
        {
            bool die = false;

            for (int i = 0; i < GetStatuses().Count; i++)
            {
                die |= UpdateStatus(value, i);
            }

            return die;
        }

        public bool UpdateTiredness(int value)
        {
            tiredness += value;
            return CheckValue(tiredness);
        }

        public bool UpdateHunger(int value)
        {
            hunger += value;
            return CheckValue(hunger);
        }

        private bool CheckValue(int value)
        {
            return (value > maxStatus || value < 0);
        }
    }
}
