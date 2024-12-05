namespace AdventOfCode2024.Day4;
using System.Text.RegularExpressions;

public class Solution
{
    public int Solve1(string filename)
    {
        var input = GetInput(filename);
        var sum = 0;
        
        char[,] matrix = new char[input.Length,input.First().Length];


        for (int i = 0; i < input.Length; i++)
            for (int j = 0; j < input.First().Length; j++)
                matrix[i, j] = input[i][j];
        

        for (int i = 0; i < input.Length; i++)
            for (int j = 0; j < input.First().Length; j++)
                if (matrix[i,j] == 'X') sum += GetMatchCount(i, j, matrix);
            
        return sum;
    }

    public int Solve2(string filename)
    {
        var input = GetInput(filename);
        var sum = 0;
        
        char[,] matrix = new char[input.Length,input.First().Length];


        for (int i = 0; i < input.Length; i++)
        for (int j = 0; j < input.First().Length; j++)
            matrix[i, j] = input[i][j];
        

        for (int i = 1; i < input.Length-1; i++)
        for (int j = 1; j < input.First().Length-1; j++)
            if (matrix[i,j] == 'A') sum += GetCrossCount(i, j, matrix)? 1: 0;
            
        return sum;
    }


    private int GetMatchCount(int x, int y, char[,] arr)
    {
        string key = "XMAS";

        int count = 0;
        int match = 0;

        // horizontal, left->right
        try
        {
            match = key.Where((t, i) => arr[x, y + i] == t).Count();
            if (match == key.Length) count++;
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception" + e);
        }

        // horizontal, right->left
        try
        {
            match = key.Where((t, i) => arr[x, y - i] == t).Count();
            if (match == key.Length) count++;
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception" + e);
        }

        // vertical, top->bottom
        try
        {
            match = key.Where((t, i) => arr[x + i, y] == t).Count();
            if (match == key.Length) count++;
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception" + e);
        }

        // vertical, bottom->top
        try
        {
            match = key.Where((t, i) => arr[x - i, y] == t).Count();
            if (match == key.Length) count++;
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception" + e);
        }
        
        // diagonal, top->left
        try
        {
            match = key.Where((t, i) => arr[x - i, y - i] == t).Count();
            if (match == key.Length) count++;
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception" + e);
        }
        
        // diagonal, top->right
        try
        {
            match = key.Where((t, i) => arr[x + i, y - i] == t).Count();
            if (match == key.Length) count++;
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception" + e);
        }
        
        // diagonal, bottom->left
        try
        {
            match = key.Where((t, i) => arr[x - i, y + i] == t).Count();
            if (match == key.Length) count++;
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception" + e);
        }
        
        // diagonal, bottom->right
        try
        {
            match = key.Where((t, i) => arr[x + i, y + i] == t).Count();
            if (match == key.Length) count++;
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception" + e);
        }

        return count;
    }
    
    private bool GetCrossCount(int x, int y, char[,] arr)
    {
        int count = 0;
        int match = 0;

        for (int i = -1; i <= 1; i+=2)
        {
            try
            {
                if (arr[x+i, y+i] == 'M' && arr[x-i, y-i] == 'S')
                {
                    match++;
                }
                if (arr[x-i, y+i] == 'M' && arr[x+i, y-i] == 'S')
                {
                    match++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        return match == 2;
    }
    
    private static string[] GetInput(string filename)
    {
        return File.ReadAllLines(filename);
    }
}