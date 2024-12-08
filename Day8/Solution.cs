using System.ComponentModel.Design;
using System.Runtime.InteropServices.ComTypes;

namespace AdventOfCode2024.Day8;

public class Solution
{
    public long Solve1(string filename)
    {
        /* Default variables */
        var input = GetInput(filename);
        long sum = 0;
        /* End of default */

        List<List<char>> map = DrawMap(input);
        
        HashSet<char> id = FindId(map);
        
        List<(int x, int y)> antennas = new List<(int x, int y)>();
        HashSet<(int x, int y)> antinodes = new HashSet<(int x, int y)>();
        
        id.Remove('.'); // removing spacing element
        
        // Scanning map
        foreach (var obj in id)
        {
            antennas = FindAntennas(obj, map);

            // Finding locations for antinodes for the specified antenna
            for (int i = 0; i < antennas.Count; i++)
            {
                for (int j = i + 1; j <antennas.Count; j++)
                {
                        var hash = LocateAntinodes(antennas[i].x, antennas[i].y, antennas[j].x, antennas[j].y, map);
                        foreach (var h in hash)
                        {
                            antinodes.Add(h);
                        }
                }
            }
        }
        
        // Adding antinodes to the map
        foreach (var t in antinodes)
        {
            if (t.y < 0 || t.x < 0 || t.y >= map.Count || t.x >= map.First().Count)
            {
                //if (map[t.y][t.x] == '.')
                {
                    Console.WriteLine(t);
                    antinodes.Remove(t);
                }
            }
        }

        sum += antinodes.Count;

        return sum;
    }
    
    
    public long Solve2(string filename)
    {
        /* Default variables */
        var input = GetInput(filename);
        long sum = 0;
        /* End of default */
        
        List<List<char>> map = DrawMap(input);
        
        HashSet<char> id = FindId(map);
        
        List<(int x, int y)> antennas = new List<(int x, int y)>();
        HashSet<(int x, int y)> antinodes = new HashSet<(int x, int y)>();
        
        id.Remove('.'); // removing spacing element
        
        // Scanning map
        foreach (var obj in id)
        {
            antennas = FindAntennas(obj, map);

            // Finding locations for antinodes for the specified antenna
            for (int i = 0; i < antennas.Count; i++)
            {
                for (int j = i + 1; j < antennas.Count; j++)
                {
                    var hash = LocateAntinodes(antennas[i].x, antennas[i].y, antennas[j].x, antennas[j].y, map);
                    foreach (var h in hash)
                    {
                        antinodes.Add(h);
                    }
                }
            }
        }

        sum += antinodes.Count;

        return sum;
    }


    private static List<List<char>> DrawMap(string[] input)
    {
        List<List<char>> map = new List<List<char>>();

        foreach (var t in input)
        {
            map.Add(t.ToCharArray().ToList());
        }
        
        return map;
    }

    private static HashSet<char> FindId(List<List<char>> map)
    {
        HashSet<char> id = new HashSet<char>();

        //id.Add(map.GetRange(0, map.Count));
        
        foreach (var t in map)
        {
            foreach (var c in t)
            {
                id.Add(c);
            }
        }

        return id;
    }

    private static List<(int x, int y)> FindAntennas(char id, List<List<char>> map)
    {
        List<(int x, int y)> coord = new List<(int x, int y)>();
        
        for (int i = 0; i < map.Count; i++)
        {
            for (int j = 0; j < map.First().Count; j++)
            {
                if (map[i][j] == id)
                {
                    coord.Add((j, i));
                }
            }
        }

        return coord;
    }

    private static HashSet<(int x, int y)> LocateAntinodes(int x, int y, int x1, int y1, List<List<char>> map)
    {
        HashSet<(int x, int y)> coord = new HashSet<(int x, int y)>();
        
        int dx = x1 - x;
        int dy = y1 - y;

        int ant1x = x;
        int ant1y = y;
        
        int ant2x = x1;
        int ant2y = y1;

        while (!IsOutofBounds(ant1x, ant1y, map))
        {
            coord.Add((ant1x, ant1y));
            ant1x -= dx;
            ant1y -= dy;
        }
        
        while (!IsOutofBounds(ant2x, ant2y, map))
        {
            coord.Add((ant2x, ant2y));
            ant2x += dx;
            ant2y += dy;
        }

        return coord;
    }
    
    private static bool IsOutofBounds (int x, int y, List<List<char>> map) => y < 0 || x < 0 || y >= map.Count || x >= map.First().Count;
    
    
    // Receiving input from the file
    private static string[] GetInput(string filename)
    {
        return File.ReadAllLines(filename);
    }
    
}