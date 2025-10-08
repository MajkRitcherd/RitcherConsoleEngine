using System.Runtime.InteropServices;

namespace RitcherConsoleEngine.WinAPI.ConsoleApiStructures
{
    /// <summary>
    /// Contains information about a console screen buffer. <br />
    /// See https://learn.microsoft.com/en-us/windows/console/console-screen-buffer-info-str.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct ConsoleScreenBufferInfo
    {
        /// <summary>
        /// A <see cref="ConsoleCoordinate"/> structure that contains the size of the console screen buffer, in character columns and rows.
        /// </summary>
        public ConsoleCoordinate Size;

        /// <summary>
        /// A <see cref="ConsoleCoordinate"/> structure that contains the column and row coordinates of the cursor in the console screen buffer.
        /// </summary>
        public ConsoleCoordinate CursorPosition;

        /// <summary>
        /// The attributes of the characters written to a screen buffer by the WriteFile and WriteConsole functions, <br />
        /// or echoed to a screen buffer by the ReadFile and ReadConsole functions.
        /// </summary>
        public short Attributes;

        /// <summary>
        /// A <see cref="ConsoleSmallRectangle"/> structure that contains the console screen buffer coordinates <br />
        /// of the upper-left and lower-right corners of the display window.
        /// </summary>
        public ConsoleSmallRectangle Window;

        /// <summary>
        /// A <see cref="ConsoleCoordinate"/> structure that contains the maximum size of the console window, <br />
        /// in character columns and rows, given the current screen buffer size and font and the screen size.
        /// </summary>
        public ConsoleCoordinate MaximumWindowSize;
    }
}