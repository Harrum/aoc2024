using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc2024.solutions.day4
{
    public class Day4 : ISolution
    {
        public void Solve()
        {
            Console.WriteLine($"Example 1: {this.Part1("example.txt")}");
        }

        private string Part1(string input)
        {
            var puzzle = this.GetInput(input);
            var total = 0;

            foreach (var row in puzzle)
            {
                var line = new string(row);
                total += Regex.Matches(line, "XMAS").Count;
                total += Regex.Matches(line, "SAMX").Count;

                //Console.WriteLine(line);
            }

            for (var y = 0; y < puzzle.Length; y++)
            {
                var line = string.Empty;
                for (var x = 0; x < puzzle[y].Length; x++)
                {
                    line += puzzle[x][y];
                }

                total += Regex.Matches(line, "XMAS").Count;
                total += Regex.Matches(line, "SAMX").Count;

                // Console.WriteLine(line);
            }

            for (var x = 0; x < puzzle.Length; x++)
            {
                var line = string.Empty;
                for (var y = 0; y < puzzle[x].Length; y++)
                {
                    line += puzzle[x][y];
                }

                total += Regex.Matches(line, "XMAS").Count;
                total += Regex.Matches(line, "SAMX").Count;

                Console.WriteLine(line);
            }
            return total.ToString();
        }

        private char[][] GetInput(string input)
        {
            var file = File.ReadAllLines("./input/day4/" + input);

            return file.Select(l => l.Select(c => c).ToArray()).ToArray();
        }
    }
}
