namespace AdventOfCode2024.Day5;

public class Solution
{
    public int Solve1(string filename)
    {
        var input = GetInput(filename);
        var sum = 0;

        var rules =
            ParseRules(input.TakeWhile(line
                => !string.IsNullOrEmpty(line)).ToList());

        var updates =
            ParseUpdates(input.SkipWhile(line
                => !string.IsNullOrEmpty(line)).Skip(1).ToList());

        foreach (var update in updates)
        {
            if (IsCorrectOrder(update, rules))
            {
                var middlePage = update[update.Count / 2];
                sum += middlePage;
            }
        }

        return sum;
    }

    public int Solve2(string filename)
    {
        var input = GetInput(filename);
        var sum = 0;

        var rules =
            ParseRules(input.TakeWhile(line => !string
                .IsNullOrEmpty(line)).ToList());
        
        var updates =
            ParseUpdates(input.SkipWhile(line => !string
                .IsNullOrEmpty(line)).Skip(1).ToList());

        foreach (var update in updates)
        {
            if (!IsCorrectOrder(update, rules))
            {
                var orderedUpdate = OrderUpdate(update, rules);
                var middlePage = orderedUpdate[orderedUpdate.Count / 2];
                sum += middlePage;
            }
            
        }

        return sum;
    }

    private static string[] GetInput(string filename)
    {
        return File.ReadAllLines(filename);
    }

    private static Dictionary<int, List<int>> ParseRules(List<string> rules)
    {
        var ruleDict = new Dictionary<int, List<int>>();

        foreach (var rule in rules)
        {
            var parts = rule.Split('|').Select(int.Parse).ToArray();
            if (!ruleDict.ContainsKey(parts[0])) ruleDict[parts[0]] = new List<int>();
            ruleDict[parts[0]].Add(parts[1]);
        }

        return ruleDict;
    }

    private static List<List<int>> ParseUpdates(List<string> updates)
    {
        return updates.Select(update => update.Split(',').Select(int.Parse).ToList()).ToList();
    }

    private static bool IsCorrectOrder(List<int> update, Dictionary<int, List<int>> rules)
    {
        var indexMap = update.Select((page, index) => new { page, index })
            .ToDictionary(x => x.page, x => x.index);

        foreach (var rule in rules)
            if (indexMap.TryGetValue(rule.Key, out int value))
                if (rule.Value.Any(afterPage => indexMap.ContainsKey(afterPage) && value > indexMap[afterPage]))
                    return false;
                

        return true;
    }

    private static List<int> OrderUpdate(List<int> update, Dictionary<int, List<int>> rules)
    {
        var orderedUpdate = new List<int>(update);
        
        orderedUpdate.Sort((a, b) =>
        {
            if (rules.ContainsKey(a) && rules[a].Contains(b)) return -1;
            if (rules.ContainsKey(b) && rules[b].Contains(a)) return 1;
            return 0;
        });

        return orderedUpdate;
    }
}