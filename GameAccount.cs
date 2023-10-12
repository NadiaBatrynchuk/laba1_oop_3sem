using System.Transactions;

namespace GameClasses;


public class GameAccount
{
    public string UserName { get; set; }

    int currentrating = 1;
    public int CurrentRating
    {
        get
        {
           return currentrating;
        }

        set{
           if(value<1) {
            currentrating = 1;

           }  else
            currentrating = value;
           
        }
    }
    public int GamesCount { get {return allGameStats.Count;} }
    public List<GameStats> allGameStats = new List<GameStats>(); 

    public GameAccount(string UserName, int BaseRating, int GamesCount)
    {
        this.UserName = UserName;
        this.currentrating = BaseRating;
      
    }

    public void WinGame(GameAccount opponent, int rating, int Counter = 2)
    {
        if(rating < 0) 
        {
            throw new ArgumentOutOfRangeException(nameof(rating), "Game rating mustn't be negative");
        }
        if(Counter == 0) return;
        currentrating += rating;

        allGameStats.Add(new GameStats(rating, opponent.UserName, "Win"));
        opponent.LoseGame(this, rating, --Counter);
    }
    

    public void LoseGame(GameAccount opponent, int rating, int Counter = 2)
    {
        if(rating < 0) 
        {
            throw new ArgumentOutOfRangeException(nameof(rating), "Game rating mustn't be negative");
        }
        if(Counter == 0) return;

        allGameStats.Add(new GameStats(-rating, opponent.UserName, "Lose"));
        opponent.WinGame(this, rating, --Counter);
    }

    public void GetStats()
    {
        Console.WriteLine($"\n--- {this.UserName}'s account game history:");
        Console.WriteLine($"(Current rating: {this.CurrentRating})\n");
        Console.WriteLine("////////////////////");
        foreach(var elem in allGameStats)
        {
            Console.WriteLine($"\nOpponent Name: {elem.OpponentName}");
            Console.WriteLine($"Game Result: {elem.GameResult}");
            Console.WriteLine($"Game rating: {elem.GameRating}");
            Console.WriteLine($"Game ID: {elem.GameID}\n");
            Console.WriteLine("////////////////////");
        }
    }

}