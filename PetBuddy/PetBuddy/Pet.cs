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
using EloBuddy.SDK.Notifications;
using EloBuddy.SDK.Rendering;

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
        public static bool nSick, Sick = false;
        public static bool FoodXP = false;
        public static int XPMulti = 1;
        public static string mySprite;

        //Sprite Vars
        public static int minion_buffer_size = 60;
        public static EloBuddy.SDK.Rendering.Sprite[] sprites = new EloBuddy.SDK.Rendering.Sprite[minion_buffer_size];
        //public EloBuddy.SDK.Rendering.Sprite PetSprite;
        

        internal static void PetInit()
        {
            Save.SaveData();
            Game.OnTick += Game_OnTick;
            Game.OnUpdate += Game_OnUpdate;
            PetMenu.InitMenu();

        }

        private static void Game_OnTick(EventArgs args)
        {
            if (!PetMenu.MiscMenu["track"].Cast<CheckBox>().CurrentValue)
            {
                return;
            }
            else
            {
                XPSys.LevelUp();
                
            }
        }

        private static void Game_OnUpdate(EventArgs args)
        {
            if (!PetMenu.MiscMenu["track"].Cast<CheckBox>().CurrentValue)
            {
                return;
            }
            else
            {
                PetMain.DragonCheck();
                Shop.ShopBuy();
                Save.ManualSave();
                Save.NewPet();
            }
        }

        public static void GetSick()
        {
            Random rnd = new Random();

            int r = rnd.Next(10) + 1;

            if (r >= 7)
            {
                Sick = true;
                nSick = true;
                NotiSick();
            }
        }

        

        public static void NotiSick()
        {
            Notifications.Show(new SimpleNotification("PetBuddy", "Your pet is sick!"));
            Chat.Print("PetBuddy: Your pet is sick!");
            Notifications.Show(new SimpleNotification("PetBuddy", "Buy Medicine from the Shop to cure! If your pet is sick for too long it will die!"));
            Chat.Print("PetBuddy: Buy Medicine from the Shop to cure! If your pet is sick for too long it will die!");
            
        }

        public static void PetDie()
        {
            Notifications.Show(new SimpleNotification("PetBuddy", "Your pet has died!"));
            Chat.Print("PetBuddy: Your pet has died!");
            Save.FirstRun();
            Converters.ConvertInt(Pet.Lvl, Pet.CurXP, Pet.MaxXP, Pet.CashBalance);
            Notifications.Show(new SimpleNotification("PetBuddy", "New Pet Created!"));
            Chat.Print("PetBuddy: New Pet Adopted!");
        }
    }
}
