﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;
using EloBuddy.SDK.Notifications;

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
                Notifications.Show(new SimpleNotification("PetBuddy", "Pet leveled up!"));
                Chat.Print("PetBuddy: Leveled up!");
            }
        }
    }
}
