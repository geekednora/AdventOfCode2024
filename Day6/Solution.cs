namespace AdventOfCode2024.Day6;

public class Solution
{
    public int Solve1(string filename)
    {
        /* Default variables */
        var input = GetInput(filename);
        var sum = 0;
        /* End of default */
        
        char[][] map = input.Select(line => line.ToCharArray()).ToArray();
        
        const char guard = '^';
        const char obstacle = '#';
        const char visited = 'X';
        int guardPosX = 0, guardPosY = 0;
        int direction = 0; // 0 = up, 1 = right, 2 = down, 3 = left

        bool isOut = false;
        HashSet<(int, int)> visitedPos = [];

        for (int y = 0; y < map.Length; y++)
        {
            for (int x = 0; x < map.First().Length; x++)
            {
                if (map[y][x] == guard)
                {
                    guardPosX = x;
                    guardPosY = y;
                }
            }
        }
        
        visitedPos.Add((guardPosY, guardPosX));
        map[guardPosY][guardPosX] = visited;

        while (!isOut)
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
                isOut = true;
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
                
                
                if (map[guardPosY][guardPosX] != visited)
                {
                    visitedPos.Add((guardPosY, guardPosX));
                    map[guardPosY][guardPosX] = visited;
                }
            }
        }

        return visitedPos.Count;
    }

    public int Solve2(string filename)
    {
        var input = GetInput(filename);
        var sum = 0;

        return sum;
    }

    private static string[] GetInput(string filename)
    {
        return File.ReadAllLines(filename);
    }
    
    
    //private char[,] GetObstacles(var input)
}