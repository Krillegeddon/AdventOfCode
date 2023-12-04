using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Advent2023.Day04
{
    public class Logic
    {
        public class CardQueue
        {
            public List<Card> Cards = new List<Card>();

            public void Add(Card card, int numCopies)
            {
                foreach (var c in Cards)
                {
                    if (c == card)
                    {
                        card.NumCopies += numCopies;
                        return;
                    }
                }
                card.NumCopies += numCopies;
                Cards.Add(card);
            }

            public Card Dequeue()
            {
                if (Cards.Count == 0)
                    return null;

                var retObj = Cards[0];
                Cards.RemoveAt(0);
                return retObj;
            }
        }

        private static int CountCorrectNumbers(Card card)
        {
            var points = 0;
            foreach (var givenNum in card.GivenNumbers)
            {
                if (card.WinningNumbers.Contains(givenNum))
                {
                    points++;
                }
            }
            return points;
        }

        public static string Run()
        {
            var model = Model.Parse();

            long sum = 0;

            var queue = new CardQueue();

            foreach (var card in model.Cards)
            {
                // Add each card to the queue and set it to be one copy of each.
                queue.Add(card.Value, 1);
            }

            while (queue.Cards.Count > 0)
            {
                var card = queue.Dequeue();
                var points = CountCorrectNumbers(card);

                for (var i = 0; i < points; i++)
                {
                    var newCard = model.Cards[card.Id + 1 + i];
                    // Add the newCard with as many copies as current card has.
                    queue.Add(newCard, card.NumCopies);
                }
            }

            foreach (var c in model.Cards)
            {
                sum += c.Value.NumCopies;
            }

            return sum.ToString(); //5539496
        }
    }
}
