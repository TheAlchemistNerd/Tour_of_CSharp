using System;
using System.Collections.Generic;
using System.Linq;


namespace FaroShuffle
{
    class Program
    {
        static void Main(string[] args)
        {
            // query syntax
            var startingDeck = (from s in Suits().LogQuery("Suit Generation")
                               from r in Ranks().LogQuery("Rank Generation")
                               select new {Suit = s, Rank = r})
                               .LogQuery("Starting Deck")
                               .ToArray();
            // method syntax
            // var startingDeck = Suits().SelectMany(suit => Ranks().Select(rank => new { Suit = suit, Rank = rank }));

            // Display each card that we've generated and placed in startingDeck in the
            foreach (var card in startingDeck)
            {
                Console.WriteLine(card);
            }

            var times = 0;
            // We can re-use the shuffle variable from earier, or you can make a new one
            var shuffle = startingDeck;
            do
            {
                /* out shuffle
                shuffle = shuffle.Take(26)
                .LogQuery("Top Half")
                .InterleaveSequenceWith(shuffle.Skip(26)
                .LogQuery("Bottom Half"))
                .LogQuery("Shuffle")
                .ToArray();
                */

                // in shuffle
                shuffle = shuffle.Skip(26)
                .LogQuery("Bottom Half")
                .InterleaveSequenceWith(shuffle.Take(26)
                .LogQuery("Top Half"))
                .LogQuery("Shuffle")
                .ToArray();
                 
                foreach (var card in shuffle)
                {
                    Console.WriteLine(card);
                }
                Console.WriteLine();
                times++;

            } while (!startingDeck.SequenceEquals(shuffle));
            
            Console.WriteLine(times);
        }

        static IEnumerable<string> Suits()
        {
            yield return "clubs";
            yield return "diamonds";
            yield return "hearts";
            yield return "spades";
        }

        static IEnumerable<string> Ranks()
        {
            yield return "two";
            yield return "three";
            yield return "four";
            yield return "five";
            yield return "six";
            yield return "seven";
            yield return "eight";
            yield return "nine";
            yield return "ten";
            yield return "jack";
            yield return "queen";
            yield return "king";
            yield return "ace";
        }
    }
}