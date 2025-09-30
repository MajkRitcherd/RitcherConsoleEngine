namespace RitcherConsoleEngine.WinAPI
{
    /// <summary>
    /// Windows console share modes.
    /// </summary>
    internal enum ShareModes : uint
    {
        /// <summary>
        /// File share read mode.
        /// </summary>
        FileShareRead = 0x00000001,

        /// <summary>
        /// File share write mode.
        /// </summary>
        FileShareWrite = 0x00000002,

        /// <summary>
        /// File share Read and Write mode.
        /// </summary>
        FileShareReadAndWrite = FileShareRead | FileShareWrite
    }
}