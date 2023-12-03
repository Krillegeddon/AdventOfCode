using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day03
{
    public class Logic
    {
        public static string Run()
        {
            var model = Model.Parse();

            long sum = 0;

            foreach (var pn in model.PartnumberCoords)
            {
                var minx = pn.Coordinate.X - 1;
                var miny = pn.Coordinate.Y - 1;
                var maxx = pn.Coordinate.X + pn.Partnumber.Length;
                var maxy = pn.Coordinate.Y + 1;

                var symbols = model.SymbolCoords.Where(c=>c.Coordinate.X >= minx && c.Coordinate.Y >= miny && c.Coordinate.X <= maxx && c.Coordinate.Y <= maxy).ToList();

                // For part 2: simply add myself (partnumber) to the list of each symbol's list of adjecent part numbers.
                foreach (var symbol in symbols)
                {
                    symbol.AdjPartnumbers.Add(pn);
                }

                if (symbols.Any())
                {
                    sum += int.Parse(pn.Partnumber);
                }
            }

            var step1Sum = sum;

            sum = 0;

            foreach (var symbol in model.SymbolCoords.Where(p => p.Symbol == '*' && p.AdjPartnumbers.Count == 2).ToList())
            {
                var p1 = int.Parse(symbol.AdjPartnumbers[0].Partnumber);
                var p2 = int.Parse(symbol.AdjPartnumbers[1].Partnumber);
                sum += (p1 * p2);
            }

            return sum.ToString();
        }
    }
}
