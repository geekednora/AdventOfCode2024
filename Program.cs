namespace AdventOfCode2024;

internal static class Program
{
    static void Main()
    {
        var solution = new AdventOfCode2024.Day5.Solution();
        
        Console.WriteLine(solution.Solve1(@"Z:\source\AdventOfCode2024\Day5\input.txt"));
        Console.WriteLine(solution.Solve2(@"Z:\source\AdventOfCode2024\Day5\input.txt"));
    }
}