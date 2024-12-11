using System.ComponentModel.Design;
using System.Runtime.InteropServices.ComTypes;

namespace AdventOfCode2024.Day9;

public class Solution
{
    public long Solve1(string filename)
    {
        /* Default variables */
        string input = GetInput(filename);
        long sum = 0;
        /* End of default */

        var fragments = FileFragmentation(input);

        List<int> blocks = fragments.blocks.ToList();
        List<int> spaces = fragments.spaces.ToList(); // division of the string into two types of inputs

        List<string> diskmap = new List<string>();
        GetDiskmap(blocks, spaces, diskmap);
        
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

    
    
    
    private static void GetDiskmap(List<int> blocks, List<int> spaces, List<string> diskmap)
    {
        bool type = true;
        for (int i = 0; i < blocks.Count + spaces.Count;)
        {
            switch (type)
            {
                case true:
                {
                    if (blocks.Count > i)
                    {
                        diskmap.Add( blocks[i].ToString() );
                    }

                    type = false;
                    break;
                }
                case false:
                {
                    if (spaces.Count > i)
                    {
                        diskmap.Add( spaces[i].ToString() );
                    }
                    
                    i++;
                    type = true;
                    break;
                }
            }
        }
    }
    
    private static (List<int> blocks, List<int> spaces) FileFragmentation(string input)
    {
        List<int> blocks = new List<int>();
        List<int> spaces = new List<int>();
        
        bool type = true;
        
        foreach (var t in input)
        {
            
            switch (type)
            {
                case true:
                {
                    blocks.Add(int.Parse(t.ToString()));
                    type = false;
                    break;
                }
                case false:
                {
                    spaces.Add(int.Parse(t.ToString()));
                    type = true;
                    break;
                }
            }
        }
        return (blocks, spaces);
    }
    
    // Receiving input from the file
    private static string GetInput(string filename)
    {
        return File.ReadAllLines(filename)[0];
    }
    
}

public static class Data
{
    private const char space = '.';
    private static List<string> set = new List<string>();
    
    public static List<string> ToIndividual(this List<string> diskmap)
    {
        bool type = true;
        int id = 0;

        foreach (var t in diskmap)
        {
            switch (type)
            {
                case true:
                {
                    for (int i = 0; i < int.Parse(t); i++)
                    {
                        set.Add(id.ToString());
                    }

                    id++;
                    
                    type = false;
                    break;
                }
                case false:
                {
                    for (int i = 0; i < int.Parse(t); i++)
                    {
                        set.Add(space.ToString());
                    }
                    
                    type = true;
                    break;
                }
            }
        }

        return set;
    }

    public static List<string> Sort(this List<string> data)
    {
        return data;
    }
}