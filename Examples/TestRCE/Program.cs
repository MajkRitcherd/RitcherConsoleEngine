using TestRCE;

using (var game = new TestGame(200, 70))
{
    game.Run();

}

// Wait so we can see the console
Console.ReadKey();