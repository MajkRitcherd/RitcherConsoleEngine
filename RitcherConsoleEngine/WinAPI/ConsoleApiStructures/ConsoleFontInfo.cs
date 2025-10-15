using System.Runtime.InteropServices;

namespace RitcherConsoleEngine.WinAPI.ConsoleApiStructures
{
    /// <summary>
    /// Contains extended information for a console font. <br />
    /// See https://learn.microsoft.com/en-us/windows/console/console-font-infoex.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    internal struct ConsoleFontInfo
    {
        /// <summary>
        /// The size of this structure, in bytes.
        /// This member must be set to sizeof(CONSOLE_FONT_INFOEX) before calling GetCurrentConsoleFontEx or it will fail.
        /// </summary>
        public uint Size;

        /// <summary>
        /// The index of the font in the system's console font table.
        /// </summary>
        public uint Font;

        /// <summary>
        /// A <see cref="ConsoleCoordinate"/> structure that contains the width and height of
        /// each character in the font, in logical units. <br />
        /// The X member contains the width, while the Y member contains the height.
        /// </summary>
        public ConsoleCoordinate FontSize;

        /// <summary>
        /// The font pitch and family.
        /// For more information, see https://learn.microsoft.com/en-us/windows/console/console-font-infoex
        /// </summary>
        public int FontFamily;

        /// <summary>
        /// The font weight. The weight can range from 100 to 1000,
        /// in multiples of 100. For example, the normal weight is 400, while 700 is bold.
        /// </summary>
        public int FontWeight;

        /// <summary>
        /// The name of the typeface (such as Courier or Arial).
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string FaceName;
    }
}