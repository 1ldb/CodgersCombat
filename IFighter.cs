using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodgersCombat
{
    // INTERFACE - a contract that says what a fighter MUST be able to do
    // By convention, interface names start with "I"
    public interface IFighter
    {
        // Properties that all fighters MUST have
        string Name { get; }
        int Health { get; }
        bool IsAlive();

        // Methods that all fighters MUST implement
        void Attack(IFighter target);
        void TakeDamage(int damage);
        void Introduce();
        void Defend(); // NEW: Defensive action
        void UseSpecialAbility(IFighter target); // NEW: Special move
        void ResetDefense(); // NEW: Reset defense state each turn
    }
}
