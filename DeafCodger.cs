using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodgersCombat
{
    // DeafCodger inherits from Codger
    public class DeafCodger : Codger
    {
        // CONSTRUCTOR
        public DeafCodger(string name, int health, int age) : base(name, health, age)
        {
        }

        // OVERRIDE Attack - Deaf codgers attack normally but with confusion
        public virtual void Attack(IFighter target)
        {
            Random random = new Random();
            int damage = random.Next(8, 18); // Slightly weaker attacks

            Console.WriteLine($"👂 {Name} yells 'WHAT?!' and swings wildly at {target.Name}!");

            target.TakeDamage(damage);

            Console.WriteLine($"{target.Name} takes {damage} damage! Health: {target.Health}\n");
        }

        // NEW METHOD - Override TakeDamage to sometimes ignore attacks!
        public new void TakeDamage(int damage)
        {
            Random random = new Random();
            int chance = random.Next(1, 101); // Random number 1-100

            // 30% chance to "not hear" the attack and take half damage
            if (chance <= 30)
            {
                int reducedDamage = damage / 2;
                Console.WriteLine($"   💭 {Name} didn't hear that coming! Takes only {reducedDamage} damage!");
                base.TakeDamage(reducedDamage); // Call parent's TakeDamage
            }
            else
            {
                base.TakeDamage(damage); // Normal damage
            }
        }
    }
}
