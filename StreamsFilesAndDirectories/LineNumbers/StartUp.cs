namespace LineNumbers
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
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var readPath = Path.Combine(path, "text.txt");
            var writePath = Path.Combine(path, "outpoot.txt");

            using (StreamReader sr = new StreamReader(readPath))
            {
                int lineNumber = 1;

                while (sr.Peek() >= 0)
                {
                    var temp = sr.ReadLine();
                    var sb = new StringBuilder();
                    int letherCount = 0;
                    int punctuationCount = 0;

                    foreach (var c in temp)
                    {
                        int currentChar = c;
                        if (currentChar >= 65)
                            letherCount++;
                        else if (currentChar>= 33 && currentChar < 65)
                            punctuationCount++;
                    }
                    sb.Append($"Line {lineNumber}: {temp} ({letherCount})({punctuationCount})");
                    stringColection.Add(sb.ToString());

                    lineNumber++;
                }
            }
            
            File.WriteAllLines(writePath, stringColection);
        }
    }
}
