using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day07
{
    public class Hand
    {
        public List<int> Cards;
        public List<int> CardsUnsorted;
        public List<int> Jacks;
        public long BidAmount;
        public long Score;
        public int Rank;

    }

    public class Model
    {
        public required List<Hand> Hands { get; set; }

        public static Model Parse()
        {
            var retObj = new Model
            {
                Hands = new List<Hand>()
            };

            var convDict = new Dictionary<char, int>()
            {
                { '2', 2 },
                { '3', 3 },
                { '4', 4 },
                { '5', 5 },
                { '6', 6 },
                { '7', 7 },
                { '8', 8 },
                { '9', 9 },
                { 'T', 10 },
                { 'J', 1 },
                { 'Q', 12 },
                { 'K', 13 },
                { 'A', 14 },
            };
            foreach (var lx in Data.InputData.Split("\n"))
            {
                var l = lx.Trim();

                if (string.IsNullOrEmpty(l))
                    continue;


                var bidArr = l.Split(" ");
                var hand = new Hand()
                {
                    BidAmount = long.Parse(bidArr[1]),
                    CardsUnsorted = new List<int>()
                };

                var cards = bidArr[0].ToCharArray();
                foreach (var cardChar in cards)
                {
                    hand.CardsUnsorted.Add(convDict[cardChar]);
                }

                int bb = 9;
                hand.Cards = hand.CardsUnsorted.Where(p=>p != 1).OrderBy(p => p).ToList();
                hand.Jacks = hand.CardsUnsorted.Where(p => p == 1).OrderBy(p => p).ToList();
                retObj.Hands.Add(hand);
            }

            return retObj;
        }
    }
}
