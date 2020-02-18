namespace blackjack
{
  public class card
  {
    // value
    //rank
    public string Rank { get; set; }
    //suit
    public string Suit { get; set; }
    //color
    public string Color { get; set; }

    //method
    public string DisplayCard()
    {
      return $"{Rank} of {Suit}";
    }

    public int GetValue()
    {
      if (Rank == "ace")
      {
        return 11;

      }
      if (Rank == "queen" || Rank == "king" || Rank == "jack")
      {
        return 10;
      }
      if (Rank == "2")
      {
        return 2;
      }
      if (Rank == "3")
      {
        return 3;
      }
      if (Rank == "4")
      {
        return 4;
      }
      if (Rank == "5")
      {
        return 5;
      }
      if (Rank == "6")
      {
        return 6;
      }
      if (Rank == "7")
      {
        return 7;
      }
      if (Rank == "8")
      {
        return 8;
      }
      if (Rank == "9")
      {
        return 9;
      }
      if (Rank == "10")
      {
        return 10;
      }
      else
      {
        return int.Parse(Rank);
      }
    }
  }
}