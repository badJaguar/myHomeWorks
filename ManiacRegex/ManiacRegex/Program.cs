using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ManiacRegex
{
    class Program
    {
        static void Main()
        {
            var watch = new Stopwatch();
            watch.Start();

            var input = Read(Input.Directive);
            string[] neededText = { "Ты", "умрешь", "этой", "ночью" };

            foreach (var word in neededText)
            {
                var matches = Regex.Match(input, word);
                var fail = Regex.IsMatch(input, word);

                foreach (var result in matches.Groups)
                    if (fail)
                        Console.WriteLine(
                            "\nОперация не может быть выполнена, так как один или \nнесколько компонентов утсутствует(ют).");
                    else
                        Console.Write($"{result} ");
                break;

            }
            Console.WriteLine($"\nОперация выполнена за {watch.ElapsedMilliseconds} милисекунд(ы).");
            Console.ReadKey();
        }

        private static string Read(string fileName)
        {
            string output;
            using (var reader = new StreamReader(fileName, Encoding.Default))
                output = reader.ReadToEnd();

            return output;
        }
    }
}
