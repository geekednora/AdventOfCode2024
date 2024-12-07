using System.ComponentModel.Design;

namespace AdventOfCode2024.Day7;

public class Solution
{
    public long Solve1(string filename)
    {
        /* Default variables */
        var input = GetInput(filename);
        long sum = 0;
        /* End of default */
        
        var total = new List<(long result, List<long> oprs)>();

        foreach (var t in input)
        {
            var split = t.Split(':');

            var result = long.Parse(split[0]); 
            var oprs = split[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);
            
            
            total.Add((result, oprs.Select(long.Parse).ToList()));
        }

        foreach (var t in total)
        {
            if (GetResult(t.result, t.oprs))
            {
                sum += t.result;
            }
        }

        return sum;
    }

    

    public long Solve2(string filename)
    {
        /* Default variables */
        var input = GetInput(filename);
        long sum = 0;
        /* End of default */

        var total = new List<(long result, List<long> oprs)>();

        foreach (var t in input)
        {
            var split = t.Split(':');

            var result = long.Parse(split[0]); 
            var oprs = split[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);
            
            
            total.Add((result, oprs.Select(long.Parse).ToList()));
        }

        foreach (var t in total)
        {
            if (GetResult(t.result, t.oprs))
            {
                sum += t.result;
            }
        }

        return sum;
    }
    

    private static string[] GetInput(string filename)
    {
        return File.ReadAllLines(filename);
    }

    private bool GetResult(long result, List<long> oprs)
    {
            int[] b = new int[oprs.Count - 1]; // operators

            do
            {
                if (GetOperators(b, oprs) == result)
                {
                    return true;
                }
                else
                {
                    for (long i = 0; i < b.Length; i++)
                    {
                        if (b[i] == 0)
                        {
                            b[i] = 1;
                            break;
                        }
                        else if (b[i] == 1)
                        {
                            b[i] = 2;
                            break;
                        }
                        else
                        {
                            b[i] = 0;
                        }
                    }
                }
            } while (b.Any(b => b != 2));
            
            if (GetOperators(b, oprs) == result)
            {
                return true;
            }
            
            return false;
        

        return true;
    }

    private long GetOperators(int[] oprs, List<long> nums)
    {
        var sum = nums[0];
        for (int i = 0; i < nums.Count-1; i++)
        {
            if (oprs[i] == 0)
            {
                sum += nums[i+1];
            }
            if (oprs[i] == 1)
            {
                sum *= nums[i+1];
            }
            if (oprs[i] == 2)
            {
                sum = long.Parse(string.Concat(sum, nums[i+1]));
            }
        }

        return sum;
    }
    
}