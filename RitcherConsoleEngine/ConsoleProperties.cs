namespace RitcherConsoleEngine
{
    /// <summary>
    /// Properties for console configuration.
    /// </summary>
    /// <remarks>
    /// Properties as Screen width and height are used to set console buffer size and window size. <br />
    /// Font width and height are used to set console font size.
    /// </remarks>
    public struct ConsoleProperties
    {
        /// <summary>
        /// Default console properties.
        /// </summary>
        /// <remarks>
        /// Screen width: 160 columns <br />
        /// Screen height: 80 rows <br />
        /// Font width: 8 <br />
        /// Font height: 16
        /// </remarks>
        public static ConsoleProperties Default => new()
        {
            ScreenWidth = 160,
            ScreenHeight = 50,
            FontWidth = 6,
            FontHeight = 12,
        };

        /// <summary>
        /// Gets or sets the height of the console font, in logical units (pixels).
        /// </summary>
        public short FontHeight { get; set; }

        /// <summary>
        /// Gets or sets the width of the console font, in logical units (pixels).
        /// </summary>
        public short FontWidth { get; set; }

        /// <summary>
        /// Gets or sets the height of the console screen, in rows.
        /// </summary>
        public short ScreenHeight { get; set; }

        /// <summary>
        /// Gets or sets the width of the console screen, in columns.
        /// </summary>
        public short ScreenWidth { get; set; }
    }
}