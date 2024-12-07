using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Day06
{
    public enum Direction
    {
        Up,
        Down,
        Right,
        Left
    }

    public class Grid
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public int GuardX { get; set; }
        public int GuardY { get; set; }

        public Direction Direction { get; set; }

        public required List<List<string>> Arr { get; set; }

        public required Dictionary<string, List<Direction>> VisitedSquares { get; set; }
        public int NumPossibleLoopObstacles { get; set; }

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

        public Direction GetDirectionAfterRotate()
        {
            // Going down, should end up by going to the left...
            if (Direction == Direction.Down)
            {
                return Direction.Left;
            }

            // Going up, should end up by going to the right...
            if (Direction == Direction.Up)
            {
                return Direction.Right;
            }

            // Going right, should end up by going down...
            if (Direction == Direction.Right)
            {
                return Direction.Down;
            }
            // Going left, should end up by going up...
            if (Direction == Direction.Left)
            {
                return Direction.Up;
            }
            throw new Exception("Could not happen!");
        }

        public void RotateGuardClockwise()
        {
            Direction = GetDirectionAfterRotate();
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
            {
                VisitedSquares.Add(posKey, new List<Direction> { Direction });
            }
            else
            {
                var list = VisitedSquares[posKey];
                if (!list.Contains(Direction))
                {
                    list.Add(Direction);
                }
            }
        }

        public void GetCoordinatesAfterMove(Direction direction, out int xout, out int yout)
        {
            GetCoordinatesAfterMove(direction, GuardX, GuardY, out xout, out yout);

        }

        public void GetCoordinatesAfterMove(Direction direction, int x, int y, out int xout, out int yout)
        {
            xout = x;
            yout = y;
            switch (direction)
            {
                case Direction.Left:
                    xout = x-1;
                    break;
                case Direction.Right:
                    xout = x+1;
                    break;
                case Direction.Up:
                    yout = y-1;
                    break;
                case Direction.Down:
                    yout = y+1;
                    break;
                default:
                    break;
            }
        }

        public void MoveGuard()
        {
            int x, y;
            GetCoordinatesAfterMove(Direction, out x, out y);
            GuardX = x;
            GuardY = y;

            if (IsInside())
                MarkVisited();
        }

        public bool IsObstacleAhead()
        {
            var x = 0;
            var y = 0;
            GetCoordinatesAfterMove(Direction, out x, out y);
            var c = GetChar(x, y);
            return c == "#";
        }

        public bool CanEnterLoop()
        {
            // If we place an obstacle on the path where guard has walked before, then we cannot put an 
            // obstacle here - then the guard will not end up here...
            var posKeyGuard = GuardX + "," + GuardY;
            if (VisitedSquares.ContainsKey(posKeyGuard))
            {

            }



            // Get new direction after rotate...
            var direction = GetDirectionAfterRotate();
            int x = GuardX;
            int y = GuardY;
            var di = Direction;
            var h = Height;
            var w = Width;

            while (true)
            {
                // Get x/y for if we would take a step in that direction!
                GetCoordinatesAfterMove(direction, x, y, out x, out y);

                // If we are on obstacle, or outside... then it's not possible to put a mark here.
                var c = GetChar(x, y);
                if (c != ".")
                    return false;

                var posKey = x + "," + y;
                if (VisitedSquares.ContainsKey(posKey))
                {
                    if (VisitedSquares[posKey].Where(p => p == direction).Any())
                        return true;
                }
            }
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
                    VisitedSquares = new Dictionary<string, List<Direction>>()
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
                        retObj.Grid.Direction = Direction.Up;
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
