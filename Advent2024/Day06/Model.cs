using AdventUtils;
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

    public class Grid : GridBase
    {
        public Coord GuardCoord { get; set; }

        public Direction Direction { get; set; }

        public required Dictionary<Coord, List<Direction>> VisitedSquares { get; set; }
        public int NumPossibleLoopObstacles { get; set; }

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
            return IsInside(Coord.Create(GuardCoord.X, GuardCoord.Y));
        }

        public void MarkVisited()
        {
            var guardCoord = Coord.Create(GuardCoord.X, GuardCoord.Y);
            if (!VisitedSquares.ContainsKey(guardCoord))
            {
                VisitedSquares.Add(guardCoord, new List<Direction> { Direction });
            }
            else
            {
                var list = VisitedSquares[guardCoord];
                if (!list.Contains(Direction))
                {
                    list.Add(Direction);
                }
            }
        }

        public Coord GetCoordinatesAfterMove(Direction direction)
        {
            return GetCoordinatesAfterMove(direction, GuardCoord);

        }

        public Coord GetCoordinatesAfterMove(Direction direction, Coord coord)
        {
            var retCoord = coord.Copy();
            switch (direction)
            {
                case Direction.Left:
                    retCoord.X = coord.X - 1;
                    break;
                case Direction.Right:
                    retCoord.X = coord.X +1;
                    break;
                case Direction.Up:
                    retCoord.Y = coord.Y -1;
                    break;
                case Direction.Down:
                    retCoord.Y = coord.Y +1;
                    break;
                default:
                    break;
            }
            return retCoord;
        }

        public void MoveGuard()
        {
            GuardCoord = GetCoordinatesAfterMove(Direction);

            if (IsInside())
                MarkVisited();
        }

        public bool IsObstacleAhead()
        {
            var coord = GetCoordinatesAfterMove(Direction);
            var c = GetChar(coord);
            return c == "#";
        }

        public bool CanEnterLoop()
        {
            // If we place an obstacle on the path where guard has walked before, then we cannot put an 
            // obstacle here - then the guard will not end up here...
            var posKeyGuard = GuardCoord.X + "," + GuardCoord.Y;
            //if (VisitedSquares.ContainsKey(posKeyGuard))
            //{

            //}



            // Get new direction after rotate...
            var direction = GetDirectionAfterRotate();
            Coord coord = Coord.Create(GuardCoord.X, GuardCoord.Y);
            var di = Direction;
            var h = Height;
            var w = Width;

            while (true)
            {
                // Get x/y for if we would take a step in that direction!
                coord = GetCoordinatesAfterMove(direction, coord);

                // If we are on obstacle, or outside... then it's not possible to put a mark here.
                var c = GetChar(coord);
                if (c != ".")
                    return false;

                if (VisitedSquares.ContainsKey(coord))
                {
                    if (VisitedSquares[coord].Where(p => p == direction).Any())
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
                    VisitedSquares = new Dictionary<Coord, List<Direction>>()
                }
            };

            var y = 0;
            foreach (var lx in Data.InputData.Split("\n"))
            {
                var l = lx.Trim();

                if (string.IsNullOrEmpty(l))
                    continue;

                var arr = l.ToCharArray();
                for (var i = 0; i< arr.Length; i++)
                {
                    var c = arr[i];
                    if (c.ToString() == "^")
                    {
                        retObj.Grid.Direction = Direction.Up;
                        retObj.Grid.GuardCoord = Coord.Create(i, y);
                        retObj.Grid.MarkVisited();
                        c = '.';
                    }

                    retObj.Grid.SetChar(Coord.Create(i, y), c.ToString());
                }
                y++;
            }

            return retObj;
        }
    }
}
