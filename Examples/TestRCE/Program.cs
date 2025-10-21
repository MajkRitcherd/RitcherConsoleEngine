using RitcherConsoleEngine;
using TestRCE;

using (var game = new TestGame(ConsoleProperties.Default))
{
    game.Run();
}

// Wait so we can see the console
Console.ReadKey();