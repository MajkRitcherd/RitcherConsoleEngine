using RitcherConsoleEngine;

namespace TestRCE
{
    internal class TestGame(ConsoleProperties consoleProperties) : RitcherConsoleGame(consoleProperties)
    {
        private readonly Random _rnd = new();

        protected override bool OnCreate()
        {
            return true;
        }

        protected override bool OnUpdate(double elapsedTime)
        {
            for (short i = 0; i < ScreenWidth; i++)
                for (short j = 0; j < ScreenHeight; j++)
                    Draw(i, j, '\u2588', (ConsoleColor)_rnd.Next(0, 16));

            return true;
        }
    }
}