namespace SongsQueue
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            var songs = new Queue<string>(Console.ReadLine().Split(", "));

            while (true)
            {
                var commands = Console.ReadLine();
                if (songs.Count == 0)
                {
                    break;
                }

                if (commands.Contains("Play"))
                {
                    songs.Dequeue();
                }

                if (commands.Contains("Add"))
                {
                    var song = commands.Split(" ", 2)[1];
                    if (songs.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(song);
                    }
                }

                if (commands.Contains("Show"))
                {
                    Console.WriteLine(string.Join(", ",songs));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
