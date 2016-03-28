using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;

using static PetBuddy.PetMenu;

namespace PetBuddy
{
    internal class PetMain
    {

        //Sprite
        public static EloBuddy.SDK.Rendering.Sprite sprite = null;
        public static string petSprite;
        public static void Init()
        {
            InitMenu();
        }
    }
}