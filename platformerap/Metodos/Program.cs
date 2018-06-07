﻿using System;

namespace platformerap
{
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
      
            using (var game = new BackupGame1())
            game.Run();
        }
    }
#endif
}