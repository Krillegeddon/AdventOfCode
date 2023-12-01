using Advent2022.Day01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2022.Day01
{
    public class Logic
    {
        public static void Run()
        {
            var model = Model.Parse();

            var maxCals = model.Elfs.Max(p => p.TotalNumCalories);

            Console.WriteLine("Part1: " + maxCals);

            var topThreeTotal = model.Elfs.OrderByDescending(p => p.TotalNumCalories).Take(3).Sum(p => p.TotalNumCalories);

            Console.WriteLine("Part2: " + topThreeTotal);
        }
    }
}
