namespace aoc2024.solutions.day1;

public class Day1 : ISolution
{
    public void Solve()
    {
        Console.WriteLine($"Example 1: {this.Part1("example.txt")}"); // 11
        Console.WriteLine($"Part 1: {this.Part1("input.txt")}"); // 1580061
        Console.WriteLine($"Example 2: {this.Part2("example.txt")}"); // 
        Console.WriteLine($"Part 2: {this.Part2("input.txt")}"); // 
    }

    private string Part1(string input)
    {
        var (left, right) = this.GetInput(input);

        var answer = 0;

        while (left.Any())
        {
            var minLeft = left.Min();
            var minRight = right.Min();

            var diff = Math.Abs(minLeft - minRight);
            answer += diff;
            left.Remove(minLeft);
            right.Remove(minRight);
        }

        return answer.ToString();
    }

    private string Part2(string input)
    {
        var (left, right) = this.GetInput(input);

        var answer = 0;

        foreach (var value in left)
        {
            var rightCount = right.Count(r => r == value);

            answer += value * rightCount;
        }

        return answer.ToString();
    }

    private (List<int> Left, List<int> Right) GetInput(string input)
    {
        var file = File.ReadAllLines("./input/day1/" + input);

        var left = file.Select(l => int.Parse(l.Split("   ").First())).ToList();
        var right = file.Select(l => int.Parse(l.Split("   ").Last())).ToList();

        return (left, right);
    }
}
