namespace RitcherConsoleEngine.WinAPI.ConsoleApiEnums
{
    /// <summary>
    /// Windows console access rights.
    /// </summary>
    internal enum AccessRights : uint
    {
        /// <summary>
        /// Read access.
        /// </summary>
        GenericRead = 0x80000000,

        /// <summary>
        /// Write access.
        /// </summary>
        GenericWrite = 0x40000000,

        /// <summary>
        /// Read and Write access.
        /// </summary>
        GenericReadAndWrite = GenericRead | GenericWrite,
    }
}