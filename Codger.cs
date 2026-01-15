using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodgersCombat
{
    // This is a blueprint for creating old fighters
    public class Codger : IFighter
    {
        // PRIVATE fields - hidden from outside access
        private string name;
        private int health;
        private int age;
        private bool isDefending;
        public bool IsDefending
        {
            get { return isDefending; }
        }

        // PUBLIC properties - controlled access to private fields
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public int Health
        {
            get { return health; }
            protected set
            {
                // Can't go below 0 or above 100
                if (value < 0)
                    health = 0;
                else if (value > 100)
                    health = 100;
                else
                    health = value;
            }
        }
        public int Age
        {
            get { return age; }
            private set { age = value; }
        }

        // This checks if the codger is still alive
        public bool IsAlive()
        {
            return Health > 0;
        }

        public void TakeDamage(int damage)
        {
            // If defending, reduce damage by 50%
            if (isDefending)
            {
                damage = damage / 2;
                Console.WriteLine($"   🛡️ {Name} blocks! Damage reduced to {damage}!");
            }

            Health = Health - damage;
        }

        // NEW: Defend reduces damage taken
        public void Defend()
        {
            isDefending = true;
            Console.WriteLine($"🛡️ {Name} takes a defensive stance!");
        }

        // NEW: Reset defense at start of turn
        public void ResetDefense()
        {
            isDefending = false;
        }

        // NEW: Special ability - each codger type will override this
        public virtual void UseSpecialAbility(IFighter target)
        {
            Console.WriteLine($"{Name} has no special ability!");
        }

        // CONSTRUCTOR - this runs when we create a new codger
        public Codger(string name, int health, int age)
        {
            Name = name;
            Health = health;
            Age = age;
        }

        // METHOD - this is something a codger can DO
        public void Introduce()
        {
            Console.WriteLine($"Greetings! I'm {Name}, age {Age}.");
            Console.WriteLine($"I've got {Health} health points left in these old bones!\n");
        }

        // NEW METHOD - attack another codger!
        // VIRTUAL means child classes can replace this method
        public virtual void Attack(IFighter target)
        {
            // Create a random number generator
            Random random = new Random();

            // Damage is now random between 10 and 20
            int damage = random.Next(10, 21);

            Console.WriteLine($"{Name} attacks {target.Name} with a cane swing!");

            // Use TakeDamage method instead of directly modifying Health
            target.TakeDamage(damage);

            Console.WriteLine($"{target.Name} takes {damage} damage! Health: {target.Health}\n");
        }
    }
}
