﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Notifications;

namespace PetBuddy
{
    internal class PetMenu
    {
        private static readonly Menu TitleMenu = MainMenu.AddMenu("PetBuddy", "petbuddy");
        public static Menu ShopMenu = TitleMenu.AddSubMenu("Shop", "shop");
        public static Menu MiscMenu = TitleMenu.AddSubMenu("Misc Settings", "misc");
        public static Menu DrawingMenu = TitleMenu.AddSubMenu("Drawings", "petdrawings");


        internal static void InitMenu()
        {
            #region Info

            TitleMenu.AddGroupLabel("PetBuddy by Veeox");
            TitleMenu.AddLabel("This is currently in BETA");
            TitleMenu.AddLabel("Please report any bugs to the EloBuddy Forum Post!");
            TitleMenu.AddSeparator();
            //if (Program.PetBuddyLoaded)
            //{
            //    TitleMenu.AddGroupLabel("Your PetBuddy Stats");
            //    TitleMenu.AddLabel("Pet Name: " + Pet.PetName);
            //    TitleMenu.AddLabel("Pet Level: " + (int)Pet.Lvl);
            //    TitleMenu.AddLabel("Current XP: " + (int)Pet.CurXP + "/" + (int)Pet.MaxXP);
            //    TitleMenu.AddLabel("PetBux: $" + (int)Pet.CashBalance);
            //    if (Pet.Sick)
            //    {
            //        TitleMenu.AddLabel("Pet Health: Sick (Will die soon!)");
            //    }
            //    else
            //    {
            //        TitleMenu.AddLabel("Pet Health: Fine");
            //    }
            //}

            #endregion

            #region Shop

            ShopMenu.AddGroupLabel("PetBuddy Shop");
            ShopMenu.AddSeparator();

            #endregion

            #region Misc

            MiscMenu.AddGroupLabel("Misc Settings");
            MiscMenu.AddSeparator();
            MiscMenu.Add("track", new CheckBox("Track Game", false));
            

            #endregion

            #region Drawings

            DrawingMenu.AddGroupLabel("Drawing Settings");
            DrawingMenu.Add("disDraw", new CheckBox("Disable all Drawings", false));
            DrawingMenu.AddSeparator();
            DrawingMenu.AddLabel("Single Draw Settings");
            DrawingMenu.Add("drawstats", new CheckBox("Draw Stats", false));
            DrawingMenu.Add("drawsprites", new CheckBox("Draw Sprites", false));
            DrawingMenu.AddSeparator();
            DrawingMenu.AddLabel("Drawing Positions");
            DrawingMenu.Add("xpos", new Slider("Draw X Position", 1711, 0, 2500));
            DrawingMenu.Add("ypos", new Slider("Draw Y Position", 591, 0, 2500));

            #endregion


        }
    }
}