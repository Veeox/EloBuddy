﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;
using EloBuddy.SDK.Notifications;

using static PetBuddy.PetMenu;
using static PetBuddy.Pet;
using static PetBuddy.Converters;
using static PetBuddy.DrawStuff;
using static PetBuddy.GameAssets;
using static PetBuddy.PetItem;
using static PetBuddy.XPSys;
using static PetBuddy.Save;

namespace PetBuddy
{
    internal class PetMain
    {
        private static string DragonBuff = "s5test_dragonslayerbuff";
        private static string BaroonBuff = "exaltedwithbaronnashor";
        private static int AllyD;
        private static int AllyB;
        public static float QuadraDelay;
        public static float DoubleDelay;
        public static float TrippleDelay;
        public static float PentaDelay;
        public static float AceDelay;
        public static float WardDelay;
        public static float bDelay;
        public static AIHeroClient hero { get { return ObjectManager.Player; } }

        public static void Init()
        {
            InitMenu();
            PetInit();
            DrawInit();
            Game.OnNotify += OnGameNotify;
            Game.OnEnd += OnEnd;
            
        }

        public static void DoWelcome()
        {
            Notifications.Show(new SimpleNotification("PetBuddy","Loaded!"));
            Chat.Print("PetBuddy: Loaded!");
        }

        internal static void OnGameNotify(GameNotifyEventArgs args)
        {
            var killer = args.NetworkId;
            var al = FindPlayerByNetworkId(killer);

            switch (args.EventId) //Check for XP events
            {

                case GameEventId.OnChampionDoubleKill:

                    if (killer == hero.NetworkId)
                    {
                        if (Game.Time > DoubleDelay)
                        {
                            Pet.CurXP += (Pet.MaxXP / 80) * Pet.XPMulti;
                            Pet.CashBalance += 10;
                            DoubleDelay = Game.Time + 3000;
                        }

                    }
                    break;
                case GameEventId.OnChampionPentaKill:

                    if (killer == hero.NetworkId)
                    {
                        if (Game.Time > PentaDelay)
                        {
                            Pet.CurXP += (Pet.MaxXP / 15) * Pet.XPMulti;
                            Pet.CashBalance += 75;
                            PentaDelay = Game.Time + 3000;
                        }

                    }
                    break;
                case GameEventId.OnChampionQuadraKill:

                    if (killer == hero.NetworkId)
                    {
                        if (Game.Time > QuadraDelay)
                        {
                            Pet.CurXP += (Pet.MaxXP / 45) * Pet.XPMulti;
                            Pet.CashBalance += 50;
                            QuadraDelay = Game.Time + 3000;
                        }

                    }
                    break;
                case GameEventId.OnChampionTripleKill:

                    if (killer == hero.NetworkId)
                    {
                        if (Game.Time > TrippleDelay)
                        {
                            Pet.CurXP += (Pet.MaxXP / 75) * Pet.XPMulti;
                            Pet.CashBalance += 35;
                            TrippleDelay = Game.Time + 3000;
                        }

                    }
                    break;
                case GameEventId.OnAce:

                    var pl = FindPlayerByNetworkId(killer);
                    if (Game.Time > AceDelay)
                    {
                        if (pl != null && pl.IsAlly)
                        {
                            Pet.CurXP += (Pet.MaxXP / 80) * Pet.XPMulti;
                            Pet.CashBalance += 15;
                            AceDelay = Game.Time + 3000;
                        }
                    }
                    break;
                case GameEventId.OnChampionKill:

                    if (killer == hero.NetworkId)
                    {
                        Pet.CurXP += (Pet.MaxXP / 75) * Pet.XPMulti;
                        Pet.CashBalance += 5;
                    }
                    break;
                case GameEventId.OnKillWard:

                    if (ObjectManager.Player.IsMe)
                    {
                        if (Game.Time > WardDelay)
                        {
                            KillWard();
                            WardDelay = Game.Time + 3000;
                        }

                        Console.WriteLine("Killed a ward!");
                    }
                    break;
                case GameEventId.OnChampionDie:
                    if (killer == hero.NetworkId && !Pet.Sick)
                    {
                        if (Pet.Lvl > 0)
                        {
                            Pet.GetSick();
                        }
                    }
                    break;
            }
        }

        public static AIHeroClient FindPlayerByNetworkId(uint id)
        {
            AIHeroClient player = null;
            foreach (var n in EntityManager.Heroes.AllHeroes)
            {
                if (n.NetworkId == id)
                    player = n;
            }
            return player;
        }

        private static void KillWard()
        {
            Pet.CurXP += (Pet.MaxXP / 100) * Pet.XPMulti;
            Pet.CashBalance += 1;
        }

        public static void DragonCheck()
        {
            var allyDbuff = hero.Buffs.Find(x => x.Name == DragonBuff);

            // ally kill dragon
            if (allyDbuff != null && allyDbuff.Count > AllyD)
            {
                AllyD = allyDbuff.Count;
                KillDrag();
            }
            // dragon 5 expiry
            if (allyDbuff != null && allyDbuff.Count < AllyD)
            {
                AllyD = allyDbuff.Count;
            }
        }

        public static void BaroonCheck()
        {
            var allyBbuff = hero.Buffs.Find(x => x.Name == BaroonBuff);
            if (Game.Time > bDelay)
            {
                // ally kill baroon
                if (allyBbuff != null && allyBbuff.Count > AllyB)
                {
                    AllyB = allyBbuff.Count;
                    KillBaroon();
                    bDelay = Game.Time + 3000;
                }
            }
            // baroon expiry
            if (allyBbuff != null && allyBbuff.Count < AllyB)
            {
                AllyB = allyBbuff.Count;
            }
        }

        private static void KillDrag()
        {
            Pet.CurXP += (Pet.MaxXP / 30) * Pet.XPMulti;
            Pet.CashBalance += 20;
            Console.WriteLine("Drag Killed");
        }

        private static void KillBaroon()
        {
            Pet.CurXP += (Pet.MaxXP / 50) * Pet.XPMulti;
            Pet.CashBalance += 35;
            Console.WriteLine("Baroon Killed");
        }
        internal static void OnEnd(EventArgs args)
        {
            Converters.ConvertInt(Pet.Lvl, Pet.CurXP, Pet.MaxXP, Pet.CashBalance);
        }

    }
}