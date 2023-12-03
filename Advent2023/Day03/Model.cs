using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day03
{
    public class Coordinate
    {
        public int X;
        public int Y;
    }

    public class SymbolCoord
    {
        public Coordinate Coordinate;
        public char Symbol;
        public List<PartnumberCoord> AdjPartnumbers;
    }

    public class PartnumberCoord
    {
        public Coordinate Coordinate;
        public string Partnumber;
    }

    public class Model
    {
        public required List<PartnumberCoord> PartnumberCoords { get; set; }
        public required List<SymbolCoord> SymbolCoords { get; set; }

        public static Model Parse()
        {
            var retObj = new Model
            {
                PartnumberCoords = new List<PartnumberCoord>(),
                SymbolCoords = new List<SymbolCoord>()
            };

            int y = 0;
            foreach (var lx in Data.InputData.Split("\n"))
            {
                var l = lx.Trim() + "."; // To find part numbers that end on the last char of a line...

                if (string.IsNullOrEmpty(l))
                    continue;

                int x = 0;
                bool isInNumber = false;
                string currentPartNum = "";
                int currentX = 0;
                foreach (var c in l.ToCharArray())
                {
                    if (c >= '0' && c <= '9')
                    {
                        if (!isInNumber)
                        {
                            currentPartNum = "";
                            isInNumber = true;
                            currentX = x;
                        }
                        currentPartNum += c.ToString();
                        x++;
                        continue;
                    }

                    if (isInNumber)
                    {
                        isInNumber = false;
                        var pn = new PartnumberCoord()
                        {
                            Partnumber = currentPartNum,
                            Coordinate = new Coordinate()
                            {
                                X = currentX,
                                Y = y
                            }
                        };
                        retObj.PartnumberCoords.Add(pn);
                    }


                    if (c == '.')
                    {
                        x++;
                        continue;
                    }

                    // Loose char... add its coordinates
                    retObj.SymbolCoords.Add(new SymbolCoord()
                    {
                        Coordinate = new Coordinate
                        {
                            X = x,
                            Y = y,
                        },
                        Symbol = c,
                        AdjPartnumbers = new List<PartnumberCoord>()
                    });

                    x++;
                }


                y++;
            }

            return retObj;
        }
    }
}
