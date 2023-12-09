using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day08
{
    public class Node
    {
        public string Code;
        public string Left;
        public string Right;
    }

    public class Model
    {
        public required List<char> Path { get; set; }

        public required Dictionary<string, Node> Nodes { get; set; }

        public static Model Parse()
        {
            var retObj = new Model
            {
                Path = new List<char>(),
                Nodes = new Dictionary<string, Node>()
            };

            foreach (var lx in Data.InputData.Split("\n"))
            {
                var l = lx.Trim();

                if (string.IsNullOrEmpty(l))
                    continue;

                if (retObj.Path.Count == 0)
                {
                    var arr = l.ToCharArray();
                    retObj.Path = arr.ToList();
                    continue;
                }

                var farr = l.Split("=");
                var code = farr[0].Trim();
                var narr = farr[1].Replace("(", "").Replace(")", "").Split(",");

                var node = new Node()
                {
                    Code = code,
                    Left = narr[0].Trim(),
                    Right = narr[1].Trim()
                };

                retObj.Nodes.Add(code, node);
            }

            return retObj;
        }
    }
}
