using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day05
{
    public class Range
    {
        public long SourceID;
        public long DestinationID;
        public long Length;
        public long SourceEnd { get { return SourceID + Length - 1; } }

        [DebuggerHidden]
        public long GetDestinationId(long currentId)
        {
            if (currentId >= SourceID && currentId < SourceID + Length)
            {
                var offset = currentId - SourceID;
                return DestinationID + offset;
            }
            return -1;
        }
    }

    public class Map
    {
        public int Id;
        public string Name;
        public List<Range> Ranges;
    }

    public class SeedRange
    {
        public long From;
        public long To;
    }

    public class Model
    {
        public required List<long> Seeds { get; set; }
        public required List<SeedRange> SeedRanges { get; set; }
        public required List<Map> Maps { get; set; }


        public static Model Parse()
        {
            var retObj = new Model
            {
                Seeds = new List<long>(),
                SeedRanges = new List<SeedRange>(),
                Maps = new List<Map>(),
            };

            var hasReadSeeds = false;
            var isInMap = false;

            Map currentMap = null;

            foreach (var lx in Data.InputData.Split("\n"))
            {
                var l = lx.Trim();

                if (!hasReadSeeds)
                {
                    var seedArr = l.Split(" ");
                    foreach (var seed in seedArr)
                    {
                        long o;
                        if (long.TryParse(seed, out o))
                        {
                            retObj.Seeds.Add(o);
                        }
                    }
                    hasReadSeeds = true;

                    for (int i = 0; i < retObj.Seeds.Count; i += 2)
                    {
                        retObj.SeedRanges.Add(new SeedRange()
                        {
                            From = retObj.Seeds[i],
                            To = retObj.Seeds[i] + retObj.Seeds[i+1] - 1
                        });
                    }

                    continue;
                }

                if (l.Contains(" map:"))
                {
                    isInMap = true;
                    currentMap = new Map()
                    {
                        Id = retObj.Maps.Count,
                        Name = l,
                        Ranges = new List<Range>()
                    };
                    continue;
                }

                if (string.IsNullOrEmpty(l))
                {
                    if (currentMap != null)
                    {
                        retObj.Maps.Add(currentMap);
                        currentMap = null;
                    }
                    continue;
                }

                // Normal line with ranges...
                var rarr = l.Split(" ");
                var r = new Range()
                {
                    DestinationID = long.Parse(rarr[0]),
                    SourceID = long.Parse(rarr[1]),
                    Length = long.Parse(rarr[2])
                };
                currentMap.Ranges.Add(r);
            }

            return retObj;
        }
    }
}
