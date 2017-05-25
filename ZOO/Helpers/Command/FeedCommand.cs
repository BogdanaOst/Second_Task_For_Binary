using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZOO.Command
{
    public class FeedCommand:ICommand
    {
        Animal reciver;

    public FeedCommand(Animal animal)
    {
        reciver = animal;
    }

    public void Execute()
    {
        reciver.Feed();
    }
}
}
