using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZOO
{
    public class UserPicker
    {

        const string LINQCommands = "test1 - view all animals grouped by type \n" +
                                    "test2 state - view all animals with picked state \n" +
                                    "test3 - view all ill tigers \n" +
                                    "test4 name - view elephant with picked name \n" +
                                    "test5 - view names of hungry animals \n" +
                                    "test6 - view the healthiest animals in every type \n" +
                                    "test7 - view number of dead animals in every type \n" +
                                    "test8 - view wolfs and bears with 3 and more health \n" +
                                    "test9 - view animals with min and max health \n" +
                                    "test10 - view avg health \n";
        const string types = "( Here are possible types of animals to add: Lion, Bear, Elephant, Fox, Wolf, Tiger )";
        const string commands = "Here are the keys for commands: \n"+
            "help - view this helper again \n"+
            "add name type - add new animal \n"+
             types+"\n"+
            "feed name - feed your animal \n"+
            "cure name - cure your animal \n"+
            "remove - remove from zoo \n"+
            "list - view all animals in zoo \n"+
            "LINQ  - view keys for test LINQ commands \n"+
            "exit - exit \n";
       
        Wrapper wrapper;
        public UserPicker(Wrapper wrapper)
        {
            this.wrapper = wrapper;
            Console.WriteLine("Hello!");
            Console.WriteLine(commands);
        }

       public bool Picker()
        {
            string[] key = (Console.ReadLine()).Split(' ');
            
            switch(key[0])
            {
                case "help":
                    Console.WriteLine(commands);
                    return true;
                case "add":
                    wrapper.Add(key[1], key[2]);
                    return true;
                case "feed":
                    wrapper.Feed(key[1]);
                    return true;
                case "cure":
                    wrapper.Cure(key[1]);
                    return true;
                case "remove":
                    wrapper.Remove(key[1]);
                    return true;
                case "list":
                    foreach (var x in wrapper.animals.GetAll())
                        Console.WriteLine(x.name + " " + x.current_health + " " + x.current_state);
                    return true;
                case "exit":
                    return false;
                case "LINQ":
                    Console.WriteLine(LINQCommands);
                    return true;
                case "test1":
                    wrapper.GetAllGrouppedByType();
                    return true;
                case "test2":
                    
                        if ((key.Count() == 2) && (key[1].ToLower() == "dead" || key[1].ToLower() == "hungry" || key[1].ToLower() == "full" || key[1].ToLower() == "ill"))
                            wrapper.GetByState(key[1]);
                    
                    else
                        Console.WriteLine("Invalid input");
                    return true;
                case "test3":
                    wrapper.GetAllTigers();
                    return true;
                case "test4":
                    if (key.Count() == 2)
                        wrapper.GetElephantByName(key[1]);
                    else
                        Console.WriteLine("Invalid input");
                    return true;
                case "test5":
                    wrapper.GetHungryNames();
                    return true;
                case "test6":
                    wrapper.GetHealthiest();
                    return true;
                case "test7":
                    wrapper.GetNumOfDead();
                    return true;
                case "test8":
                    wrapper.GetWolfsAndBearsWith3moreHealth();
                    return true;
                case "test9":
                    wrapper.GetMaxMinHealth();
                    return true;
                case "test10":
                    wrapper.AvgHealth();
                    return true;
                default:
                    Console.WriteLine("Invalid command :(");
                    return true;
            }

        }
    }
}
