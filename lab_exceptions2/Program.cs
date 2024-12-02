﻿using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        Regex regexExtForImage = new Regex("^((bmp)|(gif)|(tiff?)|(jpe?g)|(png))$", RegexOptions.IgnoreCase);
        string[] files = Directory.GetFiles(@"images");

        foreach (string fileName in files)
        {
            if (fileName.EndsWith(".DS_Store"))
            {
                Console.WriteLine($"Файл {fileName} пропущено, оскільки це не картинка.");
                continue;
            }
            string extension = Path.GetExtension(fileName);
            try
            {
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(fileName);
                string newFile = fileNameWithoutExt + "-mirrored.gif";

                Bitmap bitmap = new Bitmap(fileName);
                Bitmap mirrored = (Bitmap)bitmap.Clone();
                mirrored.RotateFlip(RotateFlipType.RotateNoneFlipX);
                mirrored.Save(newFile);
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
