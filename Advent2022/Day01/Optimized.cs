using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2022.Day01
{
    public class Optimized
    {
        private static int maxCals = 0;
        private static int maxCals2 = 0;
        private static int maxCals3 = 0;

        private static void AlignMaxes(int elfCals)
        {
            if (elfCals > maxCals)
            {
                maxCals3 = maxCals2;
                maxCals2 = maxCals;
                maxCals = elfCals;
            }
            else if (elfCals > maxCals2)
            {
                maxCals3 = maxCals2;
                maxCals2 = elfCals;

            }
            else if (elfCals > maxCals3)
            {
                maxCals3 = elfCals;
            }
        }

        public static void Run()
        {
            int elfCals = 0;
            foreach (var lx in Data.InputData.Split("\n"))
            {
                var l = lx.Trim();
                if (string.IsNullOrEmpty(l))
                {
                    AlignMaxes(elfCals);
                    elfCals = 0;
                }
                else
                {
                    elfCals += int.Parse(l);
                }

            }
            AlignMaxes(elfCals);
            Console.WriteLine("Part1 (optimized): " + maxCals);
            Console.WriteLine("Part2 (optimized): " + (maxCals + maxCals2 + maxCals3));
        }
    }
}
