using System;
using System.Linq;
using System.Threading;
using ZOO.Command;
namespace ZOO
{
    public class Wrapper
    {
        Manager counter;

        public IRepository animals { get; private set; }
        private void Ender(object s)
        {
            Console.WriteLine("Game over! All animals are dead :(");
            Thread.Sleep(10000);
            Environment.Exit(0);
        }

        public Wrapper()
        {
            animals = new Repository();
            
        }

        public void Add(string name, string type)
        {
            if (animals.FindByName(name) == null)
            {
                animals.Add(Factory.Get(name, type));
                if (animals.GetAll().Count() == 1)
                {
                    counter = new Manager(animals);
                    counter.AllAreDeadEvent += Ender;
                }
                Console.WriteLine(name + " was added to the zoo");
            }
            else Console.WriteLine("You already have " + name + " in your zoo");
        }

        public void Feed(string name)
        {
            var geted_animal = animals.FindByName(name);
            if (geted_animal == null) { Console.WriteLine("You don't have " + name + " in your zoo"); return; }
            FeedCommand command = new FeedCommand(geted_animal);
            Invoker invoker = new Invoker();
            
            invoker.SetCommand(command);
            invoker.Run();
            Console.WriteLine(name + " was feeded");
        }

        public void Cure(string name)
        {
            var geted_animal = animals.FindByName(name);
            if (geted_animal == null) { Console.WriteLine("You don't have " + name + " in your zoo"); return; }

            CureCommand command = new CureCommand(animals.FindByName(name));
            Invoker invoker = new Invoker();
         
            invoker.SetCommand(command);
            invoker.Run();
            Console.WriteLine(name + " was cured");
        }

        public void Remove(string name)
        {
            var animal = animals.FindByName(name);

            if (animal != null && animal.current_state == Animal.State.dead)
            {
                animals.Remove(animal);
                Console.WriteLine(name + " was removed");
            }
            else
                Console.WriteLine("You can remove only dead animal");

        }
    }
}
