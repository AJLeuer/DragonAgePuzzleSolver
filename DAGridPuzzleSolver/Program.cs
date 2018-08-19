using System;
using System.Diagnostics;

namespace DAGridPuzzleSolver
{
    
    internal class Program
    {

        private static void ConfigureConsoleOutputEncoding()
        {
            if ((Environment.OSVersion.Platform == PlatformID.MacOSX) ||
                (Environment.OSVersion.Platform == PlatformID.Unix))
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
            }
            else if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
            }
        }
        
        public static void Main(string[] args)
        {
            ConfigureConsoleOutputEncoding();
            
            var grid = new LightGrid(3);
            
            Console.WriteLine();
            Console.Write(grid.ToString());
            
            grid.Grid[0][0].Toggle();
            Console.Write(grid.ToString());
        }
    }
}