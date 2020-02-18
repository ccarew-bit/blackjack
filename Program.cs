using System;
using System.Collections.Generic;

namespace blackjack
{
  class Program
  {
    static void Main(string[] args)
    {
      var suits = new List<string> { "clubs", "hearts", "diamonds", "spades" };
      var rank = new List<string> { "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king", "ace" };
      var deck = new List<card>();
      for (var i = 0; i < suits.Count; i++)
      {
        for (var j = 0; j < rank.Count; j++)
        {
          var card = new card();
          card.Rank = rank[j];
          card.Suit = suits[i];
          if (card.Suit == "diamonds" || card.Suit == "hearts")
          {
            card.Color = "black";
          }
          else
          {
            card.Color = "red";
          }
          deck.Add(card);
        }
      }
      for (var i = deck.Count - 1; i >= 1; i--)
      {
        var j = new Random().Next(i);

        var temp = (deck[j]);
        deck[j] = (deck[i]);
        deck[i] = temp;

      }
      Console.WriteLine("Welcome to Blackjack!");
      var playAgain = true;
      while (playAgain && deck.Count > 0)
      {
        var playerHand = new List<card>();
        var dealerHand = new List<card>();
        playerHand.Add(deck[0]);
        playerHand.Add(deck[1]);
        deck.RemoveAt(0);
        deck.RemoveAt(1);
        dealerHand.Add(deck[0]);
        dealerHand.Add(deck[1]);
        deck.RemoveAt(0);
        deck.RemoveAt(1);
        Console.WriteLine($"this is your first card {playerHand[0].DisplayCard()} has the value of {playerHand[0].GetValue()}");
        Console.WriteLine($"this is your second card {playerHand[1].DisplayCard()} has the value of {playerHand[1].GetValue()}");
        Console.WriteLine($"this the dealers first card {dealerHand[0].DisplayCard()} has the value of {dealerHand[0].GetValue()}");
        Console.WriteLine($"player has {playerHand.Count} card");
        var playerTotal = 0;
        for (int i = 0; i < playerHand.Count; i++)
        {
          playerTotal += playerHand[i].GetValue();
        }
        var dealerTotal = 0;
        for (int i = 0; i < dealerHand.Count; i++)
        {
          dealerTotal += dealerHand[i].GetValue();
        }
        Console.WriteLine($"player total is {playerTotal}");
        if (playerTotal < 21)
        {
          Console.WriteLine("would you like to (HIT) or(QUIT)?");
          var hitQuit = Console.ReadLine();
          if (hitQuit == "hit")
          {
            playerHand.Add(deck[0]);
            deck.RemoveAt(0);
            Console.WriteLine($"this is your additional card {playerHand[0].DisplayCard()}");
            for (int i = 0; i < playerHand.Count; i++)
            {
              playerTotal += playerHand[i].GetValue();
            }
            if (playerTotal > 21)
            {
              Console.WriteLine("BUST!");
              Console.WriteLine($"your score is {playerTotal}");
              Console.WriteLine($"dealer score is {dealerTotal}");
            }
            else if (dealerTotal > 21)
            {
              Console.WriteLine("you WIN!");
              Console.WriteLine($"your score is {playerTotal}");
              Console.WriteLine($"dealer score is {dealerTotal}");
            }
            else if (playerTotal == 21)
            {
              Console.WriteLine("you win!");
              Console.WriteLine($"your score is {playerTotal}");
              Console.WriteLine($"dealer score is {dealerTotal}");
            }
            else if (playerTotal == dealerTotal)
            {
              Console.WriteLine("dealer wins!");
              Console.WriteLine($"your score is {playerTotal}");
              Console.WriteLine($"dealer score is {dealerTotal}");
            }
            else if (playerTotal < dealerTotal)
            {
              Console.WriteLine("dealer wins!");
              Console.WriteLine($"your score is {playerTotal}");
              Console.WriteLine($"dealer score is {dealerTotal}");
            }
            Console.WriteLine($"player total is {playerTotal}");
          }
          if (hitQuit == "quit")
          {
            Console.WriteLine($"your score is {playerTotal}");
            Console.WriteLine($"the dealers total is {dealerTotal}");
            while (dealerTotal < 15)
            {
              dealerHand.Add(deck[0]);
              Console.WriteLine("dealer hit");
              Console.WriteLine($"dealer got a {deck[0].DisplayCard()}");
              deck.Remove(deck[0]);
              for (int i = 0; i < dealerHand.Count; i++)
              {
                dealerTotal += dealerHand[i].GetValue();
              }
              if (dealerTotal > 15)
              {
                break;
              }
            }
            if (playerTotal > 21)
            {
              Console.WriteLine("BUST!");
              Console.WriteLine($"your score is {playerTotal}");
              Console.WriteLine($"dealer score is {dealerTotal}");
            }
            else if (dealerTotal > 21)
            {
              Console.WriteLine("you WIN!");
              Console.WriteLine($"your score is {playerTotal}");
              Console.WriteLine($"dealer score is {dealerTotal}");
            }
            else if (playerTotal == 21)
            {
              Console.WriteLine("you win!");
              Console.WriteLine($"your score is {playerTotal}");
              Console.WriteLine($"dealer score is {dealerTotal}");
            }
            else if (playerTotal == dealerTotal)
            {
              Console.WriteLine("dealer wins!");
              Console.WriteLine($"your score is {playerTotal}");
              Console.WriteLine($"dealer score is {dealerTotal}");
            }
            else if (playerTotal < dealerTotal)
            {
              Console.WriteLine("dealer wins!");
              Console.WriteLine($"your score is {playerTotal}");
              Console.WriteLine($"dealer score is {dealerTotal}");
            }
          }
        }

        Console.WriteLine("would you like to play again?");
        var answer = Console.ReadLine().ToLower();
        if (answer == "yes")
        {
          playAgain = true;
        }
        if (answer != "yes")
        {
          Console.WriteLine("Thanks for playing blackjack!, goodbye!");
          playAgain = false;
        }
      }
    }
  }
}
