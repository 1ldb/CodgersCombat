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

        private PlayerController playerController;
        private AIController aiController;


        public BattleManager()
        {
            playerController = new PlayerController();
            aiController = new AIController();
        }


        // Method to run a battle between two fighters
        public void RunBattle(IFighter fighter1, IFighter fighter2)
        {
            Console.WriteLine($"\n*** {fighter1.Name} vs {fighter2.Name} ***\n");

            // Battle loop
            for (int round = 1; round <= 10; round++)
            {
                Console.WriteLine($"--- ROUND {round} ---");

                fighter1.ResetDefense();
                fighter2.ResetDefense();

                CombatAction action = playerController.ChooseAction();

                switch (action)
                {
                    case CombatAction.Attack:
                        fighter1.Attack(fighter2);
                        break;
                    case CombatAction.Defend:
                        fighter1.Defend();
                        break;
                    case CombatAction.SpecialAbility:
                        fighter1.UseSpecialAbility(fighter2);
                        break;
                }



                CombatAction aiAction = aiController.ChooseAction(fighter2, fighter1);

                switch (aiAction)
                {
                    case CombatAction.Attack:
                        fighter2.Attack(fighter1);
                        break;
                    case CombatAction.Defend:
                        fighter2.Defend();
                        break;
                    case CombatAction.SpecialAbility:
                        fighter2.UseSpecialAbility(fighter1);
                        break;
                }

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
