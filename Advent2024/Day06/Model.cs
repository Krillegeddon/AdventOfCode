using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Day06
{
    public class Grid
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public int GuardX { get; set; }
        public int GuardY { get; set; }
        public int GuardDeltaX { get; set; }
        public int GuardDeltaY { get; set; }

        public required List<List<string>> Arr { get; set; }

        public required Dictionary<string, bool> VisitedSquares { get; set; }

        public string GetChar(int x, int y)
        {
            if (x < 0 || y < 0)
                return "";

            if (y >= Arr.Count)
                return "";
            if (x >= Arr[y].Count)
                return "";
            return Arr[y][x];
        }

        public void RotateGuardClockwise()
        {
            // Going down, should end up by going to the left...
            if (GuardDeltaX == 0 && GuardDeltaY == 1)
            {
                GuardDeltaX = -1;
                GuardDeltaY = 0;
                return;
            }

            // Going up, should end up by going to the right...
            if (GuardDeltaX == 0 && GuardDeltaY == -1)
            {
                GuardDeltaX = 1;
                GuardDeltaY = 0;
                return;
            }

            // Going right, should end up by going down...
            if (GuardDeltaX == 1 && GuardDeltaY == 0)
            {
                GuardDeltaX = 0;
                GuardDeltaY = 1;
                return;
            }

            // Going left, should end up by going up...
            if (GuardDeltaX == -1 && GuardDeltaY == 0)
            {
                GuardDeltaX = 0;
                GuardDeltaY = -1;
                return;
            }
        }

        public bool IsInside()
        {
            if (GuardX < 0)
                return false;
            if (GuardY < 0)
                return false;
            if (GuardX > Width-1)
                return false;
            if (GuardY > Height-1)
                return false;
            return true;
        }

        public void MarkVisited()
        {
            var posKey = GuardX + "," + GuardY;
            if (!VisitedSquares.ContainsKey(posKey))
                VisitedSquares.Add(posKey, true);
        }

        public void MoveGuard()
        {
            GuardX += GuardDeltaX;
            GuardY += GuardDeltaY;
            if (IsInside())
                MarkVisited();
        }

        public bool IsObstacleAhead()
        {
            var c = GetChar(GuardX + GuardDeltaX, GuardY + GuardDeltaY);
            return c == "#";
        }
    }



    public class Model
    {
        public Grid Grid { get; set; }

        public static Model Parse()
        {
            var retObj = new Model
            {
                Grid = new Grid()
                {
                    Arr = new List<List<string>>(),
                    VisitedSquares = new Dictionary<string, bool>()
                }
            };

            foreach (var lx in Data.InputData.Split("\n"))
            {
                var l = lx.Trim();

                if (string.IsNullOrEmpty(l))
                    continue;

                var row = new List<string>();
                var arr = l.ToCharArray();
                for (var i = 0; i< arr.Length; i++)
                {
                    var c = arr[i];
                    if (c.ToString() == "^")
                    {
                        retObj.Grid.GuardDeltaY = -1;
                        retObj.Grid.GuardDeltaX = 0;
                        retObj.Grid.GuardX = i;
                        retObj.Grid.GuardY = retObj.Grid.Height;
                        retObj.Grid.MarkVisited();
                        c = '.';
                    }

                    row.Add(c.ToString());
                }
                retObj.Grid.Arr.Add(row);
                retObj.Grid.Height++;
                if (row.Count > retObj.Grid.Width)
                {
                    retObj.Grid.Width = row.Count;
                }
            }

            return retObj;
        }
    }
}
