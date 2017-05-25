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
    }
}
