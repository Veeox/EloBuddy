using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using SharpDX;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace PetBuddy
{
    internal class PetMenu
    {
        private static Menu TitleMenu = MainMenu.AddMenu("PetBuddy", "PetBuddy");


        public static void InitMenu()
        {
            TitleMenu.AddGroupLabel("PetBuddy by Veeox");
            TitleMenu.AddGroupLabel("This is currently in BETA");
            TitleMenu.AddGroupLabel("Please report any bugs to the EloBuddy Forum Post!");


        }
    }
}
