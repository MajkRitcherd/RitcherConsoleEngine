using System.Runtime.InteropServices;

namespace RitcherConsoleEngine.WinAPI.ConsoleApiStructures
{
    /// <summary>
    /// Defines the coordinates of the upper left and lower right corners of a rectangle. <br />
    /// See https://learn.microsoft.com/en-us/windows/console/small-rect-str.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct ConsoleSmallRectangle
    {
        /// <summary>
        /// The X-coordinate of the upper left corner of the rectangle.
        /// </summary>
        public short Left;

        /// <summary>
        /// The Y-coordinate of the upper left corner of the rectangle.
        /// </summary>
        public short Top;

        /// <summary>
        /// The X-coordinate of the lower right corner of the rectangle.
        /// </summary>
        public short Right;

        /// <summary>
        /// The Y-coordinate of the lower right corner of the rectangle.
        /// </summary>
        public short Bottom;
    }
}