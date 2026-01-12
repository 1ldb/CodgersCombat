using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodgersCombat
{
    // SINGLE RESPONSIBILITY - This class does ONE thing: manages battles
    public class BattleManager
    {
        // Method to run a battle between two fighters
        public void RunBattle(IFighter fighter1, IFighter fighter2)
        {
            Console.WriteLine($"\n*** {fighter1.Name} vs {fighter2.Name} ***\n");

            // Battle loop
            for (int round = 1; round <= 10; round++)
            {
                Console.WriteLine($"--- ROUND {round} ---");

                // Fighter 1 attacks
                fighter1.Attack(fighter2);

                if (!fighter2.IsAlive())
                {
                    Console.WriteLine($"{fighter2.Name} is knocked out!");
                    break;
                }

                // Fighter 2 attacks
                fighter2.Attack(fighter1);

                if (!fighter1.IsAlive())
                {
                    Console.WriteLine($"{fighter1.Name} is knocked out!");
                    break;
                }
            }

            // Show results
            ShowResults(fighter1, fighter2);
        }

        // Private helper method - only used inside this class
        private void ShowResults(IFighter fighter1, IFighter fighter2)
        {
            Console.WriteLine("\n=== BATTLE OVER ===");
            Console.WriteLine($"{fighter1.Name}: {fighter1.Health} HP remaining");
            Console.WriteLine($"{fighter2.Name}: {fighter2.Health} HP remaining");

            // Announce winner
            if (fighter1.IsAlive() && !fighter2.IsAlive())
                Console.WriteLine($"\n🏆 {fighter1.Name} WINS! 🏆");
            else if (fighter2.IsAlive() && !fighter1.IsAlive())
                Console.WriteLine($"\n🏆 {fighter2.Name} WINS! 🏆");
            else
                Console.WriteLine("\n⚔️ Both fighters survived! ⚔️");
        }
    }
}
