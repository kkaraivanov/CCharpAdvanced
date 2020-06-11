namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var stringColection = new Dictionary<string, int>();
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var textFile = Path.Combine(path, "text.txt");
            var wordsFile = Path.Combine(path, "words.txt");
            var actualResultFile = Path.Combine(path, "actualResult.txt");
            var expectedResultFile = Path.Combine(path, "expectedResult.txt");
            

            var str = File.ReadAllText(textFile)
                .ToLower()
                .Split(new char[] { ' ', ',', '-', '.', '!', '?', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            
            using (StreamReader sr = new StreamReader(wordsFile))
            {
                while (sr.Peek() >= 0)
                {
                    int count = 0;
                    var currentWord = sr.ReadLine();
                    
                    foreach (var s in str)
                    {
                        if (s == currentWord)
                            count++;
                    }

                    if (!stringColection.ContainsKey(currentWord))
                        stringColection[currentWord] = 0;

                    stringColection[currentWord] = count;
                }
            }

            if (!File.Exists(actualResultFile) || !File.Exists(expectedResultFile))
            {
                using (StreamWriter sw = new StreamWriter(actualResultFile, true))
                {
                    foreach (var (key, value) in stringColection)
                    {
                        sw.WriteLine($"{key} - {value}");
                    }
                }

                using (StreamWriter sw = new StreamWriter(expectedResultFile, true))
                {
                    foreach (var (key, value) in stringColection
                        .OrderByDescending(x => x.Value))
                    {
                        sw.WriteLine($"{key} - {value}");
                    }
                }
            }
        }
    }
}
