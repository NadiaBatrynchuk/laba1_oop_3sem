using GameClasses;


class Lab1
{
    static void Main(string[] args)
    {
        var Player1 = new GameAccount("Vasya", 900, 4);
        var Player2 = new GameAccount("Petya", -450, 2);
        var Player3 = new GameAccount("Kolya", 200, 3);
        try
        {
            Player1.WinGame(Player2, 200);
            Player1.LoseGame(Player3, 350);
        }
        catch(ArgumentOutOfRangeException e)
        {
            Console.WriteLine("Exception caught creating a game with negative rating");
            Console.WriteLine(e.ToString());
            return;
        }
        Player1.GetStats();
        Player2.GetStats();
        Player3.GetStats();
    }
}
    