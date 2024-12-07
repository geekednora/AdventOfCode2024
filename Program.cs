using System.Diagnostics;

namespace AdventOfCode2024;

internal static class Program
{
    static void Main()
    {
        Stopwatch sw1 = new Stopwatch();
        Stopwatch sw2 = new Stopwatch();
        
        var solution = new AdventOfCode2024.Day6.Solution();
        
        /* First Solution */
        sw1.Start();
        
        Console.Write("Solution 1: " + solution.Solve1(@"Z:\source\AdventOfCode2024\Day6\input.txt")
            , Console.ForegroundColor = ConsoleColor.DarkGreen); Console.ResetColor();
        
        sw1.Stop();
        
        Console.WriteLine(" | Elapsed Time: " + sw1.Elapsed, Console.ForegroundColor == ConsoleColor.Blue);
        Console.ResetColor();
        
        /* Second Solution */
        sw2.Start();
        
        Console.Write("Solution 2: " + solution.Solve2(@"Z:\source\AdventOfCode2024\Day6\input.txt")
            , Console.ForegroundColor = ConsoleColor.DarkGreen); Console.ResetColor();
        
        sw2.Stop();
        
        Console.WriteLine(" | Elapsed Time: " + sw2.Elapsed, Console.ForegroundColor == ConsoleColor.Blue);
        Console.ResetColor();
    }
}