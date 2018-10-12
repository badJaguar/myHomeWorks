using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Maniac
//Если делать в лоб, то получается сразу... А тут я не уверен, что сделал правильно. Пожалуйста, нужен комментарий
{
    static class Program
    {
        static void Main()
        {
            var watch = new Stopwatch();
            string[] neededText = { "Ты", "умрешь", "этой", "ночью" };

            watch.Start();
            var lines = QueryMethod();

            var droppedText = 
                from words in neededText
                from text in lines
                where text.Contains(words)
                group text by words into c
                orderby c.Key.StartsWith("ь")
                select c.Key;

            foreach (var d in droppedText)
            {
                Console.Write($"{d} ");
            }
            Console.WriteLine($"\nОперация выполнена за {watch.ElapsedMilliseconds} милисекунд(ы).");
            Console.ReadKey();
        }

        static IEnumerable<string> QueryMethod()
        {
            var filePath = @"..\..\..\Polyarnyy_Skazka-o-samoubiystve-_RuLit_Me.txt";
            var content = File.ReadLines(filePath, Encoding.Default);
            return content.SelectMany(line => line.Split(' '));
        }
    }
}