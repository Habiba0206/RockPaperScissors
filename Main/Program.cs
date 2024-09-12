using Main;

var moves = args; 
var hMacGenerator = new HMACGenerator();
var game = new Game();
var player = new Player();


while (true)
{
    if (!game.ValidateArgument(moves))
    {
        break; 
    }
    var secureKey = hMacGenerator.GenerateSecureKey();
    var choise = player.ChooseTheMove(moves.Length) - 1;
   var computerMove = moves[choise];
    Console.WriteLine($"HMAC:{hMacGenerator.ComputeHMAC(computerMove, secureKey)}\n");
    game.DisplayAvailabeMovements(moves);
    var yourMove = Console.ReadLine();

    if (yourMove == "0")
    {
        break;
    }
    else if (yourMove == "?")
    {
        game.DisplayTheMain(moves);
    }
    else if (int.TryParse(yourMove, out int number))
    {
        Console.WriteLine($"Your move: {moves[number - 1]}\nComputer's move: {computerMove}\n");
        var result = game.GetGameResult(number - 1, Array.IndexOf(moves, computerMove),  moves.Length);
        Console.WriteLine($"You {result}");
        Console.WriteLine($"HMAC key: {hMacGenerator.ConvertKeyToHex(secureKey)}\n");
    }
    else 
    {
        Console.WriteLine("Wrong command!");
    }
}
