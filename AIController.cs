using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodgersCombat
{
    // Simple AI that makes decisions for enemy fighters
    public class AIController
    {
        private Random random = new Random();

        // AI chooses an action based on simple logic
        public CombatAction ChooseAction(IFighter aiFighter, IFighter playerFighter)
        {
            // If AI health is low (below 30%), 40% chance to defend
            if (aiFighter.Health < 30 && random.Next(1, 101) <= 40)
            {
                return CombatAction.Defend;
            }

            // If AI health is good, 20% chance to use special ability
            if (random.Next(1, 101) <= 20)
            {
                return CombatAction.SpecialAbility;
            }

            // Default: Attack (most common action)
            return CombatAction.Attack;
        }
    }
}
