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
    internal class Pet
    {
        //Main Pet Vars
        public static int CurXP;
        public static int MaxXP;
        public static int Lvl;
        public static string PetName;
        public static int CashBalance = 0;
        public static bool Sick = false;
        public static bool FoodXP = false;
        public static int XPMulti = 1;
        public static string mySprite;

        //Sprite Vars
        public static int minion_buffer_size = 60;
        public static EloBuddy.SDK.Rendering.Sprite[] sprites = new EloBuddy.SDK.Rendering.Sprite[minion_buffer_size];
        //public EloBuddy.SDK.Rendering.Sprite PetSprite;

        public static void PetRun()
        {

        }
    }
}
