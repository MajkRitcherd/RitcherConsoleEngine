namespace RitcherConsoleEngine
{
    /// <summary>
    /// Console CORE exception.
    /// </summary>
    internal class ConsoleCoreException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleCoreException"/> class.
        /// </summary>
        public ConsoleCoreException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleCoreException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ConsoleCoreException(string? message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleCoreException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ConsoleCoreException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}