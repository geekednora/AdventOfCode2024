namespace AdventOfCode2024.Day2;

public class Solution
{
    public int Solve1(string filename)
    {
        var input = GetInput(filename);
        var sum = 0;

        foreach (var line in input)
        {
            var split = line.Split(" ");

            var isIncreasing = true;
            var isDecreasing = true;

            for (var i = 0; i < split.Length - 1; i++)
            {
                var diff = Math.Abs(int.Parse(split[i + 1]) - int.Parse(split[i]));
                if (diff is < 1 or > 3)
                {
                    isIncreasing = false;
                    isDecreasing = false;
                    break;
                }

                if (int.Parse(split[i]) < int.Parse(split[i + 1])) isDecreasing = false;
                if (int.Parse(split[i]) > int.Parse(split[i + 1])) isIncreasing = false;
            }

            if (isIncreasing || isDecreasing) sum++;
        }

        return sum;
    }

    public int Solve2(string filename)
    {
        var input = GetInput(filename);
        var sum = 0;

        var reports = input
            .Select(line => line.Split(" "))
            .Select(split => new List<int>(split.Select(int.Parse)))
            .ToList();

        foreach (var t in reports)
            if (CheckLevel(t))
                sum++;
            else
                for (var i = 0; i < t.Count; i++)
                {
                    var copy = new List<int>(t);
                    copy.RemoveAt(i);

                    if (CheckLevel(copy))
                    {
                        sum++;
                        break;
                    }
                }


        return sum;
    }


    /// <summary>
    ///     Receiving the input from the file
    /// </summary>
    /// <param name="filename">Absolute path to the file</param>
    /// <returns>string[] array containing multiple lines from the input file</returns>
    private static string[] GetInput(string filename)
    {
        return File.ReadAllLines(filename);
    }

    private bool CheckLevel(List<int> report)
    {
        var isIncreasing = true;
        var isDecreasing = true;

        for (var j = 0; j < report.Count - 1; j++)
        {
            var diff = Math.Abs(report[j + 1] - report[j]);

            if (diff is < 1 or > 3)
            {
                isIncreasing = false;
                isDecreasing = false;
                break;
            }

            if (report[j] < report[j + 1]) isDecreasing = false;
            if (report[j] > report[j + 1]) isIncreasing = false;
        }

        return isIncreasing || isDecreasing;
    }
}