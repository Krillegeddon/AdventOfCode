using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day04
{
    public class Card
    {
        public int Id;
        public int NumCopies;
        public List<int> WinningNumbers;
        public List<int> GivenNumbers;
    }

    public class Model
    {
        public required Dictionary<int, Card> Cards { get; set; }

        public static Model Parse()
        {
            var retObj = new Model
            {
                Cards = new Dictionary<int, Card>()
            };

            foreach (var lx in Data.InputData.Split("\n"))
            {
                var l = lx.Trim();

                if (string.IsNullOrEmpty(l))
                    continue;

                var arr1 = l.Split(':');
                var arr2 = arr1[1].Split("|");
                var winArr = arr2[0].Split(" ");
                var givenArr = arr2[1].Split(" ");

                var card = new Card()
                {
                    Id = int.Parse(arr1[0].Replace("Card ", "")),
                    NumCopies = 0,
                    WinningNumbers = winArr.Where(p=>!string.IsNullOrEmpty(p)).Select(p => int.Parse(p)).ToList(),
                    GivenNumbers = givenArr.Where(p => !string.IsNullOrEmpty(p)).Select(p => int.Parse(p)).ToList(),
                };
                retObj.Cards.Add(card.Id, card);
            }

            return retObj;
        }
    }
}
