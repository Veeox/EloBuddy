﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;


namespace PetBuddy
{
    internal class Bonuses
    {
        public static string news =
            "Version 0.0.1.5"
            + System.Environment.NewLine +
            ""
            + System.Environment.NewLine +
            "PetBuddy now has HATS!!"
            + System.Environment.NewLine +
            "Check out the Pet Shop to purchase!"
            + System.Environment.NewLine +
            "Please report any bugs!"
            + System.Environment.NewLine +
            "<3 Veeox";


        //private static string bonusTextFile = Resources.Resource1.BonusValues;
        public static string SpBonusXP = null;
        public static int bonusMulti = 0;
        private static Assembly assembly = Assembly.GetExecutingAssembly();
        private static string resourceName = "PetBuddy.Resources.BonusValues.txt";
        internal static void BonusInit()
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            using (var streamReader = new StreamReader(stream))
            {
                // Read the embedded file ...
                string line;
                int currentLineNumber = 0;
                while ((line = streamReader.ReadLine()) != null)
                {
                    switch (++currentLineNumber)
                    {
                        case 1:
                            SpBonusXP = line;
                            break;
                    }
                }

                bonusMulti = int.Parse(SpBonusXP);
                Pet.XPMulti = bonusMulti;
            }
        }
    }
}
