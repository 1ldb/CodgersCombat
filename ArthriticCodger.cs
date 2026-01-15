using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodgersCombat
{
    // This class INHERITS from Codger - it gets all Codger's properties and methods
    // The : Codger part means "is a type of Codger"
    public class ArthriticCodger : Codger
    {
        // CONSTRUCTOR - calls the parent class constructor
        public ArthriticCodger(string name, int health, int age) : base(name, health, age)
        {
            // base() calls the Codger constructor
        }

        // OVERRIDE - replace the parent's Attack method with our own special version
        public virtual void Attack(IFighter target)
        {
            Random random = new Random();

            // Arthritic codgers do MORE damage (15-30) because their joints are like weapons!
            int damage = random.Next(15, 31);

            Console.WriteLine($"💢 {Name} locks their arthritic joints around {target.Name}!");
            Console.WriteLine($"   The stiff, creaky bones deal extra damage!");

            // Use TakeDamage method
            target.TakeDamage(damage);

            Console.WriteLine($"{target.Name} takes {damage} damage! Health: {target.Health}\n");
        }

        // Override special ability - extra powerful joint lock
        public override void UseSpecialAbility(IFighter target)
        {
            Random random = new Random();
            int damage = random.Next(25, 40); // Very high damage!

            Console.WriteLine($"💥 {Name} uses ARTHRITIC DEATH GRIP!");
            Console.WriteLine($"   Their locked joints crush {target.Name}!");

            target.TakeDamage(damage);

            Console.WriteLine($"{target.Name} takes {damage} damage! Health: {target.Health}\n");
        }
    }
}
