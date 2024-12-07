namespace AdventOfCode2024.Day6;

public class Solution
{
    public int Solve1(string filename)
    {
        /* Default variables */
        var input = GetInput(filename);
        /* End of default */

        var map = input.Select(line => line.ToCharArray()).ToArray();

        const char guard = '^';
        const char obstacle = '#';
        const char visited = 'X';
        int guardPosX = 0, guardPosY = 0;
        var direction = 0; // 0 = up, 1 = right, 2 = down, 3 = left

        HashSet<(int, int)> visitedPos = [];

        for (var y = 0; y < map.Length; y++)
        for (var x = 0; x < map.First().Length; x++)
            if (map[y][x] == guard)
            {
                guardPosX = x;
                guardPosY = y;
            }

        visitedPos.Add((guardPosY, guardPosX));
        map[guardPosY][guardPosX] = visited;

        return CheckPath(guardPosX, guardPosY, direction, map, obstacle, visited, visitedPos);
    }

    

    public int Solve2(string filename)
    {
        /* Default variables */
        var input = GetInput(filename);
        int result = 0;
        var field = new char[input[0].Length, input.Length];
        var currentX = 0;
        var currentY = 0;
        var direction = 0;
        var lengthX = input[0].Length;
        var lengthY = input.Length;

        for (var y = 0; y < lengthY; y++)
        {
            var line = input[y];
            for (int x = 0; x < lengthX; x++)
            {
                var ch = line[x];
                if (ch == '^') 
                {
                    currentX = x;
                    currentY = y;
                    field[x, y] = '.';
                    continue;
                }
                field[x, y] = ch;
            }
        }

        for (int x = 0; x < lengthX; x++)
        {
            for (int y = 0; y < lengthY; y++)
            {
                if (field[x, y] != '#' && !(x == currentX && y == currentY))
                {
                    field[x, y] = '#';
                    if (!CanExit(field, currentX, currentY, direction))
                    {
                        result++;
                        // Console.WriteLine($"x: {x}, y: {y}");
                    }
                    field[x, y] = '.';
                }
            }
        }
        return result;
    }
    
    
    private int CheckPath(int guardPosX, int guardPosY, int direction, char[][] map, char obstacle, char visited,
        HashSet<(int, int)> visitedPos)
    {
        while (true)
        {
            int nextPosX = guardPosX, nextPosY = guardPosY;

            switch (direction)
            {
                case 0:
                    nextPosY--;
                    break; // up
                case 1:
                    nextPosX++;
                    break; // right
                case 2:
                    nextPosY++;
                    break; // down
                case 3:
                    nextPosX--;
                    break; // left
            }


            if (nextPosX < 0 || nextPosX >= map[0].Length
                             || nextPosY < 0 || nextPosY >= map.Length)
            {
                break;
            }
            if (map[nextPosY][nextPosX] == obstacle)
            {
                direction = (direction + 1) % 4; // turn right
            }
            else
            {
                guardPosX = nextPosX;
                guardPosY = nextPosY;


                if (visitedPos.Contains((guardPosY, guardPosX)))
                {
                    return -1; // guard is stuck in a loop
                }
                visitedPos.Add((guardPosY, guardPosX));
                map[guardPosY][guardPosX] = visited;
            }
        }

        return visitedPos.Count;
    }
    
    private static bool CanExit(char[,] field, int x, int y, int direction)
    {
        var visitedTiles = new HashSet<(int x, int y, int direction)>();
        while (true)
        {
            if (visitedTiles.Contains((x, y, direction)))
            {
                return false;
            }
            visitedTiles.Add((x, y, direction));
            
            var moveX = 0;
            var moveY = 0;
            if (direction == 0)
            {
                moveX = 0;
                moveY = -1;
            }
            else if (direction == 1)
            {
                moveX = 1;
                moveY = 0;
            }
            else if (direction == 2)
            {
                moveX = 0;
                moveY = 1;
            }
            else if (direction == 3)
            {
                moveX = -1;
                moveY = 0;
            }

            var nextX = x + moveX;
            var nextY = y + moveY;
            if (IsOutOfBounds(nextX, nextY, field.GetLength(0), field.GetLength(1)))
            {
                return true;
            }
            

            if (field[nextX, nextY] == '#')
            {
                direction = (direction + 1) % 4;
                continue;
            }
            
            x = nextX;
            y = nextY;
        }
    }
    
    private static bool IsOutOfBounds(int x, int y, int lengthX, int lengthY)
    {
        return (x < 0 || y < 0 || x >= lengthX || y >= lengthY);
    }
    

    private static string[] GetInput(string filename)
    {
        return File.ReadAllLines(filename);
    }
}