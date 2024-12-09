using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Day09
{
    public class Logic
    {
        private static int CountInArray(List<int> list, int index, int direction)
        {
            var val = list[index];
            var num = 0;
            for (int i = 0; list[index + direction * i] == val; i++)
            {
                if (index + direction * i == 0)
                    return 1000000000;
                num++;
            }
            return num;
        }


        private static List<int> Organize(List<int> fileSystem)
        {
            var retList = fileSystem.ToList();

            for (int rightIndex = retList.Count - 1; rightIndex >= 0; rightIndex--)
            {
                if (retList[rightIndex] == -1)
                    continue;

                var rightLength = CountInArray(retList, rightIndex, -1);

                var hasChanged = false;
                // We have found a number to the right...
                for (int leftIndex = 0; leftIndex < rightIndex; leftIndex++)
                {
                    if (retList[leftIndex] != -1)
                        continue;

                    var leftLength = CountInArray(retList, leftIndex, +1);
                    if (leftLength < rightLength)
                    {
                        // No room here... bump up left counter to skip checking more in this space
                        leftLength += leftLength - 1;
                        continue;
                    }

                    // We have numbers to both left and right. Set the right value on the left side!
                    for (var i = 0; i < rightLength; i++)
                    {
                        retList[leftIndex + i] = retList[rightIndex - i];
                        retList[rightIndex - i] = -1;
                    }

                    hasChanged = true;
                    break;
                }

                if (!hasChanged)
                {
                    // If we didn't find a spot, then we need to make right index to skip the entire block
                    rightIndex -= rightLength - 1;
                }

            }

            return retList;
        }

        public static string Run()
        {
            var model = Model.Parse();

            long sum = 0;

            var fileSystemOrganized = Organize(model.FileSystem);

            for (int i = 0; i < fileSystemOrganized.Count; i++)
            {
                if (fileSystemOrganized[i] < 0)
                    continue;
                sum += i * fileSystemOrganized[i];
            }


            return sum.ToString();
        }
    }
}
