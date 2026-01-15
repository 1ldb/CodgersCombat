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

            

            // Player chooses their fighter
            PlayerController playerController = new PlayerController();
            IFighter plaFighter = playerController.ChooseFighter(fighters.ToArray());

            // Pick a random enemy (not the same as player's choice)
            Random random = new Random();
            IFighter enemyFighter;

            do
            {
                int randomIndex = random.Next(0, fighters.Count);
                enemyFighter = fighters[randomIndex];
            } while (enemyFighter == plaFighter); // Keep picking until it's different

            Console.WriteLine($"Your opponent is: {enemyFighter.Name}\n");

            // Create battle manager and run the battle
            BattleManager battleManager = new BattleManager();
            battleManager.RunBattle(plaFighter, enemyFighter);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}