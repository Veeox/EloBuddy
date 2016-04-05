using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;
using EloBuddy.SDK.Notifications;
using EloBuddy.SDK.Menu.Values;

namespace PetBuddy
{
    internal class Shop
    {
        public static void ShopBuy()
        {

            if (!PetMenu.ShopMenu["food1"].Cast<CheckBox>().CurrentValue 
                && (!PetMenu.ShopMenu["food2"].Cast<CheckBox>().CurrentValue)
                && (!PetMenu.ShopMenu["topHat"].Cast<CheckBox>().CurrentValue)
                && (!PetMenu.ShopMenu["stache"].Cast<CheckBox>().CurrentValue))
            {
                return;
            }

            if (PetMenu.ShopMenu["food1"].Cast<CheckBox>().CurrentValue)
            {
                var CanBuy = GameAssets.PurchaseAvailable(GameAssets.med);

                if (CanBuy)
                {
                    if (!Pet.Sick)
                    {
                        Notifications.Show(new SimpleNotification("PetBuddy", "Your pet is not Sick!"));
                        PetMenu.ShopMenu["food1"].Cast<CheckBox>().CurrentValue = false;
                        return;
                    }
                    else
                    {
                        Notifications.Show(new SimpleNotification("PetBuddy", GameAssets.med.Name + " Bought!"));
                        Notifications.Show(new SimpleNotification("PetBuddy", "Your pet has been cured!"));
                        Pet.Sick = false;

                    }

                    //Deduct Cost
                    Pet.CashBalance -= GameAssets.med.Cost;
                }
                else
                {
                    Notifications.Show(new SimpleNotification("PetBuddy", "Not enough PetBux!"));
                }

                PetMenu.ShopMenu["food1"].Cast<CheckBox>().CurrentValue = false;
            }

            if (PetMenu.ShopMenu["food2"].Cast<CheckBox>().CurrentValue)
            {
                var CanBuy = GameAssets.PurchaseAvailable(GameAssets.expdouble);

                if (CanBuy)
                {
                    if (Pet.FoodXP)
                    {
                        Notifications.Show(new SimpleNotification("PetBuddy", "Cannot Buy Twice!"));
                        PetMenu.ShopMenu["food2"].Cast<CheckBox>().CurrentValue = false;
                        return;
                    }
                    else
                    {
                        if (Bonuses.bonusMulti < 2)
                        {
                            Notifications.Show(new SimpleNotification("PetBuddy", GameAssets.expdouble.Name + " Bought!"));
                            Pet.FoodXP = true;
                            Pet.XPMulti = 2;
                        }
                        else
                        {
                            Notifications.Show(new SimpleNotification("PetBuddy", "Bonus XP in effect, no need for this item!"));
                        }
                    }

                    //Deduct Cost
                    Pet.CashBalance -= GameAssets.expdouble.Cost;
                }
                else
                {
                    Notifications.Show(new SimpleNotification("PetBuddy", "Not enough PetBux!"));
                }

                PetMenu.ShopMenu["food2"].Cast<CheckBox>().CurrentValue = false;
            }

            if (PetMenu.ShopMenu["topHat"].Cast<CheckBox>().CurrentValue)
            {
                var CanBuy = GameAssets.PurchaseAvailable(GameAssets.topHat);

                if (CanBuy)
                {
                    if (Pet.topHat > 0)
                    {
                        Notifications.Show(new SimpleNotification("PetBuddy", "Cannot buy two hats!"));
                        PetMenu.ShopMenu["topHat"].Cast<CheckBox>().CurrentValue = false;
                        return;
                    }
                    else
                    {
                        Notifications.Show(new SimpleNotification("PetBuddy", GameAssets.topHat.Name + " Bought!"));
                        Notifications.Show(new SimpleNotification("PetBuddy", "Equip " + GameAssets.topHat.Name + " from your inventory!"));
                        
                        Pet.topHat = 1;
                        Converters.ConvertInt(Pet.topHat, Pet.stache);
                    }

                    //Deduct Cost
                    Pet.CashBalance -= GameAssets.topHat.Cost;
                }
                else
                {
                    Notifications.Show(new SimpleNotification("PetBuddy", "Not enough PetBux!"));
                }

                PetMenu.ShopMenu["topHat"].Cast<CheckBox>().CurrentValue = false;
            }

            if (PetMenu.ShopMenu["stache"].Cast<CheckBox>().CurrentValue)
            {
                var CanBuy = GameAssets.PurchaseAvailable(GameAssets.stache);

                if (CanBuy)
                {
                    if (Pet.stache > 0)
                    {
                        Notifications.Show(new SimpleNotification("PetBuddy", "Cannot buy two Moustaches!"));
                        PetMenu.ShopMenu["stache"].Cast<CheckBox>().CurrentValue = false;
                        return;
                    }
                    else
                    {
                        Notifications.Show(new SimpleNotification("PetBuddy", GameAssets.stache.Name + " Bought!"));
                        Notifications.Show(new SimpleNotification("PetBuddy", "Equip " + GameAssets.stache.Name + " from your inventory!"));
                        
                        Pet.stache = 1;
                        Converters.ConvertInt(Pet.topHat, Pet.stache);
                    }

                    //Deduct Cost
                    Pet.CashBalance -= GameAssets.stache.Cost;
                }
                else
                {
                    Notifications.Show(new SimpleNotification("PetBuddy", "Not enough PetBux!"));
                }

                PetMenu.ShopMenu["stache"].Cast<CheckBox>().CurrentValue = false;
            }
        }
    }
}
