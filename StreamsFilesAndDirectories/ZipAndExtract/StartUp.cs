namespace ZipAndExtract
{
    using System;
    using System.IO;
    using System.IO.Compression;

    class StartUp
    {
        static void Main(string[] args)
        {
            string pathName = @"\zipPath\";
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = @"MyZip.zip";
            string compressFile = string.Empty;

            Console.WriteLine($"The file \"{fileName}\" will be created in \"{filePath + pathName}\"!");
            Console.WriteLine();

            if (!Directory.Exists(filePath + pathName))
                Directory.CreateDirectory(filePath + pathName);

            Console.WriteLine("Select file/files to compress");
            compressFile = Console.ReadLine();
            var source = $"{filePath}{pathName}{fileName}";
            var files = Directory.GetFiles(@$"{compressFile}");

            using (var archive = ZipFile.Open(source, ZipArchiveMode.Create))
            {
                foreach (var fileInPath in files)
                {
                    archive.CreateEntryFromFile(fileInPath, Path.GetFileName(fileInPath));
                }
            }

            var unZipFiles = @$"{filePath}{pathName}Extract\";
            Console.WriteLine($"The file \"{fileName}\" is created." +
                              $"{Environment.NewLine}Do you want it to be unzipped?" +
                              $"{Environment.NewLine}\"Y\" for Yes or \"N\" for No");
            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.Y)
            {
                ZipFile.ExtractToDirectory(source, unZipFiles);
            }
            else if(key.Key == ConsoleKey.N)
                return;
        }
    }
}
