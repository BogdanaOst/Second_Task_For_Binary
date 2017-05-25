using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZOO.AnimalTypes;

namespace ZOO
{
    class Program
    {
        static void Main(string[] args)
        {
                Wrapper wrapper = new Wrapper();
                UserPicker picker = new UserPicker(wrapper);

            bool checker = true;
            while (checker)
            {
                try
                {
                    checker=picker.Picker();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
