using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace CodgersCombat
{
    // Handles player input and decision making
    public class PlayerController
    {
        // Let player choose their fighter from the roster
        public IFighter ChooseFighter(IFighter[] fighters)
        {
            Console.WriteLine("\n=== CHOOSE YOUR FIGHTER ===");

            for (int i = 0; i < fighters.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {fighters[i].Name} (Health: {fighters[i].Health})");
            }

            Console.Write("\nEnter number (1-{0}): ", fighters.Length);

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > fighters.Length)
            {
                Console.Write("Invalid choice! Enter number (1-{0}): ", fighters.Length);
            }

            Console.WriteLine($"\nYou chose: {fighters[choice - 1].Name}!\n");
            return fighters[choice - 1];
        }

        // Let player choose an action each turn
        public CombatAction ChooseAction()
        {
            Console.WriteLine("\n--- YOUR TURN ---");
            Console.WriteLine("1. Attack (Standard damage)");
            Console.WriteLine("2. Defend (Reduce incoming damage by 50%)");
            Console.WriteLine("3. Special Ability (Unique powerful move)");
            Console.Write("\nChoose your action (1-3): ");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
            {
                Console.Write("Invalid choice! Enter 1, 2, or 3: ");
            }

            Console.WriteLine(); // Blank line for readability

            return (CombatAction)(choice - 1); // Convert 1,2,3 to enum values 0,1,2
        }
    }
}