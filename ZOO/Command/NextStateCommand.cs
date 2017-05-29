using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZOO.Command
{
    public class NextStateCommand : ICommand
    {
        Animal reciver;

        public NextStateCommand(Animal animal)
        {
            reciver = animal;
        }

        public void Execute()
        {
            if (reciver != null)
                reciver.ChangeStateNext();
        }
    }
}
