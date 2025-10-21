using RitcherConsoleEngine;

namespace TestRCE
{
    internal class TestGame : RitcherConsoleGame
    {
        public TestGame(ConsoleProperties consoleProperties)
            : base(consoleProperties)
        {
            var rnd = new Random();
            for (short i = 0; i < ScreenWidth; i++)
                for (short j = 0; j < ScreenHeight; j++)
                    Draw(i, j, '\u2588', (ConsoleColor)rnd.Next(0, 16));
        }

        protected override bool OnCreate()
        {
            return false;
        }

        protected override bool OnUpdate(float elapsedTime)
        {
            return false;
        }
    }
}