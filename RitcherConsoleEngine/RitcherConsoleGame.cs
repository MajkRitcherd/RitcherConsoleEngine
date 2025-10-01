namespace RitcherConsoleEngine
{
    /// <summary>
    /// This class is used to be inherited in application to create console games/simulation. <br />
    /// It provides basic drawing functionality.
    /// </summary>
    /// <remarks>
    /// Application must inherit this class and implement methods which defines game logic and rendering. <br />
    /// </remarks>
    public abstract class RitcherConsoleGame
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RitcherConsoleGame"/> class.
        /// </summary>
        /// <param name="screenWidth">Screen width (console columns).</param>
        /// <param name="screenHeight">Screen height (console rows).</param>
        protected RitcherConsoleGame(ushort screenWidth = 160, ushort screenHeight = 80)
        {
            ScreenHeight = screenHeight;
            ScreenWidth = screenWidth;
        }

        /// <summary>
        /// Gets screen height (console rows).
        /// </summary>
        public ushort ScreenHeight { get; protected set; }

        /// <summary>
        /// Get screen width (console columns).
        /// </summary>
        public ushort ScreenWidth { get; protected set; }
    }
}