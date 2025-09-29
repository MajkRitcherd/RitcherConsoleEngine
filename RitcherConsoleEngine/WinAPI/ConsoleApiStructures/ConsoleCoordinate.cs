using System.Runtime.InteropServices;

namespace RitcherConsoleEngine.WinAPI.ConsoleApiStructures
{
    /// <summary>
    /// Defines the coordinates of a character cell in a console screen buffer. <br />
    /// See https://learn.microsoft.com/en-us/windows/console/coord-str.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct ConsoleCoordinate
    {
        /// <summary>
        /// The horizontal coordinate or column value.
        /// </summary>
        public short X;

        /// <summary>
        /// The vertical coordinate or row value.
        /// </summary>
        public short Y;
    }
}