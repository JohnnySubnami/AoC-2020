using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC2020
{
    class Program
    {
        static void Main(string[] args)
        {
            string day;
            string part;
            int dayPart;

            Console.Write("Enter the day of challenge: ");
            day = Console.ReadLine(); 
            Console.Write("Enter 1 or 2 for part: ");
            part = "0"+Console.ReadLine();
            dayPart = int.Parse(day + part);

            switch (dayPart)
            {
                #region Day 1 Part 1
                case 101:
                    string filePath = @"C:\Advent of Code 2020\inputs\day1input.txt";
                    List<string> lines = new();
                    lines = File.ReadLines(filePath).ToList<string>();
                    List<int> numbers = lines.Select(int.Parse).ToList();
                    int sum = 0;
                    int cc = 0;
                    foreach (int number in numbers)
                    {
                        foreach (int number2 in numbers)
                        {
                            sum = number + number2;
                            if (sum == 2020 && cc == 0)
                            {
                                Console.WriteLine($"Match found at {number}, {number2}, product is " + number * number2);
                                cc += 1;
                            }
                        }
                    }
                    break;
                #endregion
                #region Day 1 Part 2
                case 102:
                    filePath = @"C:\Advent of Code 2020\inputs\day1input.txt";
                    lines = File.ReadLines(filePath).ToList<string>();
                    numbers = lines.Select(int.Parse).ToList();
                    sum = 0;
                    cc = 0;

                    foreach (int number in numbers)
                    {
                        foreach (int number2 in numbers)
                        {
                            foreach (int number3 in numbers)
                            {
                                sum = number + number2 + number3;
                                if (sum == 2020 && cc == 0)
                                {
                                    Console.WriteLine($"Match found at {number}, {number2}, {number3} product is " + number * number2 * number3);
                                    cc += 1;
                                }
                            }
                        }
                    }
                    break;
                #endregion
                #region Day 2 Part 2
                case 202:
                    filePath = @"C:\Advent of Code 2020\inputs\day2input.txt";
                    lines = File.ReadLines(filePath).ToList<string>();
                    int totalGood = 0;
                    int totalChecked = 0;
                    string pattern = @"(\d{1,2})-(\d{1,2})\s(\w):\s(\w*)";
                    int currentElement = 0;
                    string currentLine = lines.ElementAt<string>(currentElement);

                    foreach (string line in lines)
                    {

                        MatchCollection myMatches = Regex.Matches(line, pattern);

                        foreach (Match match in myMatches)
                        {

                            GroupCollection groups = match.Groups;
                            int firstPlace = int.Parse(groups[1].Value) - 1;
                            int secondPlace = int.Parse(groups[2].Value) - 1;
                            char passLetter = char.Parse(groups[3].Value);
                            char[] password = groups[4].Value.ToCharArray();
                            if (password.ElementAt<char>(firstPlace) == passLetter ^ password.ElementAt<char>(secondPlace) == passLetter)
                            {
                                totalGood++;
                            }
                            totalChecked++;
                        }
                    }
                    Console.WriteLine($"Total Checked: {totalChecked}");
                    Console.WriteLine($"Total good: {totalGood}");
                    break;
                #endregion
                #region Day 2 Part 1
                case 201:
                    filePath = @"C:\Advent of Code 2020\inputs\day2input.txt";
                    lines = File.ReadLines(filePath).ToList<string>();
                    totalGood = 0;
                    totalChecked = 0;
                    pattern = @"(\d{1,2})-(\d{1,2})\s(\w):\s(\w*)";
                    currentElement = 0;
                    currentLine = lines.ElementAt<string>(currentElement);

                    foreach (string line in lines)
                    {

                        MatchCollection myMatches = Regex.Matches(line, pattern);

                        foreach (Match match in myMatches) //Part 1
                        {
                            GroupCollection groups = match.Groups;
                            int passCount = 0;
                            int minPass = int.Parse(groups[1].Value);
                            int maxPass = int.Parse(groups[2].Value);
                            char passwordLetter = char.Parse(groups[3].Value);
                            char[] password = groups[4].Value.ToCharArray();

                            foreach (Char letter in password)
                            {
                                if (letter == passwordLetter)
                                {
                                    passCount++;
                                }
                            }
                            if (passCount <= maxPass && passCount >= minPass)
                            {
                                totalGood++;
                            }
                            totalChecked++;
                            currentElement++;
                        }
                    }
                    Console.WriteLine($"Total Checked: {totalChecked}");
                    Console.WriteLine($"Total good: {totalGood}");
                    break;
                #endregion
                #region Day 3 Part 1
                case 301:
                    filePath = @"C:\Advent of Code 2020\inputs\day3input.txt";
                    lines = File.ReadLines(filePath).ToList<string>();
                    int x = 0;
                    int treeCount = 0;

                    foreach (string line in lines)
                    {
                        char spot = line.ElementAt(x);
                        if (spot == char.Parse("#"))
                        {
                            treeCount++;
                        }
                        x += 3;
                        if (x >= line.Length)
                        {
                            x -= line.Length;
                        }
                    }
                    Console.WriteLine("You hit {0} trees with a slope of 3:1", treeCount);
                    break;
                #endregion
                #region Day 3 Part 2
                case 302:
                    filePath = @"C:\Advent of Code 2020\inputs\day3input.txt";
                    lines = File.ReadLines(filePath).ToList<string>();
                    List<int> slopes = new();
                    List<int> treesHit = new();
                    slopes.Add(1);
                    slopes.Add(3);
                    slopes.Add(5);
                    slopes.Add(7);

                    double treesMultiplied = 1;

                    x = 0;
                    treeCount = 0;
                    foreach (int slope in slopes)
                    {
                        foreach (string line in lines)
                        {
                            char spot = line.ElementAt(x);
                            if (spot == char.Parse("#"))
                            {
                                treeCount++;
                            }
                            x += slope;
                            if (x >= line.Length)
                            {
                                x -= line.Length;
                            }
                        }
                        treesHit.Add(treeCount);
                        treeCount = 0;
                        x = 0;
                    }

                    int skip = 0;
                    foreach (string line in lines)
                    {


                        if (skip == 0)
                        {
                            char spot = line.ElementAt(x);
                            if (spot == char.Parse("#"))
                            {
                                treeCount++;
                            }
                            x++;
                            if (x >= line.Length)
                            {
                                x -= line.Length;
                            }
                        }
                        skip = Math.Abs(skip - 1);
                    }

                    treesHit.Add(treeCount);
                    treeCount = 0;
                    x = 0;
                    foreach(int tree in treesHit)
                    {
                        Console.WriteLine(tree);
                    }
                    Console.WriteLine();

                    foreach (int tree in treesHit)
                    {
                        Console.Write($"Multiplying {treesMultiplied} by {tree}. ");
                        treesMultiplied = treesMultiplied * tree;
                        Console.WriteLine("Result is " + treesMultiplied + ".");
                    }
                    Console.WriteLine("The product of all your slopes is: {0} ", treesMultiplied);
                    break;
                #endregion

                default:
                    Console.WriteLine("Invalid Day/Part");
                    break;
            }
            Console.ReadKey();
        }
    }
}
