﻿using System;

namespace Day1;

public class Solution
{
    public static int Solve(string filename)
    {
        string[] input = File.ReadAllLines(filename);
        int sum = 0;

        List<int> leftColumn = new List<int>();
        List<int> rightColumn = new List<int>();

        foreach (var line in input)
        {
            var split = line.Split("   ");
            
            leftColumn.Add(int.Parse(split[0])); // Add the first column to the leftColumn list
            rightColumn.Add(int.Parse(split[1])); // Split the second column by spaces
        }
        
        leftColumn.Sort();
        rightColumn.Sort();

        for (int i = 0; i < leftColumn.Count; i++)
        {
            if (leftColumn[i] < rightColumn[i] || rightColumn[i] < leftColumn[i])
            {
                var distance = Math.Abs(leftColumn[i] - rightColumn[i]);
                sum += distance;
            }
            else
            {
                continue;
            }
        }

        return sum;
    }
}