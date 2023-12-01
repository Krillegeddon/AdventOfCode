using Advent2022.Day01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2022.Day01
{
    public class Elf
    {
        public List<int> Calories { get; set; }
        public int TotalNumCalories { get; set; }
    }

    public class Model
    {
        public required List<Elf> Elfs { get; set; }

        public static Model Parse()
        { 
            var retObj = new Model
            {
                Elfs = new List<Elf>()
            };

            var currentElf = new Elf()
            {
                Calories = new List<int>(),
                TotalNumCalories = 0,
            };
            foreach (var lx in Data.InputData.Split("\n"))
            {
                var l = lx.Trim();
                if (string.IsNullOrEmpty(l))
                {
                    retObj.Elfs.Add(currentElf);
                    currentElf = new Elf()
                    {
                        Calories = new List<int>(),
                        TotalNumCalories = 0
                    };
                }
                else
                {
                    var calories = int.Parse(l);
                    currentElf.Calories.Add(calories);
                    currentElf.TotalNumCalories += calories;
                }
            }
            retObj.Elfs.Add(currentElf);
            return retObj;

        }
    }
}
