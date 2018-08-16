using System;

namespace DAGridPuzzleSolver
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var grid = new LightGrid(3);
            
            Console.Write(grid.ToString());
        }
    }
}