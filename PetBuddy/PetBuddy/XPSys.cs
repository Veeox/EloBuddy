using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;

namespace PetBuddy
{
    internal class XPSys
    {
    
        public static void LevelUp()
        {
            if (Pet.CurXP >= Pet.MaxXP)
            {
                Pet.CurXP = (Pet.CurXP - Pet.MaxXP);
                Pet.MaxXP = (Pet.MaxXP * 2);
                Pet.Lvl++;
                Chat.Print("PetBuddy: Leveled up!");
            }
        }
    }
}
