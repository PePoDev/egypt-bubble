using System;

namespace GP_Midterm_BubblePuzzle {
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new MainScene())
                game.Run();
        }
    }
#endif
}
