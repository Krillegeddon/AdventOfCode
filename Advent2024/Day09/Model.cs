using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Day09
{
    public class Model
    {
        public required List<int> FileSystem { get; set; }

        public static Model Parse()
        {
            var retObj = new Model
            {
                FileSystem = new List<int>()
            };

            var arr = Data.InputData.ToCharArray();
            var input = arr.Select(p => int.Parse(p.ToString())).ToList();

            var isFile = true;
            var idCount = 0;
            for (int i = 0; i < input.Count; i++)
            {
                var length = input[i];
                if (isFile)
                {
                    for (int j = 0; j < length; j++)
                        retObj.FileSystem.Add(idCount);
                    idCount++;
                }
                else
                {
                    for (int j = 0; j < length; j++)
                        retObj.FileSystem.Add(-1);
                }

                isFile = !isFile;
            }

            return retObj;
        }
    }
}
