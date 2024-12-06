using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        Regex regexExtForImage = new Regex("^.((bmp)|(gif)|(tiff?)|(jpe?g)|(png))$", RegexOptions.IgnoreCase);
        string[] files = Directory.GetFiles(@"C:\Users\lizaz\source\repos\lab\lab\bin\Debug\net8.0\images");

        foreach (string fileName in files)
        {
            string extension = Path.GetExtension(fileName);
            try
            {
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(fileName);
                string newFile = fileNameWithoutExt + "-mirrored.gif";

                using (FileStream s = new FileStream(fileName, FileMode.Open))
                {
                    Bitmap bitmap = new Bitmap(s);
                    Bitmap mirrored = (Bitmap)bitmap.Clone();
                    mirrored.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    mirrored.Save(@"C:\Users\lizaz\source\repos\lab\lab\bin\Debug\net8.0\images\" + newFile);
                }
            }
            catch
            {
                if (regexExtForImage.IsMatch(extension))
                {
                    Console.WriteLine($"Файл {fileName} не був прочитаний, хоча є картинкою.");
                }
                else
                {
                    Console.WriteLine($"Файл {fileName} не є картинкою.");
                }
            }

        }
        Console.ReadKey();
    }
}