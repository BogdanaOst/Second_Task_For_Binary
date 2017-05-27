using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZOO.Command
{
    public class Invoker
    {
        ICommand command;
        public void SetCommand(ICommand command)
        {
            this.command = command;
        }
        public void Run()
        { 
            if(command!=null)
            command.Execute();
        }
    }
}
