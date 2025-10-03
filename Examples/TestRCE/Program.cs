using TestRCE;

using (var game = new TestGame(150, 50))
{
    game.Run();

    // Wait so we can see the console
    Console.ReadKey();
}
