using Microsoft.VisualBasic.FileIO;

namespace AdventOfCode2024.Day2;

public class Solution
{
    public int Solve1(string filename)
    {
        string[] input = GetInput(filename);
        int sum = 0;

        foreach (var line in input)
        {
            var split = line.Split(" ");
            
            bool isIncreasing = true;
            bool isDecreasing = true;
            
            for (int i = 0; i < split.Length-1; i++)
            {
                int diff = Math.Abs(int.Parse(split[i + 1]) - int.Parse(split[i]));
                if (diff is < 1 or > 3)
                {
                    isIncreasing = false;
                    isDecreasing = false;
                    break;
                }
                if (int.Parse(split[i]) < int.Parse(split[i+1]))
                {
                    isDecreasing = false;
                }
                if (int.Parse(split[i]) > int.Parse(split[i+1]))
                {
                    isIncreasing = false;
                }
            }

            if (isIncreasing || isDecreasing)
            {
                sum++;
            }
        }

        return sum;
    }
    
    public int Solve2(string filename)
    {
        string[] input = GetInput(filename);
        int sum = 0;

        foreach (var line in input)
        {
            var split = line.Split(" ");
            
            bool isIncreasing = true;
            bool isDecreasing = true;
            
            for (int i = 0; i < split.Length-1; i++)
            {
                int diff = Math.Abs(int.Parse(split[i + 1]) - int.Parse(split[i]));
                if (diff is < 1 or > 3)
                {
                    isIncreasing = false;
                    isDecreasing = false;
                    break;
                }
                if (int.Parse(split[i]) < int.Parse(split[i+1]))
                {
                    isDecreasing = false;
                }
                if (int.Parse(split[i]) > int.Parse(split[i+1]))
                {
                    isIncreasing = false;
                }
            }

            if (isIncreasing || isDecreasing)
            {
                sum++;
            }
        }

        return sum;
    }


    /// <summary>
    /// Receiving the input from the file
    /// </summary>
    /// <param name="filename">Absolute path to the file</param>
    /// <returns>string[] array containing multiple lines from the input file</returns>
    private static string[] GetInput(string filename) => File.ReadAllLines(filename);
}