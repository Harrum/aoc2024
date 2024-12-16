using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2024.solutions.day2
{
    public class Day2 : ISolution
    {
        public void Solve()
        {
            Console.WriteLine($"Example 1: {Part2("example.txt", false)}"); // 2
            Console.WriteLine($"Part 1: {Part2("input.txt", false)}"); // 591
            Console.WriteLine($"Example 2: {Part2("example.txt", true)}"); // 4
            Console.WriteLine($"Part 2: {Part2("input.txt", true)}"); // 621
        }

        private string Part2(string input, bool dampen)
        {
            var reports = GetInput(input);
            var dampenerReports = new List<int[]>();
            var safeCount = 0;

            foreach (var report in reports)
            {
                var safe = IsSafe2(report, dampen);

                if (safe)
                {
                    safeCount++;
                }
            }

            return safeCount.ToString();
        }

        private bool IsSafe2(int[] report, bool dampen)
        {
            var asc = report.Last() > report.First();
            var safe = true;

            for (var i = 1; i < report.Count(); i++)
            {
                var first = report[i - 1];
                var current = report[i];

                if (asc)
                {
                    if (current <= first || current - first > 3)
                    {
                        if (dampen)
                        {
                            for (int x = 0; x < report.Count(); x++)
                            {
                                var dampenedList = report.ToList();
                                dampenedList.RemoveAt(x);
                                var bruteForce = IsSafe2(dampenedList.ToArray(), false);

                                if (bruteForce)
                                {
                                    return true;
                                }
                            }
                        }

                        safe = false;
                        break;
                    }
                }
                else
                {
                    if (current >= first || first - current > 3)
                    {
                        if (dampen)
                        {
                            for (int x = 0; x < report.Count(); x++)
                            {
                                var dampenedList = report.ToList();
                                dampenedList.RemoveAt(x);
                                var bruteForce = IsSafe2(dampenedList.ToArray(), false);

                                if (bruteForce)
                                {
                                    return true;
                                }
                            }
                        }

                        safe = false;
                        break;
                    }
                }
            }

            return safe;
        }

        private IEnumerable<int[]> GetInput(string input)
        {
            var file = File.ReadAllLines("./input/day2/" + input);

            var reports = new List<List<int>>();

            return file.Select(l => l.Split(" ").Select(s => int.Parse(s)).ToArray());
        }
    }
}
