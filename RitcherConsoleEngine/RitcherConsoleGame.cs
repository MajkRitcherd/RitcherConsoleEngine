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
        private short _screenHeight;
        private short _screenWidth;

        /// <summary>
        /// Initializes a new instance of the <see cref="RitcherConsoleGame"/> class.
        /// </summary>
        /// <param name="screenWidth">Screen width (console columns).</param>
        /// <param name="screenHeight">Screen height (console rows).</param>
        protected RitcherConsoleGame(short screenWidth = 160, short screenHeight = 80)
        {
            ScreenHeight = screenHeight;
            ScreenWidth = screenWidth;
        }

        /// <summary>
        /// Gets screen height (console rows).
        /// </summary>
        public short ScreenHeight
        {
            get => _screenHeight;
            protected set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(ScreenHeight), "Screen height must be greaer than or equal to zero.");

                _screenHeight = value;
            }
        }

        /// <summary>
        /// Get screen width (console columns).
        /// </summary>
        public short ScreenWidth
        {
            get => _screenWidth;
            protected set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(ScreenWidth), "Screen width must be greater than or equal to zero.");

                _screenWidth = value;
            }
        }
    }
}