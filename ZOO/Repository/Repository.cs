using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZOO
{
    public class Repository : IRepository
    {
        #region 
        private List<Animal> animals = new List<Animal>();

        public void Add(Animal animal)
        {
            animals.Add(animal);
        }

        public void Remove(Animal animal)
        {
            animals.Remove(animal);
        }

        public Animal FindByName(string name)
        {
            return animals.Find(n => n.name == name);
        }
        public IEnumerable<Animal> GetAll()
        {
            return animals.AsReadOnly();
        }
        #endregion
        public IEnumerable<IGrouping<string, Animal>> GetAllGrouppedByType()//1
        {
            var result = from a in animals
                         group a by a.type;
            return result;
        }
        public IEnumerable<Animal> GetByState(string state)//2
        {
            var result = animals.Where(x => x.current_state.ToString().ToLower() == state.ToLower());           
            return result;
        }
        public IEnumerable<Animal> GetIllTigers()//3
        {
            var result = animals.Where(x => x.type == "tiger" && x.current_state == Animal.State.ill);              
            return result;
        }

        public Animal GetElephantByName(string name)//4
        {
            var result = animals.Where(x => x.type == "elephant" && x.name == name).FirstOrDefault();  
            return result;
        }
        public IEnumerable<string> GetHungryNames()//5
        {
            var result = from a in animals
                         where a.current_state == Animal.State.hungry
                         select a.name;
            return result;
        }
     
        public IEnumerable<Animal> GetHealthiest()//6
        {
            var result = animals.GroupBy(a => a.type).
                         Select(f => (f.OrderByDescending(x => x.current_health)).First());
            
            return result;
        }
        public IEnumerable<KeyValuePair<string, int>> GetNumOfDead()//7
        {
            var result = animals.GroupBy(o => o.type)
                .Select(gr => new
                    KeyValuePair<string, int>(gr.Key, gr.Where(a => a.current_state == Animal.State.dead).Count()));
            return result; 
        }
        public IEnumerable<Animal> GetWolfsAndBearsWith3moreHealth()//8
        {
            var result = animals.Where(x => ((x.type == "wolf" || x.type == "bear") && x.current_health >= 3));
            return result;
        }
        public IEnumerable<Animal> GetMaxMinHealth()//9
        {
            
            var result = (animals.OrderBy(a => a.current_health).
                Take(1).
                Concat
                (animals.OrderByDescending(a => a.current_health).Take(1)));
            return result;            
                
        }

        public double AvgHealth()//10
        {
            var result = animals.Average(a => a.current_health);
            return result;
        }
    }
}
