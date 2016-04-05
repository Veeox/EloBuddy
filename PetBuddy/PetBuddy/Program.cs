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

namespace PetBuddy
{
    class Program
    {
        public static bool PetBuddyLoaded { get; internal set; }
        static void Main(string[] args)
        {

            Loading.OnLoadingComplete += OnLoad;
            
        }
        private static void OnLoad(EventArgs arg)
        {

            PetBuddyLoaded = false;
            Bonuses.BonusInit();
            Game.OnTick += Game_OnTick;

        }

        private static void Game_OnTick(EventArgs arg)
        {
            if (!PetBuddyLoaded)
            {
                PetMain.Init();
                Save.SaveData();
                Save.SaveCos();
                PetBuddyLoaded = true;

            }
            if (PetBuddyLoaded)
            {
                PetMain.DoWelcome();
                Game.OnTick -= Game_OnTick;
            }
        }
        
    }
}