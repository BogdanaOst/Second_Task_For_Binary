using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZOO
{

    public abstract class Animal
    {
        public int current_health { get; set; }
        public int max_health { get; protected set; }
        public State current_state { get; set; }
        public string name { get; private set; }
        public string type { get; protected set; }
        
        public Animal(string name, int maxHealth)
        {
            max_health = maxHealth;
            this.name = name;
            current_state = State.full;
            current_health = max_health;            
        }
        public enum State
        {
            full,
            hungry,
            ill,
            dead
        }

        public void Feed()
        {
            if (current_state == State.hungry)
                current_state = State.full;                
        }
        public void Cure()
        {
            if (current_state != State.dead && current_health < max_health)
                current_health++;
            if (current_state == State.ill)
                current_state = State.hungry;
        }
       
        public void ChangeStateNext()
        {

            if (current_state == State.full)
                current_state = State.hungry;
            else
                if (current_state == State.hungry)
                current_state = State.ill;
            else
                if (current_state == State.ill)
            {
                current_health--;
                if (current_health == 0)
                {
                    current_state = State.dead;
                }
            }
        }
    }

}
