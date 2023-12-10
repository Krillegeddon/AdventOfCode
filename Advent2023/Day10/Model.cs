using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day10
{
    public enum PipeDirection
    {
        NorthSouth,
        EastWest,
        NorthEast,
        NorthWest,
        SouthWest,
        SouthEast,
        Start,
        Ground,
        Outside,
        Inside
    }

    public class Coordinate
    {
        public int X;
        public int Y;
        public PipeDirection PipeDirection;
    }

    public class Grid
    {
        public List<Coordinate> Cells;

        public void Set(int x, int y, PipeDirection pipeDirection)
        {
            var cell = Get(x, y);
            cell.PipeDirection = pipeDirection;
        }

        public Coordinate Get(int x, int y)
        {
            var coordinate = Cells.Where(p=>p.X == x && p.Y == y).FirstOrDefault();

            if (coordinate == null)
            {
                coordinate = new Coordinate { X = x, Y = y, PipeDirection = PipeDirection.Ground };
                Cells.Add(coordinate);
            }
                
            return coordinate;
        }

        public void SetOutside(int x, int y)
        {
            var coord = Get(x, y);
            if (coord.PipeDirection == PipeDirection.Ground)
            {
                coord.PipeDirection = PipeDirection.Outside;
            }
        }
    }

    public class Model
    {
        public required Grid Grid { get; set; }

        public static Model Parse()
        {
            var retObj = new Model
            {
                Grid = new Grid
                {
                    Cells = new List<Coordinate>()
                }
            };

            var y = 0;

            foreach (var lx in Data.InputData.Split("\n"))
            {
                var l = lx.Trim();

                if (string.IsNullOrEmpty(l))
                    continue;

                var arr = l.ToCharArray();
                for (int x = 0; x < arr.Length; x++)
                {
                    PipeDirection pipeDirection = PipeDirection.Ground;
                    switch (arr[x])
                    {
                        case '.':
                            pipeDirection = PipeDirection.Ground;
                            break;
                        case '|':
                            pipeDirection = PipeDirection.NorthSouth;
                            break;
                        case '-':
                            pipeDirection = PipeDirection.EastWest;
                            break;
                        case 'L':
                            pipeDirection = PipeDirection.NorthEast;
                            break;
                        case 'J':
                            pipeDirection = PipeDirection.NorthWest;
                            break;
                        case '7':
                            pipeDirection = PipeDirection.SouthWest;
                            break;
                        case 'F':
                            pipeDirection = PipeDirection.SouthEast;
                            break;
                        case 'S':
                            pipeDirection = PipeDirection.Start;
                            break;
                        default:
                            throw new Exception("Unhandled character");
                            break;

                    }

                    retObj.Grid.Set(x, y, pipeDirection);
                }

                y++;
            }

            var ll = retObj.Grid.Cells.Last();

            return retObj;
        }
    }
}
