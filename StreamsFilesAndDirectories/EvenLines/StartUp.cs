namespace EvenLines
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    class StartUp
    {
        static void Main()
        {
            var stringColection = new List<string>();
            var separators = new List<char>() { '-', ',', '.', '!', '?' };
            var myPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "text.txt");
            
            using (StreamReader sr = new StreamReader(myPath))
            {
                int counter = 0;
                
                while (sr.Peek() >= 0)
                {
                    var temp = sr.ReadLine().Split(' ');

                    if (counter % 2 == 0)
                    {
                        var sb = new StringBuilder();

                        for (int i = temp.Length - 1; i >= 0; i--)
                        {
                            sb.Append($"{temp[i]} ");
                        }

                        stringColection.Add(sb.ToString().TrimEnd());
                    }

                    counter++;
                }
            }

            for (int i = 0; i < stringColection.Count; i++)
            {
                foreach (var c in stringColection[i])
                    if (separators.Contains(c))
                        stringColection[i] = stringColection[i].Replace(c, '@');
            }

            stringColection.ForEach(Console.WriteLine);
        }
    }
}
