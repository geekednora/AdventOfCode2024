namespace AdventOfCode2024.Day9;

public class Solution
{
    public long Solve1(string filename)
    {
        /* Default variables */
        var input = GetInput(filename);
        long sum = 0;
        /* End of default */

        var fragments = FileFragmentation(input);

        var blocks = fragments.blocks.ToList();
        var spaces = fragments.spaces.ToList(); // division of the string into two types of inputs

        var diskmap = new List<string>();
        GetDiskmap(blocks, spaces, diskmap);

        diskmap = diskmap.ToIndividual();
        Data.Sort(diskmap);

        var result = Data.Sort(diskmap);

        Console.WriteLine("DEBUG:   " + string.Join("", result), Console.ForegroundColor = ConsoleColor.Red);


        for (var i = 0; i < diskmap.Count; i++)
        {
            if (diskmap[i] == ".") break;
            sum += int.Parse(diskmap[i]) * i;
        }

        return sum;
    }


    public long Solve2(string filename)
    {
        /* Default variables */
        var input = GetInput(filename);
        long sum = 0;
        /* End of default */

        var fragments = FileFragmentation(input);

        var blocks = fragments.blocks.ToList();
        var spaces = fragments.spaces.ToList(); // division of the string into two types of inputs

        var diskmap = new List<string>();
        GetDiskmap(blocks, spaces, diskmap);

        diskmap = diskmap.ToIndividual();
        Data.Sort(diskmap);

        var result = diskmap.Fit();

        Console.WriteLine("DEBUG:   " + string.Join("", result), Console.ForegroundColor = ConsoleColor.Red);


        for (var i = 0; i < diskmap.Count; i++)
        {
            if (diskmap[i] == ".") break;
            sum += int.Parse(diskmap[i]) * i;
        }

        return sum;
    }


    private static void GetDiskmap(List<int> blocks, List<int> spaces, List<string> diskmap)
    {
        var type = true;
        for (var i = 0; i < blocks.Count + spaces.Count;)
            switch (type)
            {
                case true:
                {
                    if (blocks.Count > i) diskmap.Add(blocks[i].ToString());

                    type = false;
                    break;
                }
                case false:
                {
                    if (spaces.Count > i) diskmap.Add(spaces[i].ToString());

                    i++;
                    type = true;
                    break;
                }
            }
    }

    private static (List<int> blocks, List<int> spaces) FileFragmentation(string input)
    {
        var blocks = new List<int>();
        var spaces = new List<int>();

        var type = true;

        foreach (var t in input)
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
    private static List<string> set = new();

    public static List<string> ToIndividual(this List<string> diskmap)
    {
        var type = true;
        var id = 0;

        set = new List<string>(); // resetting data in set

        foreach (var t in diskmap)
            switch (type)
            {
                case true:
                {
                    for (var i = 0; i < int.Parse(t); i++) set.Add(id.ToString());

                    id++;

                    type = false;
                    break;
                }
                case false:
                {
                    for (var i = 0; i < int.Parse(t); i++) set.Add(space.ToString());

                    type = true;
                    break;
                }
            }

        return set;
    }

    public static List<string> Sort(this List<string> data)
    {
        var result = new List<string>();
        for (var i = 0; i < data.Count; i++)
            if (data[i] == space.ToString())
                for (var j = data.Count - 1; j >= i; j--)
                    if (data[j] != space.ToString())
                    {
                        data[i] = data[j];
                        data[j] = space.ToString();
                        break;
                    }

        return data;
    }

    public static List<string> Fit(this List<string> data)
    {
        for (var i = 0; i < data.Count; i++)
            if (data[i] == space.ToString())
            {
                var count = 1;
                for (var j = i + 1; j < data.Count; j++) // counting dots
                {
                    if (data[j] != space.ToString()) break;

                    count++;
                }

                for (var j = data.Count - 1; j >= i; j--)
                {
                    var nums = 0;
                    if (int.TryParse(data[j], out var temp))
                        for (var c = j; c >= j; c--) // counting repeated numbers
                            if (int.Parse(data[c]) == temp) // if number is the same
                            {
                                nums++;
                            }
                            else // if number is NOT the same
                            {
                                if (count <= nums)
                                {
                                    data[i] = data[j];
                                    data[j] = space.ToString();
                                    break;
                                }

                                count = 0;
                                nums = 0;
                                break;
                            }
                }
            }

        return data;
    }
}