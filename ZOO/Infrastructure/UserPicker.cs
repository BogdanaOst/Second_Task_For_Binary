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
        const string types = "( Here are possible types of animals to add: Lion, Bear, Elephant, Fox, Wolf, Tiger )";
        const string commands = "Here are the keys for commands: \n"+
            "help - view this helper again \n"+
            "add name type - add new animal \n"+
             types+"\n"+
            "feed name - feed your animal \n"+
            "cure name - cure your animal \n"+
            "remove - remove from zoo \n"+
            "list - view all animals in zoo \n"+
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
                default:
                    Console.WriteLine("Invalid command :(");
                    return true;
            }

        }
    }
}
