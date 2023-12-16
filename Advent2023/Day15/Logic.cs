using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day15
{
    public class Logic
    {
        private static int CalculateHash(string s)
        {
            var arr = s.ToCharArray();
            int res = 0;

            foreach (var i in arr)
            {
                res += i;
                res *= 17;
                res = res % 256;
            }
            return res;
        }


        public static string Run()
        {
            //var rr = CalculateHash("ab");

            var model = Model.Parse();

            var boxes = new Dictionary<int, List<Lens>>();
            foreach (var lens in model.Lenses)
            {
                var boxId = CalculateHash(lens.Code);
                if (lens.Operator == '-')
                {
                    List<Lens> box = null;
                    if (boxes.ContainsKey(boxId))
                    {
                        box = boxes[boxId];
                    }
                    if (box == null)
                    {
                        continue;
                    }
                        // We have the same code in this box, replace it!
                    var boxToRemove = box.Where(p => p.Code == lens.Code).FirstOrDefault();
                    if (boxToRemove != null)
                    {
                        box.Remove(boxToRemove);
                    }

                }
                else
                {
                    List<Lens> box;
                    if (boxes.ContainsKey(boxId))
                    {
                        box = boxes[boxId];
                    }
                    else
                    {
                        box = new List<Lens>();
                        boxes.Add(boxId, box);
                    }
                    if (box.Where(p => p.Code == lens.Code).Any())
                    {
                        // We have the same code in this box, replace it!
                        var lensToReplace = box.Where(p => p.Code == lens.Code).Single();
                        lensToReplace.Value = lens.Value;
                    }
                    else
                    {
                        box.Add(lens);
                    }
                }
                //sum += CalculateHash(s);
            }

            long sum = 0;
            foreach (var boxKvp in boxes)
            {
                var boxId = boxKvp.Key + 1;
                var lenses = boxKvp.Value;
                for (int i = 0; i < lenses.Count; i++)
                {
                    var slotId = i + 1;
                    sum += (boxId * slotId * lenses[i].Value);
                }
            }


            return sum.ToString();
        }
    }
}
