using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day05
{
    public class Logic
    {
        private static long FindLowestId(Model model, long seed)
        {
            var currentId = seed;

            foreach (var map in model.Maps)
            {
                foreach (var r in map.Ranges)
                {
                    if (currentId >= r.SourceID && currentId < r.SourceID + r.Length)
                    {
                        var offset = currentId - r.SourceID;
                        currentId = r.DestinationID + offset;
                        break;
                    }
                    // Didn't find anything... let currentId be unchanged.
                }
            }
            return currentId;
        }


        public static string Run()
        {
            var model = Model.Parse();

            long sum = long.MaxValue;

            //foreach (var seed in model.Seeds)
            foreach (var srange in model.SeedRanges)
            {
                for (var seed = srange.From; seed <= srange.To; seed++)
                {
                    var l = FindLowestId(model, seed);
                    if (l < sum)
                        sum = l;
                }
            }

            return sum.ToString();
        }
    }
}
