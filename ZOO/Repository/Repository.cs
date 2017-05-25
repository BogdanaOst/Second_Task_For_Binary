using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZOO
{
    public class Repository:IRepository
    {
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
    }
}
