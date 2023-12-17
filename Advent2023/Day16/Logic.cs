using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day16
{
    public class Logic
    {
        private static Dictionary<string, bool> _alreadyWalked = new Dictionary<string, bool>();


        private static void Walk(Grid grid, int x, int y, int dx, int dy, bool isFirst)
        {
            var walkKey = $"{x}_{y}_{dx}_{dy}";
            if (!isFirst)
            {
                if (_alreadyWalked.ContainsKey(walkKey))
                    return;
                _alreadyWalked.Add(walkKey, true);
            }



            if (x < 0) return;
            if (x > grid.Width -1) return;
            if (y < 0) return;
            if (y > grid.Height - 1) return;

            grid.SetEnergized(x, y);

            var newx = x;
            var newy = y;

            if (!isFirst)
            {
                newx = x + dx;
                newy = y + dy;
            }

            var newCell = grid.Get(newx, newy);
            if (newCell == null || newCell.Type == '.')
            {
                // If just a blank... then continue walking...
                Walk(grid, newx, newy, dx, dy, false);
                return;
            }
            if (newCell.Type == '-' && (dx == 1 || dx == -1))
            {
                // If passing through a -
                Walk(grid, newx, newy, dx, dy, false);
                return;
            }
            if (newCell.Type == '|' && (dy == 1 || dy == -1))
            {
                // If passing through a |
                Walk(grid, newx, newy, dx, dy, false);
                return;
            }
            if (newCell.Type == '/')
            {
                // If coming from the left to right (dx = 1), the move upwards (dy = -1).
                // If coming from the right to left (dx = -1), then move downards (dy = 1)
                if (dx == 1 || dx == -1)
                {
                    Walk(grid, newx, newy, 0, dx * -1, false);
                    return;
                }

                // If coming from up to down (dy = 1), then move to the left (dx = -1)
                // If coming from down to up (dy = -1), then move the right (dx = 1)
                if (dy == 1 || dy == -1)
                {
                    Walk(grid, newx, newy, dy * -1, 0, false);
                    return;
                }
            }
            if (newCell.Type == '\\')
            {
                // If coming from the left to right (dx = 1), the move down (dy = 1).
                // If coming from the right to left (dx = -1), then move upwards (dy = -1)
                if (dx == 1 || dx == -1)
                {
                    Walk(grid, newx, newy, 0, dx, false);
                    return;
                }

                // If coming from up to down (dy = 1), then move to the right (dx = 1)
                // If coming from down to up (dy = -1), then move the left (dx = -1)
                if (dy == 1 || dy == -1)
                {
                    Walk(grid, newx, newy, dy, 0, false);
                    return;
                }
            }
            if (newCell.Type == '|')
            {
                // In this case, we are splitting! Passing through has already been handled in if-statements above!
                // We now want to walk both up and down!
                Walk(grid, newx, newy, 0, -1, false); // walk up
                Walk(grid, newx, newy, 0, 1, false); // walk down
                return;
            }

            if (newCell.Type == '-')
            {
                // In this case, we are splitting! Passing through has already been handled in if-statements above!
                // We now want to walk left and right!
                Walk(grid, newx, newy, -1, 0, false); // walk left
                Walk(grid, newx, newy, 1, 0, false); // walk right
                return;
            }
        }

        public static long CountEnergizers(int x, int y, int dx, int dy)
        {
            var model = Model.Parse();
            _alreadyWalked = new Dictionary<string, bool>();

            Walk(model.Grid, x, y, dx, dy, true);

            var sum = 0;
            foreach (var c in model.Grid.Coordinates)
            {
                if (c.Value.IsEnergized)
                    sum++;
            }
            return sum;
        }

        public static string Run()
        {
            var model = Model.Parse();

            long maxEnergizers = 0;

            var ss = CountEnergizers(0, 0, 1, 0);
            var bb = ss; // Step 1


            for (var x = 0; x < model.Grid.Width; x++)
            {
                var d = CountEnergizers(x, 0, 0, 1);
                if (d > maxEnergizers)
                    maxEnergizers = d;
                d = CountEnergizers(x, model.Grid.Height - 1, 0, -1);
                if (d > maxEnergizers)
                    maxEnergizers = d;
            }

            for (var y = 0; y < model.Grid.Width; y++)
            {
                var d = CountEnergizers(0, y, 1, 0);
                if (d > maxEnergizers)
                    maxEnergizers = d;
                d = CountEnergizers(model.Grid.Width - 1, y, -1, 0);
                if (d > maxEnergizers)
                    maxEnergizers = d;
            }

            //CountEnergizers(0, 0, 1, 0);

            //Walk(model.Grid, 0, 0, 0, 1);


            model.Grid.DebugWrite();

            return maxEnergizers.ToString();
        }
    }
}
