namespace CopyBinaryFile
{
    using System;
    using System.IO;

    class StartUp
    {
        static void Main()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var readFileName = "copyMe.png";
            var writeFileName = "copyTo.png";
            var readFile = Path.Combine(path, readFileName);
            var writeFile = Path.Combine(path, writeFileName);

            using FileStream readStream = new FileStream(readFile, FileMode.Open);
            using (FileStream writer = new FileStream(writeFile, FileMode.Create))
            {
                byte[] buffer = new byte[2048];
                int bytesRead;

                while ((bytesRead = readStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    writer.Write(buffer, 0, bytesRead);
                }
            }
        }
    }
}
