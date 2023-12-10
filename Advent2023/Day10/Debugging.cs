using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day10
{
    internal class Debugging
    {
        private static char ConvertPipeDirection(PipeDirection pipeDirection)
        {
            switch (pipeDirection)
            {
                case PipeDirection.Ground:
                    return '.';
                case PipeDirection.NorthSouth:
                    return '|';
                case PipeDirection.EastWest:
                    return '-';
                case PipeDirection.NorthEast:
                    return 'L';
                case PipeDirection.NorthWest:
                    return 'J';
                case PipeDirection.SouthWest:
                    return '7';
                case PipeDirection.SouthEast:
                    return 'F';
                case PipeDirection.Start:
                    return 'S';
                case PipeDirection.Outside:
                    return '*';
                case PipeDirection.Inside:
                    return '%';
            }
            throw new Exception("Unhandled character");
        }

        public static void DumpToPipesText(Grid g)
        {
            //var sb = new StringBuilder("");

            //for (int y = 0; y < 140; y++)
            //{
            //    for (int x = 0; x < 140; x++)
            //    {
            //        var dir = g.Get(x, y).PipeDirection;
            //        var c = ConvertPipeDirection(dir);
            //        sb.Append(c);
            //    }
            //    sb.Append('\n');
            //}
            //File.WriteAllText("c:\\Temp\\pipes.txt", sb.ToString());
        }
    }
}
