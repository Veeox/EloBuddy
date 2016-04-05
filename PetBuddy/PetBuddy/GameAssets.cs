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
    internal class PetItem
    {
        public String Name { get; set; }
        public int Cost { get; set; }
        public bool Owned { get; set; }
    }
    static class GameAssets
    {
        public static PetItem med = new PetItem
        {
            Name = "Medicine",
            Cost = 30,
            Owned = false
        };

        public static PetItem expdouble = new PetItem
        {
            Name = "Double Experience",
            Cost = 500,
            Owned = false
        };

        public static PetItem topHat = new PetItem
        {
            Name = "Top Hat",
            Cost = 1500,
            Owned = false
        };

        public static PetItem stache = new PetItem
        {
            Name = "Moustache",
            Cost = 1000,
            Owned = false
        };

        public static bool IsOwned(this PetItem item)
        {
            return item.Owned;
        }

        public static bool PurchaseAvailable(this PetItem item)
        {
            return !item.Owned && Pet.CashBalance >= item.Cost;
        }
    }

}
