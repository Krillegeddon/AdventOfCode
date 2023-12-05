using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day05
{
    public class Logic
    {
        private static long Traverse(List<Map> maps, int mapIndex, long minValue, long maxValue)
        {
            var isFinal = mapIndex == maps.Count - 1;
            var map = maps[mapIndex];

            var ranges = map.Ranges.Where(p=>p.SourceEnd >= minValue && p.SourceID <= maxValue).OrderBy(p=>p.SourceID).ToList();

            if (ranges.Count == 0)
            {
                // No mappings, then just traverse min/max values to next layer without modify them
                if (isFinal)
                    return minValue;
                return Traverse(maps, mapIndex + 1, minValue, maxValue);
            }

            var lenghts = new List<long>();
            var checkFrom = minValue - 1;
            foreach (var range in ranges)
            {
                checkFrom++;

                if (range.SourceID > checkFrom)
                {
                    // We have an unranged area between checkFrom and range.Start! Traverse that! Without conversion.
                    if (isFinal)
                        lenghts.Add(checkFrom);
                    else
                        lenghts.Add(Traverse(maps, mapIndex + 1, checkFrom, range.SourceID - 1));
                    checkFrom = range.SourceID;
                }

                var checkTo = long.Min(range.SourceEnd, maxValue);

                //... and then from RangeStart (or minValue) to end of range (or maxValue)... With conversion.
                if (isFinal)
                    lenghts.Add(range.GetDestinationId(checkFrom));
                else
                    lenghts.Add(Traverse(maps, mapIndex + 1, range.GetDestinationId(checkFrom), range.GetDestinationId(checkTo)));
                checkFrom = checkTo;
            }

            // Almost done! Check if there is an unranged area between end of last range and maxValue!
            if (ranges[ranges.Count - 1].SourceEnd < maxValue)
            {
                if (isFinal)
                    lenghts.Add(ranges[ranges.Count - 1].SourceEnd + 1);
                else
                    lenghts.Add(Traverse(maps, mapIndex + 1, ranges[ranges.Count - 1].SourceEnd + 1, maxValue));
            }

            return lenghts.Min(p => p);
        }

        public static string Run()
        {
            var sw = new Stopwatch();
            sw.Start();
            var model = Model.Parse();

            long sum = long.MaxValue;


            foreach (var srange in model.SeedRanges)
            {
                var l = Traverse(model.Maps, 0, srange.From, srange.To);
                if (l < sum)
                    sum = l;
            }
            sw.Stop();

            var yy = sw.ElapsedMilliseconds; // 19 ms

            return sum.ToString();
        }
    }
}
