using System.Runtime.InteropServices;

namespace RitcherConsoleEngine.WinAPI.ConsoleApiStructures
{
    /// <summary>
    /// Specifies a Unicode or ANSI character and its attributes. <br />
    /// See https://learn.microsoft.com/en-us/windows/console/char-info-str.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    internal struct ConsoleCharInfo
    {
        /// <summary>
        /// Internal representation of the Char. <br />
        /// Represented as ushort because of bite match with WCHAR (https://learn.microsoft.com/en-us/windows/win32/extensible-storage-engine/wchar).
        /// </summary>
        [FieldOffset(0)]
        private ushort _internalCharacterRepresentation;

        /// <summary>
        /// The character attributes. This member can be zero or any combination of the following values.
        /// </summary>
        [FieldOffset(2)]
        public short Attributes;

        /// <summary>
        /// Unicode character of a screen buffer character cell.
        /// </summary>
        public char Character
        {
            readonly get => (char)_internalCharacterRepresentation;
            set => _internalCharacterRepresentation = value;
        }
    }
}