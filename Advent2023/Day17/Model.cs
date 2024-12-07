using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day17;

public class Block
{
    public int HeatLoss;
    public bool IsVisited;
}

public class Model
{
    public required List<List<Block>> Blocks { get; set; }

    public static Model Parse()
    {
        var retObj = new Model
        {
            Blocks = new List<List<Block>>()
        };

        foreach (var lx in Data.InputData.Split("\n"))
        {
            var l = lx.Trim();

            if (string.IsNullOrEmpty(l))
                continue;

            var currentList = new List<Block>();
            var arr = l.ToCharArray();
            for (var x = 0; x < arr.Length; x++)
            {
                currentList.Add(new Block()
                {
                    HeatLoss = int.Parse(arr[x].ToString()),
                    IsVisited = false
                });
            }
            retObj.Blocks.Add(currentList);
        }
        return retObj;
    }
}
