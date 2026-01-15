using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodgersCombat
{
    // INTERFACE - a contract that says what a fighter MUST be able to do
    // By convention, interface names start with "I"
    // ENUM - a list of named constants for combat actions
    public enum CombatAction
    {
        Attack,         // Standard attack
        Defend,         // Reduce incoming damage
        SpecialAbility  // Unique ability (varies by codger type)
    }
}
