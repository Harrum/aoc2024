using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc2024.solutions.day3
{
    public class Day3 : ISolution
    {
        public void Solve()
        {
            Console.WriteLine($"Example 1: {this.Part1("example.txt")}"); // 161
            Console.WriteLine($"Part 1: {this.Part1("input.txt")}"); // 179571322
            Console.WriteLine($"Example 2: {this.Part2("example2.txt")}"); // 48
            Console.WriteLine($"Part 2: {this.Part2("input.txt")}"); // 48
        }

        public string Part1(string input)
        {
            var memory = File.ReadAllText("./input/day3/" + input);
            var regexMul = new Regex("mul\\([0-9]{1,3},[0-9]{1,3}\\)");

            var regexNumbers = new Regex("[0-9]{1,3},[0-9]{1,3}");
            var result = regexMul.Matches(memory);

            var total = 0;

            for (var i = 0; i < result.Count; i++)
            {
                var numbers = regexNumbers.Match(result[i].Value).Value;

                var x = int.Parse(numbers.Split(',')[0]);
                var y = int.Parse(numbers.Split(",")[1]);

                total += x * y;
            }

            return total.ToString();
        }


        public string Part2(string input)
        {
            var memory = File.ReadAllText("./input/day3/" + input);

            memory = RemoveDont(memory);
            var regexMul = new Regex("mul\\([0-9]{1,3},[0-9]{1,3}\\)");
            var regexNumbers = new Regex("[0-9]{1,3},[0-9]{1,3}");
            var result = regexMul.Matches(memory);

            var total = 0;

            for (var i = 0; i < result.Count; i++)
            {
                var numbers = regexNumbers.Match(result[i].Value).Value;

                var x = int.Parse(numbers.Split(',')[0]);
                var y = int.Parse(numbers.Split(",")[1]);

                total += x * y;
            }

            return total.ToString();
        }

        private string RemoveDont(string memory)
        {
            var regexMul = new Regex("mul\\([0-9]{1,3},[0-9]{1,3}\\)");

            var keepGoing = true;

            while (keepGoing)
            {
                var dont = memory.IndexOf("don't()");

                if (dont < 0)
                {
                    keepGoing = false;
                    break;
                }

                var mul = regexMul.Match(memory, dont);

                if (mul.Index < 0)
                {
                    keepGoing = false;
                    break;
                }

                var dok = memory.IndexOf("do()", mul.Index);

                if (dok < 0)
                {
                    keepGoing = false;
                    break;
                }

                memory = memory.Remove(dont, dok - dont - 1);
            }

            return memory;
        }
    }
}
