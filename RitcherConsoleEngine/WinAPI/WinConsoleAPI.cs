using System.Runtime.InteropServices;
using RitcherConsoleEngine.WinAPI.ConsoleApiStructures;

namespace RitcherConsoleEngine.WinAPI
{
    /// <summary>
    /// Handles console related calls to the WinAPI.
    /// </summary>
    internal static class WinConsoleAPI
    {
        /// <summary>
        /// Creates a console screen buffer.
        /// </summary>
        /// <param name="accessRights">Windows console access right.</param>
        /// <param name="shareModes">Windows console share mode.</param>
        /// <returns>Handle to the console screen buffer.</returns>
        public static IntPtr CreateScreenBuffer(AccessRights accessRights, ShareModes shareModes)
        {
            return CheckWinAPIResult(CreateConsoleScreenBuffer((uint)accessRights, (uint)shareModes, IntPtr.Zero, 1, IntPtr.Zero),
                "Failed to create console screen buffer");
        }

        /// <summary>
        /// Sets the specified screen buffer to be the currently displayed console screen buffer.
        /// </summary>
        /// <param name="screenBufferHandle">A handle to the console screen buffer.</param>
        /// <returns>True on success, otherwise false.</returns>
        public static void SetActiveScreenBuffer(IntPtr screenBufferHandle)
        {
            CheckWinAPIResult(SetConsoleActiveScreenBuffer(screenBufferHandle),
                "Failed to set console active screen buffer");
        }

        /// <summary>
        /// Changes the size of the specified console screen buffer.
        /// </summary>
        /// <param name="screenBufferHandle">A handle to the console screen buffer.</param>
        /// <param name="bufferSize">Size of a screen buffer.</param>
        /// <returns>True on success, otherwise false.</returns>
        public static void SetScreenBufferSize(IntPtr screenBufferHandle, ConsoleCoordinate bufferSize)
        {
            CheckWinAPIResult(SetConsoleScreenBufferSize(screenBufferHandle, bufferSize),
                "Failed to set new console screen buffer size");
        }

        /// <summary>
        /// Sets the current size and position of a console screen buffer's window.
        /// </summary>
        /// <param name="screenBufferHandle">A handle to the console screen buffer.</param>
        /// <param name="areAbsoluteCoordinates">If true, coordinates specify the new upper-left and lower-right corners of the window,
        ///                                      otherwise coordinates are relative to the current window-corner coordinates.</param>
        /// <param name="coordinates">Coordinates of the new window.</param>
        /// <returns>True on success, otherwise false.</returns>
        public static void SetWindowInfo(IntPtr screenBufferHandle, bool areAbsoluteCoordinates, ref ConsoleSmallRectangle coordinates)
        {
            CheckWinAPIResult(SetConsoleWindowInfo(screenBufferHandle, areAbsoluteCoordinates, ref coordinates),
                "Failed to set console window info");
        }

        /// <summary>
        /// Writes character and color attribute data to a specified rectangular block of character cells in a console screen buffer.
        /// </summary>
        /// <param name="screenBufferHandle">A handle to the console screen buffer.</param>
        /// <param name="screenData">Data to be written to the screen buffer.</param>
        /// <param name="bufferSize">Size of a screen buffer.</param>
        /// <param name="startPosition">Start position of write.</param>
        /// <param name="writeArea">Write rectangle area (upper-left corner and lower-right corner).</param>
        /// <returns>True on success, otherwise false.</returns>
        public static void WriteToScreenBuffer(IntPtr screenBufferHandle, ConsoleCharInfo[] screenData, ConsoleCoordinate bufferSize, ConsoleCoordinate startPosition, ref ConsoleSmallRectangle writeArea)
        {
            CheckWinAPIResult(WriteConsoleOutput(screenBufferHandle, screenData, bufferSize, startPosition, ref writeArea),
                "Failed to write to the console screen buffer");
        }

        /// <summary>
        /// Checks Window API call result.
        /// </summary>
        /// <param name="apiCallResult">Windows API call result.</param>
        /// <param name="failureMessage">Message to be thrown with exception.</param>
        /// <exception cref="ConsoleCoreException">Throws Console CORE exception if windows API fails.</exception>
        private static void CheckWinAPIResult(bool apiCallResult, string failureMessage)
        {
            if (!apiCallResult)
                throw new ConsoleCoreException(ComposeErrorMessage(failureMessage));
        }

        /// <summary>
        /// Checks Window API call result (pointer).
        /// </summary>
        /// <param name="apiCallResult">Window API call result (pointer).</param>
        /// <param name="failureMessage">Message to be thrown with exception.</param>
        /// <returns>Handle (pointer).</returns>
        /// <exception cref="ConsoleCoreException">Throws Console CORE exception if windows API fails.</exception>
        private static IntPtr CheckWinAPIResult(IntPtr apiCallResult, string failureMessage)
        {
            if (apiCallResult == IntPtr.Zero)
                throw new ConsoleCoreException(ComposeErrorMessage(failureMessage));

            return apiCallResult;
        }

        /// <summary>
        /// Composes an error message with error code.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Error message with error code.</returns>
        private static string ComposeErrorMessage(string message)
        {
            var errorCode = Marshal.GetLastWin32Error();
            return $"{message}. Error code: {errorCode}.";
        }

        #region Import Console functions

        /// <summary>
        /// Creates a console screen buffer.
        /// See https://learn.microsoft.com/en-us/windows/console/createconsolescreenbuffer.
        /// </summary>
        /// <param name="dwDesiredAccess">The access to the console screen buffer.</param>
        /// <param name="dwShareMode">This parameter can be zero, indicating that the buffer cannot be shared, or it can be one or more of the following values:
        ///                           FILE_SHARE_READ (0x00000001) or FILE_SHARE_WRITE (0x00000002).</param>
        /// <param name="lpSecurityAttributes">A pointer to a SECURITY_ATTRIBUTES structure that determines whether the returned handle can be inherited by child processes.</param>
        /// <param name="dwFlags">The type of console screen buffer to create. The only supported screen buffer type is CONSOLE_TEXTMODE_BUFFER.</param>
        /// <param name="lpScreenBufferData">Reserved; should be NULL.</param>
        /// <returns>Handle to the new console screen buffer on success, otherwise INVALID_HANDLE_VALUE.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr CreateConsoleScreenBuffer(uint dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, uint dwFlags, IntPtr lpScreenBufferData);

        /// <summary>
        /// Sets the specified screen buffer to be the currently displayed console screen buffer.
        /// See https://learn.microsoft.com/en-us/windows/console/setconsoleactivescreenbuffer.
        /// </summary>
        /// <param name="hConsoleOutput">A handle to the console screen buffer.</param>
        /// <returns>True on success, False on fail.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleActiveScreenBuffer(IntPtr hConsoleOutput);

        /// <summary>
        /// Changes the size of the specified console screen buffer.
        /// See https://learn.microsoft.com/en-us/windows/console/setconsolescreenbuffersize.
        /// </summary>
        /// <param name="hConsoleOutput">A handle to the console screen buffer.</param>
        /// <param name="dwSize">A <see cref="ConsoleCoordinate"/> structure that specifies the new size of the console screen buffer, in character rows and columns.</param>
        /// <returns>True on success, False on fail.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleScreenBufferSize(IntPtr hConsoleOutput, ConsoleCoordinate dwSize);

        /// <summary>
        /// Sets the current size and position of a console screen buffer's window.
        /// See https://learn.microsoft.com/en-us/windows/console/setconsolewindowinfo.
        /// </summary>
        /// <param name="hConsoleOutput">A handle to the console screen buffer.</param>
        /// <param name="bAbsolute">If this parameter is TRUE, the coordinates specify the new upper-left and lower-right corners of the window.
        ///                         If it is FALSE, the coordinates are relative to the current window-corner coordinates.</param>
        /// <param name="lpConsoleWindow ">A pointer to a <see cref="ConsoleSmallRectangle"/> structure that specifies the new upper-left and lower-right corners of the window.</param>
        /// <returns>True on success, False on fail.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleWindowInfo(IntPtr hConsoleOutput, bool bAbsolute, ref ConsoleSmallRectangle lpConsoleWindow);

        /// <summary>
        /// Writes character and color attribute data to a specified rectangular block of character cells in a console screen buffer. <br />
        /// See https://learn.microsoft.com/en-us/windows/console/writeconsoleoutput.
        /// </summary>
        /// <param name="hConsoleOutput">A handle to the console screen buffer. The handle must have the GENERIC_WRITE access right.</param>
        /// <param name="lpBuffer">The data to be written to the console screen buffer.
        ///                        This pointer is treated as the origin of a two-dimensional array of CHAR_INFO structures whose size is specified by the dwBufferSize parameter.</param>
        /// <param name="dwBufferSize">The size of the buffer pointed to by the lpBuffer parameter, in character cells.
        ///                            The X member of the <see cref="ConsoleCoordinate"/> structure is the number of columns; the Y member is the number of rows.</param>
        /// <param name="dwBufferCoord">The coordinates of the upper-left cell in the buffer pointed to by the lpBuffer parameter.
        ///                             The X member of the <see cref="ConsoleCoordinate"/> structure is the column, and the Y member is the row.</param>
        /// <param name="lpWriteRegion">A pointer to a <see cref="ConsoleSmallRectangle"/> structure.
        ///                             On input, the structure members specify the upper-left and lower-right coordinates of the console screen buffer rectangle to write to.</param>
        /// <returns>True on success, False on fail.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteConsoleOutput(IntPtr hConsoleOutput, ConsoleCharInfo[] lpBuffer, ConsoleCoordinate dwBufferSize, ConsoleCoordinate dwBufferCoord, ref ConsoleSmallRectangle lpWriteRegion);

        #endregion Import Console functions
    }
}