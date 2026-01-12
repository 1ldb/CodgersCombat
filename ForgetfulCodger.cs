using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodgersCombat
{
    // ForgetfulCodger - sometimes forgets what they're doing!
    public class ForgetfulCodger : Codger
    {
        public ForgetfulCodger(string name, int health, int age) : base(name, health, age)
        {
        }

        // OVERRIDE Attack - 40% chance to forget and not attack at all!
        public override void Attack(IFighter target)
        {
            Random random = new Random();
            int chance = random.Next(1, 101); // 1-100

            // 40% chance to forget to attack
            if (chance <= 40)
            {
                Console.WriteLine($"🤔 {Name} stares blankly... 'Wait, what was I doing?'");
                Console.WriteLine($"   {Name} forgot to attack!\n");
                return; // Exit the method without attacking
            }

            // Normal attack if they remember
            int damage = random.Next(12, 22);
            Console.WriteLine($"{Name} remembers just in time and attacks {target.Name}!");

            target.TakeDamage(damage);

            Console.WriteLine($"{target.Name} takes {damage} damage! Health: {target.Health}\n");
        }
    }
}
