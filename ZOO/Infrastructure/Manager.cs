using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZOO.Command;

namespace ZOO
{
    
    public class Manager
    {
        public delegate void AllAreDeadHandler(object s);
        public event AllAreDeadHandler AllAreDeadEvent;

        IRepository animals;
        Timer timer;
        const int period = 5000;

        public Manager(IRepository repository)
        {
            animals = repository;
            timer = new Timer(SetNextState,null, 0, period);
        }

        Animal PickRandomAnimal()
        {
            
                int index = new Random().Next(0, animals.GetAll().Count());
                return (animals.GetAll()).ToList()[index];

        }
        public void SetNextState(object obj)
        {
            Invoker invoker = new Invoker();
            ICommand command = new NextStateCommand(PickRandomAnimal());
            invoker.SetCommand(command);
            invoker.Run();

            if ((animals.GetAll().Where(n => n.current_state!=Animal.State.dead).Count()==0))
            {
                timer.Change(Timeout.Infinite, 0);
                AllAreDeadEvent?.Invoke(this);                
            }

        }
    }
}
