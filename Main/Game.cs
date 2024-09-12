using System.Data;

namespace Main;

public class Game
{
    public bool ValidateArgument(string[] moves)
    {
        var invalidLength = ValidationError.InvalidLength;
        var invalidArguments = ValidationError.InvalidArguments;
        
        var isValid = moves.Length >= 3 && moves.Length % 2 == 1;

        if (!isValid)
        {
            Console.WriteLine(invalidLength.ToString());
            return isValid;
        }

        foreach (var move in moves)
        {
            if (moves.Count(x => x.Equals(move)) > 1)
            {
                Console.WriteLine(invalidArguments.ToString());
                return !isValid;
            }

        }

        return isValid;
    }

    public void DisplayTheMain(string[] moves)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("+-------------+------+-------+----------+");
        Console.Write("| v PC\\User > |");
        foreach (var move in moves)
        {
            Console.Write($" {move,-6} |");
        }
        Console.WriteLine();
        Console.WriteLine("+-------------+------+-------+----------+");
        Console.ResetColor();

        foreach (var rowMove in moves)
        {
            Console.Write(value: $"| {rowMove,-12} |");
            foreach (var columnMove in moves)
            {
                string result = GetGameResult(Array.IndexOf(moves, columnMove), Array.IndexOf(moves, rowMove), moves.Length);
                Console.Write($" {result,-5} |");
            }
            Console.WriteLine();
            Console.WriteLine("+-------------+------+-------+----------+");
        }
    }

    public void DisplayAvailabeMovements(string[] moves)
    {
        Console.WriteLine("Available movements:\n");
        for(var i =0; i<moves.Length; i++)
        {
            Console.WriteLine($"{i+1} - {moves[i]}");
        }
        Console.Write("0 - exit\n? - help\n\nEnter your move: ");
    }

    public string GetGameResult(int column, int row, int count)
    {
        //Console.WriteLine($"Column: {column+1}\nRow: {row+1}\nCount: {count}\n");
        var p = count / 2;
        var result = (column - row + p + count) % count - p;  

        if (result == 0)
            return "Draw";

        else if (result > 0)
            return "Win";
        else 
            return "Lose";
    }
}
