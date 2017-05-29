using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZOO
{
    public interface IRepository
    {
        void Add(Animal animal);
        void Remove(Animal animal);
        Animal FindByName(string name);
        IEnumerable<Animal> GetAll();
        IEnumerable<IGrouping<string, Animal>> GetAllGrouppedByType(); //1
        IEnumerable<Animal> GetByState(string state);//2
        IEnumerable<Animal> GetIllTigers();//3
        Animal GetElephantByName(string name);//4
        IEnumerable<string> GetHungryNames();//5
        IEnumerable< Animal> GetHealthiest();//6
        IEnumerable<KeyValuePair<string, int>> GetNumOfDead();//7
        IEnumerable<Animal> GetWolfsAndBearsWith3moreHealth();//8
        IEnumerable<Animal> GetMaxMinHealth();//9
        double AvgHealth();//10
    }
}
