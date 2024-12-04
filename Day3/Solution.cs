namespace AdventOfCode2024.Day3;

public class Solution
{
    public int Solve1(string filename)
    {
        var input = GetInput(filename);
        var sum = 0;

        foreach (var line in input)
        {
            if (line.Contains("mul("))
            {
                var split = line.Split("mul(")[1..];
                foreach (var t in split)
                {
                    int i = 0;
                    string multipliers = new string("");

                    // checking for digits before comma in mul
                    while (char.IsDigit(t[i]))
                    {
                        multipliers += t[i];
                        i++;
                    }

                    if (!char.IsDigit(t[i]) && t[i] != ',')
                    {
                        continue;
                    }

                    var operand = int.Parse(multipliers);
                    multipliers = "";
                    i++;

                    // checking for the second digit if the comma is contained in operation
                    while (char.IsDigit(t[i]))
                    {
                        multipliers += t[i];
                        i++;
                    }

                    if (!char.IsDigit(t[i]) && t[i] != ')')
                    {
                        continue;
                    }

                    operand *= int.Parse(multipliers);
                    sum += operand;
                }
            }

        }

        return sum;
    }

    public int Solve2(string filename)
    {
        var input = GetInput(filename);
        var sum = 0;
        
        
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
}