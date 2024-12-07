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

        return sum;
    }
    

    private static string[] GetInput(string filename)
    {
        return File.ReadAllLines(filename);
    }

    private bool GetResult(long result, List<long> oprs)
    {
            bool[] b = new bool[oprs.Count - 1]; // operators

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
                        if (!b[i])
                        {
                            b[i] = true;
                            break;
                        }
                        else
                        {
                            b[i] = false;
                        }
                    }
                }
            } while (b.Any(b => b == false));
            
            if (GetOperators(b, oprs) == result)
            {
                return true;
            }
            
            return false;
        

        return true;
    }

    private long GetOperators(bool[] oprs, List<long> nums)
    {
        var sum = nums[0];
        for (int i = 0; i < nums.Count-1; i++)
        {
            if (oprs[i] is false)
            {
                sum += nums[i+1];
            }

            if (oprs[i] is true)
            {
                sum *= nums[i+1];
            }
        }

        return sum;
    }
    
}