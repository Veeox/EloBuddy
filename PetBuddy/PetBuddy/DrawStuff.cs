using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = System.Drawing.Color;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;
using EloBuddy.SDK.Rendering;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Notifications;

namespace PetBuddy
{
    internal class DrawStuff
    {
        public static int xpos = 0;
        public static int ypos = 0;
        public static int drawX1 = (int)(Drawing.Width * 0.68);
        public static int drawY1 = (int)(Drawing.Height * 0.97);
        public static int drawX2 = (int)(Drawing.Width * 0.68);
        public static int drawY2 = (int)(Drawing.Height * 0.97) - 40;
        public static int myTeamDmgX = (int)(Drawing.Width * 0.68);
        public static int myTeamDmgY = (int)(Drawing.Height * 0.97) - 20;
        public static int enemyTeamDmgX = (int)(Drawing.Width * 0.68);
        public static int enemyTeamDmgY = (int)(Drawing.Height * 0.97) - 60;
        public static string tempSprite = null;

        //Sprite
        private static readonly TextureLoader TextureLoader = new TextureLoader();


        public static Sprite sprite = null;
        //public static string petSprite;

        //Cosmetic sprites
        public static Sprite topHatSprite = null;
        public static Sprite stacheSprite = null;

        internal static void DrawInit()
        {
            Drawing.OnEndScene += Drawing_OnDraw;

        }

        internal static void Drawing_OnDraw(EventArgs args)
        {
            if (!PetMenu.MiscMenu["track"].Cast<CheckBox>().CurrentValue)
            {
                return;
            }

            if (sprite == null)
            {

                DrawSprite();
                tempSprite = Pet.mySprite.ToString();
            }

            xpos = PetMenu.DrawingMenu["xpos"].Cast<Slider>().CurrentValue;
            ypos = PetMenu.DrawingMenu["ypos"].Cast<Slider>().CurrentValue;

            if (PetMenu.DrawingMenu["drawstats"].Cast<CheckBox>().CurrentValue && !PetMenu.DrawingMenu["disDraw"].Cast<CheckBox>().CurrentValue)
            {
                //Drawing Box

                var borderColor = Color.Black;
                var bgColor = Color.LightGray;
                var textColor = Color.Black;


                //Left
                Drawing.DrawLine(xpos - 7,
                                 ypos + 120,
                                 xpos - 7,
                                 ypos - 90, 3,
                                 borderColor);
                //Top
                Drawing.DrawLine(xpos - 8,
                                 ypos - 92,
                                 xpos + 170,
                                 ypos - 92, 3,
                                 borderColor);
                //Right
                Drawing.DrawLine(xpos + 168,
                                 ypos + 120,
                                 xpos + 168,
                                 ypos - 91, 3,
                                 borderColor);
                //Bottom
                Drawing.DrawLine(xpos - 8,
                                 ypos + 120,
                                 xpos + 170,
                                 ypos + 120, 3,
                                 borderColor);
                //Drawing Background

                Drawing.DrawLine(xpos + 81,
                                 ypos + 119,
                                 xpos + 81,
                                 ypos - 90, 171,
                                 bgColor);

                //Drawing Stats

                Drawing.DrawText(xpos + 25, ypos - 85, System.Drawing.Color.DarkRed, "PetBuddy BETA");
                Drawing.DrawText(xpos, ypos + 20, textColor, "Pet Name: " + Pet.PetName);
                Drawing.DrawText(xpos, ypos + 40, textColor, "Level: " + (int)Pet.Lvl);
                Drawing.DrawText(xpos, ypos + 60, textColor, "XP: " + (int)Pet.CurXP + "/" + (int)Pet.MaxXP);
                Drawing.DrawText(xpos, ypos + 80, textColor, "PetBux: $" + (int)Pet.CashBalance);
                if (Pet.Sick)
                {
                    Drawing.DrawText(xpos, ypos + 100, System.Drawing.Color.Red, "Pet Health: Sick");
                }
                else
                {
                    Drawing.DrawText(xpos, ypos + 100, System.Drawing.Color.Green, "Pet Health: Fine");
                }
            }
            if (PetMenu.DrawingMenu["drawsprites"].Cast<CheckBox>().CurrentValue && sprite != null && !PetMenu.DrawingMenu["disDraw"].Cast<CheckBox>().CurrentValue)
            {
                
                DrawCurSprite();

                GetCos();

                //sprite.X = xpos + 35;
                //sprite.Y = ypos - 60;

            }
            else
            {
                return;
            }


    }
        public static void DrawCurSprite()
        {
            if (Pet.mySprite.ToString() != tempSprite)
            {
                sprite = null;
                TextureLoader.Dispose();
                tempSprite = Pet.mySprite.ToString();
            }
            else
            {
                sprite.Draw(new Vector2(DrawStuff.xpos + 43, DrawStuff.ypos - 60));
            }
        }


        public static void DrawSprite()
        {
            xpos = PetMenu.DrawingMenu["xpos"].Cast<Slider>().CurrentValue;
            ypos = PetMenu.DrawingMenu["ypos"].Cast<Slider>().CurrentValue;

            //Draw Sprites
            //Get Pet Sprite
            GetPetSprite();

            sprite.Scale = new Vector2(0.12f, 0.12f);

        }

        public static void GetCos()
        {
            if (Pet.topHat < 1 && PetMenu.InventoryMenu["topHatEquip"].Cast<CheckBox>().CurrentValue)
            {

                Notifications.Show(new SimpleNotification("PetBuddy", "You do not own the " + GameAssets.topHat.Name + " yet!" + System.Environment.NewLine + "To purchase please visit the Pet Shop!"));
                PetMenu.InventoryMenu["topHatEquip"].Cast<CheckBox>().CurrentValue = false;
            }

            if (Pet.stache < 1 && PetMenu.InventoryMenu["stacheEquip"].Cast<CheckBox>().CurrentValue)
            {

                Notifications.Show(new SimpleNotification("PetBuddy", "You do not own the " + GameAssets.stache.Name + " yet!" + System.Environment.NewLine + "To purchase please visit the Pet Shop!"));
                PetMenu.InventoryMenu["stacheEquip"].Cast<CheckBox>().CurrentValue = false;
            }

            if (Pet.topHat > 0 && PetMenu.InventoryMenu["topHatEquip"].Cast<CheckBox>().CurrentValue)
            {
                if (DrawStuff.topHatSprite == null)
                { 
                    TextureLoader.Load("TopHat", Resources.Resource1.TopHat);
                    topHatSprite = new Sprite(() => TextureLoader["TopHat"]);
                }

                DrawHat();
                
            }
            
            if (Pet.stache > 0 && PetMenu.InventoryMenu["stacheEquip"].Cast<CheckBox>().CurrentValue)
            {
                if (DrawStuff.stacheSprite == null)
                {
                    TextureLoader.Load("moustache", Resources.Resource1.moustache);
                    stacheSprite = new Sprite(() => TextureLoader["moustache"]);
                }

                DrawStache();
                
            }
            else
            {
                return;
            }
        }

        public static void DrawHat()
        {
            if (Pet.mySprite == "g4205")
            {
                topHatSprite.Scale = new Vector2(1.1f, 1.1f);
                topHatSprite.Draw(new Vector2(DrawStuff.xpos + 32, DrawStuff.ypos - 130));
            }
            else
            {
                topHatSprite.Scale = new Vector2(1.1f, 1.1f);
                topHatSprite.Draw(new Vector2(DrawStuff.xpos + 25, DrawStuff.ypos - 130));
            }
        }

        public static void DrawStache()
        {
            if (Pet.mySprite == "g4205")
            {
                stacheSprite.Draw(new Vector2(DrawStuff.xpos + 34.5f, DrawStuff.ypos - 35));
                stacheSprite.Scale = new Vector2(1.1f, 1.1f);
            }
            else 
            {
                stacheSprite.Draw(new Vector2(DrawStuff.xpos + 26.5f, DrawStuff.ypos - 35));
                stacheSprite.Scale = new Vector2(1.1f, 1.1f);
            }
        }

        public static void GetPetSprite()
        {
            switch (Pet.mySprite)
            {
                case "g4148":
                    TextureLoader.Load("g4148", Resources.Resource1.g4148);
                    sprite = new Sprite(() => TextureLoader["g4148"]);
                    //sprite = new Sprite(Resources.Resource1.g4148, new Vector2(xpos + 20, ypos - 75));
                    break;
                case "g4174":
                    TextureLoader.Load("g4174", Resources.Resource1.g4174);
                    sprite = new Sprite(() => TextureLoader["g4174"]);
                    //sprite = new Sprite(Resources.Resource1.g4174, new Vector2(xpos + 20, ypos - 75));
                    break;
                case "g4205":
                    TextureLoader.Load("g4205", Resources.Resource1.g4205);
                    sprite = new Sprite(() => TextureLoader["g4205"]);
                    //sprite = new Sprite(Resources.Resource1.g4205, new Vector2(xpos + 20, ypos - 75));
                    break;
                case "g4238":
                    TextureLoader.Load("g4238", Resources.Resource1.g4238);
                    sprite = new Sprite(() => TextureLoader["g4238"]);
                    //sprite = new Sprite(Resources.Resource1.g4238, new Vector2(xpos + 20, ypos - 75));
                    break;
                case "path4249":
                    TextureLoader.Load("path4249", Resources.Resource1.path4249);
                    sprite = new Sprite(() => TextureLoader["path4249"]);
                    //sprite = new Sprite(Resources.Resource1.path4249, new Vector2(xpos + 20, ypos - 75));
                    break;
                default:
                    TextureLoader.Load("g4205", Resources.Resource1.g4205);
                    sprite = new Sprite(() => TextureLoader["g4205"]);
                    //sprite = new Sprite(Resources.Resource1.g4205, new Vector2(xpos + 20, ypos - 75));
                    Pet.mySprite = "g4205";
                    Converters.ConvertInt(Pet.Lvl, Pet.CurXP, Pet.MaxXP, Pet.CashBalance);
                    break;
            }
        }
    }
}
