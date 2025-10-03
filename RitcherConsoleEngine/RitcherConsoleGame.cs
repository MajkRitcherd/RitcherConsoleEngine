using RitcherConsoleEngine.WinAPI;
using RitcherConsoleEngine.WinAPI.ConsoleApiEnums;
using RitcherConsoleEngine.WinAPI.ConsoleApiStructures;

namespace RitcherConsoleEngine
{
    /// <summary>
    /// This class is used to be inherited in application to create console games/simulation. <br />
    /// It provides basic drawing functionality.
    /// </summary>
    /// <remarks>
    /// Application must inherit this class and implement methods which defines game logic and rendering. <br />
    /// </remarks>
    public abstract class RitcherConsoleGame : IDisposable
    {
        private readonly Thread _gameThread;
        private bool _disposed;
        private IntPtr _screenBufferHandle;
        private ConsoleCoordinate _screenBufferSize;
        private short _screenHeight;
        private short _screenWidth;
        private ConsoleSmallRectangle _windowCoordinates;

        /// <summary>
        /// Initializes a new instance of the <see cref="RitcherConsoleGame"/> class.
        /// </summary>
        /// <param name="screenWidth">Screen width (console columns).</param>
        /// <param name="screenHeight">Screen height (console rows).</param>
        protected RitcherConsoleGame(short screenWidth = 160, short screenHeight = 80)
        {
            ScreenHeight = screenHeight;
            ScreenWidth = screenWidth;

            _gameThread = new Thread(GameThreadLoop);
            _screenBufferSize = new ConsoleCoordinate { X = ScreenWidth, Y = ScreenHeight };
            _windowCoordinates = new ConsoleSmallRectangle { Left = 0, Top = 0, Right = (short)(ScreenWidth - 1), Bottom = (short)(ScreenHeight - 1) };
        }

        /// <summary>
        /// Gets screen height (console rows).
        /// </summary>
        public short ScreenHeight
        {
            get => _screenHeight;
            protected set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(ScreenHeight), "Screen height must be greaer than or equal to zero.");

                _screenHeight = value;
            }
        }

        /// <summary>
        /// Get screen width (console columns).
        /// </summary>
        public short ScreenWidth
        {
            get => _screenWidth;
            protected set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(ScreenWidth), "Screen width must be greater than or equal to zero.");

                _screenWidth = value;
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Runs the application.
        /// </summary>
        public void Run()
        {
            if (!CreateConsole())
                throw new ConsoleCoreException("Failed to create console");

            _gameThread.Start();
            _gameThread.Join();
        }

        /// <summary>
        /// Disposes managed and unmanaged resources.
        /// </summary>
        /// <param name="disposing">Whether or not it is called manually or by GC.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // Dispose managed resources
            }

            // Dispose unmanaged resources
            if (_screenBufferHandle != IntPtr.Zero)
                WinConsoleAPI.CloseHandle(_screenBufferHandle);

            _disposed = true;
        }

        /// <summary>
        /// Creates the console using WinAPI calls.
        /// </summary>
        /// <remarks>
        /// Gets the standard output handle and sets its window size to the smallest one,
        /// so we can create window of any size. <br />
        /// Then it creates screen buffer (double buffering) and sets it as active screen buffer
        /// and sets the window size.
        /// </remarks>
        /// <returns>True, if creating console was successful, otherwise false.</returns>
        private bool CreateConsole()
        {
            var smallRect = new ConsoleSmallRectangle
            {
                Left = 0,
                Top = 0,
                Right = 0,
                Bottom = 0
            };

            // Set output console to small window so we can set any window size later on
            var handleConsole = WinConsoleAPI.GetStdHandle(StdHandleTypes.OutputHandle);
            WinConsoleAPI.SetWindowInfo(handleConsole, true, ref smallRect);

            // Prepare console buffer/size
            _screenBufferHandle = WinConsoleAPI.CreateScreenBuffer(AccessRights.GenericReadAndWrite, ShareModes.FileShareReadAndWrite);
            WinConsoleAPI.SetActiveScreenBuffer(_screenBufferHandle);
            WinConsoleAPI.SetScreenBufferSize(_screenBufferHandle, _screenBufferSize);
            WinConsoleAPI.SetWindowInfo(_screenBufferHandle, true, ref _windowCoordinates);

            return true;
        }

        /// <summary>
        /// Method executed by thread representing the main loop of an application.
        /// </summary>
        private void GameThreadLoop()
        {
            while (true)
            {
            }
        }
    }
}