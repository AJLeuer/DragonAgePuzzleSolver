using System;

namespace DAGridPuzzleSolver
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var grid = new LightGrid(3);
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            
            Console.Write(grid.ToString());
            
            grid.Grid[1][2].Toggle();
            
            Console.Write(grid.ToString());
        }
    }
}