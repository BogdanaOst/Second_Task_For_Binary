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



        public void GetAllGrouppedByType()
        {
            var output = animals.GetAllGrouppedByType();
            if (output.Count()==0) Console.WriteLine("No animals at all :("); else
            foreach(IGrouping<string,Animal> a in output)
            {
                Console.WriteLine(a.Key+" :");
                foreach (var x in a)
                    Console.WriteLine(x.name);
            }
        }

        public void GetByState(string state)
        {
            var output = animals.GetByState(state);
            if (output.Count() == 0 || animals.GetAll().Count()==0)
                Console.WriteLine("Any {0} animals", state);
            else
            {
                Console.WriteLine("Your " + state + " animals");
                foreach (var x in output)
                    Console.WriteLine(x.type + " " + x.name);
            }
        }

        public void GetAllTigers()
        {
            var output = animals.GetIllTigers();
            if (output.Count() == 0) Console.WriteLine("Any ill tigers");
            else
            {
                Console.WriteLine("Your ill tigers:");
                foreach (var a in output)
                {
                    Console.WriteLine(a.name);
                }
            }
        }

        public void GetElephantByName(string name)
        {
            
            var elephant = animals.GetElephantByName(name);
            if (elephant != null)
            {
                Console.WriteLine("This is info about elephant named " + name + " :");
                Console.WriteLine("it's " + elephant.current_state + ", health is " + elephant.current_state);
            }
            else
                Console.WriteLine("Any elephants named " + name);
        }
        
        public void GetHungryNames()
        {
            var list = animals.GetHungryNames();
            Console.WriteLine("They are hungry: ");
            if (list.Count() == 0) Console.WriteLine("Nobody"); else
            foreach (var x in list)
                Console.WriteLine(x);
        }
        public void GetHealthiest()
        {
            var output = animals.GetHealthiest();
            foreach (var x in output)
            {
               
                    Console.WriteLine("The healthiest from {0}s is {1} with {2} health ",x.type, x.name, x.current_health);
            }
        }
        public void GetNumOfDead()
        {
            var groups = animals.GetNumOfDead();

            foreach(var g in groups)
            {

                Console.WriteLine("{0} dead {1}s", g.Value, g.Key);
            }
        }

        public void GetWolfsAndBearsWith3moreHealth()
        {
            Console.WriteLine("Wolf and bears with 3 or more health:");
            var output = animals.GetWolfsAndBearsWith3moreHealth();
            if (output.Count() == 0) Console.WriteLine("Any"); else
            foreach (var a in output)
                Console.WriteLine(a.type + " named " + a.name + ", health: " + a.current_health);
        }
        public void GetMaxMinHealth()
        {

            var output = (animals.GetMaxMinHealth()).ToList();
            if (output.Count() == 0) Console.WriteLine("Any animals at all :(");
            else
            {
                Console.WriteLine("{0} named {1} has min health: {2}", output[0].type, output[0].name, output[0].current_health);
                Console.WriteLine("{0} named {1} has max health: {2}", output[1].type, output[1].name, output[1].current_health);
            }
        }
        public void AvgHealth()
        {
            if (animals.GetAll().Count() == 0) Console.WriteLine("Any animals at all :(");
            else
            {
                var output = animals.AvgHealth();
                Console.WriteLine("Avg health is " + output);
            }
        }
    }
}
