using Advent2023.Day04;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day07
{
    public class Logic
    {
        private static int GetCard(Hand hand, int index)
        {
            if (index < 0)
                return -1;
            if (index >= hand.Cards.Count)
                return -1;
            return hand.Cards[index];
        }

        public static List<int> GetGroup(Hand hand, int numOfAKind)
        {
            var retList = new List<int>();
            for (int i = 1; i < hand.Cards.Count; i++)
            {
                var currentCard = GetCard(hand, i);

                // The card after current must be different in order for it to be a match.
                if (GetCard(hand, i + 1) == currentCard)
                    continue;

                // If we are looking for three of a kind, and we are on i=4, then index 4, 3, 2 need to be the same
                // ... BUT 1 (i-numOfAKind) must be different.
                if (GetCard(hand, i - numOfAKind) == currentCard)
                    continue;

                var allSame = true;
                for (int j = 0; j < numOfAKind; j++)
                {
                    // All cards between i and i-numOfAKind should be the same. outside should be different (already checked).
                    if (GetCard(hand, i - j) != currentCard)
                        allSame = false;
                }

                if (allSame)
                    retList.Add(currentCard);
            }

            return retList;
        }



        public static string Run()
        {
            var model = Model.Parse();

            // Calculate score on each hand
            foreach (var hand in model.Hands)
            {
                var kScore = 0;

                for (var k = 2; k <= hand.Cards.Count; k++)
                {
                    var kList = GetGroup(hand, k);
                    if (kList.Count == 1)
                    {
                        kScore = k * 2;
                    }
                    if (kList.Count == 2)
                    {
                        kScore = k * 2 + 1; // Two-pairs...
                    }
                    if (k == 3 && kList.Count == 1)
                    {
                        var p = GetGroup(hand, 2);
                        if (p.Count == 1)
                        {
                            // Full-house!
                            kScore = k * 2 + 1;
                        }
                    }
                }

                var numJacks = hand.Jacks.Count;
                if (numJacks == 1)
                {
                    if (kScore < 4) // nothing
                    {
                        kScore = 4; // pair at least!
                    }
                    else if (kScore == 6) // Three of a kind...
                    {
                        kScore = 8; // ... becomes four of a kind.
                    }
                    else if (kScore == 5) // Two-pairs...
                    {
                        kScore = 7; // becomes a Fullhouse instead!
                    }
                    else if (kScore == 8) // Four of a kind...
                    {
                        kScore = 10; // ... becomes 5 of a kind.
                    }
                    else if (kScore == 4) // pair...
                    {
                        kScore = 6; // ... becomes three of a kind.
                    }
                }

                if (numJacks == 2)
                {
                    if (kScore < 4) // nothing
                    {
                        kScore = 6; // three of a kind
                    }
                    else if (kScore == 4) // pair
                    {
                        kScore = 8; // four of a kind
                    }
                    else if (kScore == 6) // triss
                    {
                        kScore = 10; // femtal
                    }
                }

                if (numJacks == 3)
                {
                    if (kScore < 4) // nothing
                    {
                        kScore = 8; // four of a kind
                    }
                    else if (kScore == 4) // pair
                    {
                        kScore = 10; // five of a kind
                    }
                }

                if (numJacks == 4 || numJacks == 5)
                {
                    kScore = 10; // Whatever the non-jack card is, the jacks will be the same and become five of a kind!
                }

                hand.Score = kScore * 10000000000;
                hand.Score += hand.CardsUnsorted[0] * 100000000;
                hand.Score += hand.CardsUnsorted[1] * 1000000;
                hand.Score += hand.CardsUnsorted[2] * 10000;
                hand.Score += hand.CardsUnsorted[3] * 100;
                hand.Score += hand.CardsUnsorted[4] * 1;
            }

            // Set rank on every hand
            int r = 1;
            foreach (var hand in model.Hands.OrderBy(p => p.Score).ToList())
            {
                hand.Rank = r;
                r++;
            }

            // Calculate sum of all rank * bid.
            long sum = 0;
            foreach (var hand in model.Hands)
            {
                var bid = hand.Rank * hand.BidAmount;
                sum += bid;
            }

            return sum.ToString();
        }
    }
}
