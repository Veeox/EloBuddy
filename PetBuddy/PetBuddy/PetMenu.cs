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
        public static Menu InventoryMenu = TitleMenu.AddSubMenu("Inventory", "inventory");
        public static Menu MiscMenu = TitleMenu.AddSubMenu("Misc Settings", "misc");
        public static Menu DrawingMenu = TitleMenu.AddSubMenu("Drawings", "petdrawings");

//        public static bool InvMenu = false;


        internal static void InitMenu()
        {
            #region Info

            TitleMenu.AddGroupLabel("PetBuddy by Veeox");
            TitleMenu.AddSeparator();
            TitleMenu.AddLabel(Bonuses.news);
            TitleMenu.AddSeparator();
            TitleMenu.AddSeparator();
            if (Bonuses.bonusMulti > 1)
            {
                TitleMenu.AddGroupLabel("Bonus XP is in effect!!");
                TitleMenu.AddLabel("Current Bonus: x" + Bonuses.bonusMulti + " XP");
            }
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

            #region Consumables

            ShopMenu.AddGroupLabel("Consumables");
            ShopMenu.Add("food1", new CheckBox("Buy " + GameAssets.med.Name + " ($" + GameAssets.med.Cost + ")", false));
            ShopMenu.Add("food2", new CheckBox("Buy " + GameAssets.expdouble.Name + " ($" + GameAssets.expdouble.Cost + ")", false));
            ShopMenu.AddSeparator();

            #endregion

            #region Cosmetics

            ShopMenu.AddGroupLabel("Cosmetics");
            ShopMenu.Add("topHat", new CheckBox("Buy " + GameAssets.topHat.Name + " ($" + GameAssets.topHat.Cost + ")", false));
            ShopMenu.Add("stache", new CheckBox("Buy " + GameAssets.stache.Name + " ($" + GameAssets.stache.Cost + ")", false));
            ShopMenu.AddSeparator();

            #endregion

            #region Invetory

            InventoryMenu.AddGroupLabel("PetBuddy Inventory");
            InventoryMenu.AddSeparator();
            InventoryMenu.Add("topHatEquip", new CheckBox("Equip " + GameAssets.topHat.Name, false));
            InventoryMenu.Add("stacheEquip", new CheckBox("Equip " + GameAssets.stache.Name, false));


            #endregion

            #region Misc

            MiscMenu.AddGroupLabel("Misc Settings");
            MiscMenu.AddSeparator();
            MiscMenu.Add("track", new CheckBox("Track Game", false));
            MiscMenu.Add("save", new CheckBox("Manual Save", false));
            MiscMenu.Add("new", new CheckBox("New Pet (Start Over)", false));


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
            DrawingMenu.Add("ypos", new Slider("Draw Y Position", 388, 0, 2500));

            #endregion


        }

        public static void AddStache()
        {
            if (Pet.stache > 0)
            {
                InventoryMenu.Add("stacheEquip", new CheckBox("Equip " + GameAssets.stache.Name, false));
            }
        }
    }
}
