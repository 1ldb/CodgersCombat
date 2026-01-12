using System;
using System.Collections.Generic;

namespace CodgersCombat
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== CODGERS COMBAT ===");
            Console.WriteLine("Welcome to the nursing home arena!\n");

            // Create fighters
            List<IFighter> fighters = new List<IFighter>();

            fighters.Add(new ArthriticCodger("Old Man Jenkins", 100, 87));
            fighters.Add(new DeafCodger("Grandma Ethel", 100, 92));
            fighters.Add(new Codger("Regular Joe", 100, 85));
            fighters.Add(new ArthriticCodger("Stiff Sally", 100, 89));
            fighters.Add(new ForgetfulCodger("Confused Carl", 100, 90));

            // Show all fighters
            Console.WriteLine("FIGHTERS ENTERING THE ARENA:");
            foreach (IFighter fighter in fighters)
            {
                fighter.Introduce();
            }

            // Pick two random fighters
            Random random = new Random();
            int index1 = random.Next(0, fighters.Count);
            int index2 = random.Next(0, fighters.Count);

            while (index2 == index1)
            {
                index2 = random.Next(0, fighters.Count);
            }

            IFighter fighter1 = fighters[index1];
            IFighter fighter2 = fighters[index2];

            // Create battle manager and run the battle
            BattleManager battleManager = new BattleManager();
            battleManager.RunBattle(fighter1, fighter2);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}