using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZOO.Command
{
    public class CureCommand : ICommand
    {
        Animal reciver;

        public CureCommand(Animal animal)
        {
            reciver = animal;
        }

        public void Execute()
        {
            reciver.Cure();
        }
    }
}
