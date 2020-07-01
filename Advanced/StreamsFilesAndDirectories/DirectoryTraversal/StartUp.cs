namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;

    class StartUp
    {
        static void Main(string[] args)
        {
            var inputDirectory = Console.ReadLine();
            var readFilesInDirectory = @$"{inputDirectory}";
            string userPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var reportFile = Path.Combine(userPath, "report.txt");
            var colectionFile = new Dictionary<string, Dictionary<string, double>>();
            var dir = new DirectoryInfo(readFilesInDirectory);
            var fileInfo = dir.GetFiles("*.*");
            ;
            foreach (var file in fileInfo)
            {
                string extension = file.Extension;
                string fullName = file.Name;
                var fileSize = file.Length;

                if (!colectionFile.ContainsKey(extension))
                    colectionFile[extension] = new Dictionary<string, double>();

                if (!colectionFile[extension].ContainsKey(fullName))
                    colectionFile[extension][fullName] = 0.0;

                colectionFile[extension][fullName] = (fileSize * 1.0) / 8000;
            }

            foreach (var (key, value) in colectionFile
                .OrderByDescending(x => x.Value.Values.Count())
                .ThenBy(x => x.Key))
            {
                using (StreamWriter sw = new StreamWriter(reportFile, true))
                {
                    sw.WriteLine($"{key}");
                    foreach (var (name, size) in value
                    .OrderBy(x => x.Value))
                    {
                        sw.WriteLine($"--{name} - {size:f3}");
                    }
                }
            }
        }
    }
}
