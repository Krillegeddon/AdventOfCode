using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Day04
{
    public class Logic
    {
        private static bool CanFindXmas(Grid g, int x, int y, int dx, int dy)
        {
            var stringToFind = "XMAS";
            var arrToFind = stringToFind.ToCharArray().Select(p => p.ToString()).ToList();
            var currX = x + dx;
            var currY = y + dy;


            for (int i = 1; i < stringToFind.Length; i++)
            {
                var cc = g.GetChar(currX, currY);
                if (g.GetChar(currX, currY) != arrToFind[i])
                    return false;
                currX += dx;
                currY += dy;
            }


            return true;
        }

        private static int NumFindXmas(Grid g, int x, int y)
        {
            if (x == 5 && y == 0)
            {
                int bb = 9;
            }


            // If we don't even start on an A, that's 0 XMAS:es here...
            if (g.GetChar(x, y) != "A")
                return 0;

            var a = g.GetChar(x - 1, y - 1);
            var b = g.GetChar(x + 1, y + 1);
            var c = g.GetChar(x + 1, y - 1);
            var d = g.GetChar(x - 1, y + 1);

            var ab = false;
            if (a == "M" && b == "S" || a == "S" && b == "M")
                ab = true;
            var cd = false;
            if (c == "M" && d == "S" || c == "S" && d == "M")
                cd = true;

            if (ab && cd)
                return 1;
            else
                return 0;

            int retNum = 0;

            for (int dx = -1; dx < 2; dx++)
            {
                for (int dy = -1; dy < 2; dy++)
                {
                    if (CanFindXmas(g, x, y, dx, dy))
                        retNum++;
                }
            }
            return retNum;
        }

        public static string Run()
        {
            var model = Model.Parse();

            long sum = 0;

            for (int x = 0; x < model.Grid.Width; x++)
            {
                for (int y = 0; y < model.Grid.Height; y++)
                {
                    sum += NumFindXmas(model.Grid, x, y);
                }
            }

            return sum.ToString();
        }
    }
}
