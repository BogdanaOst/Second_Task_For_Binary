using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZOO.AnimalTypes
{
    public class Bear:Animal
    {
        public Bear(string name):base(name, 6)
        {
            type = "bear";
        }
    }
}
