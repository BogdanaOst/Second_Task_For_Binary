using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZOO.AnimalTypes;

namespace ZOO
{
    public static class Factory
    {
        public static Animal Get(string name, string type)
        {
            switch (type.ToLower())
            {
                case "wolf":
                    return new Wolf(name);
                case "lion":
                    return new Lion(name);
                case "elephant":
                    return new Elephant(name);
                case "fox":
                    return new Fox(name);
                case "tiger":
                    return new Tiger(name);
                case "bear":
                    return new Bear(name);
                default:
                    throw new Exception("Invalid Input");
            }
        }
    }
}
