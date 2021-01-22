using System;
using System.Collections.Generic;

namespace SOLID_Labb
{
    class Human
    {
        public string name = "";
        public List<Animal> ownedAnimals = new List<Animal>();


        public Human(string inName){
            name = inName;
        }

        public void GainOwnership(Animal animal){
            ownedAnimals.Add(animal);
        }
    }
}