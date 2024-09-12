namespace Main;

public class Player
{
    public int ChooseTheMove(int moves) 
    {
        var random = new Random();

        return random.Next(1, moves + 1);
    }
}
