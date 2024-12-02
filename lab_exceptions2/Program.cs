using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        Regex regexExtForImage = new Regex("^((bmp)|(gif)|(tiff?)|(jpe?g)|(png))$", RegexOptions.IgnoreCase);
        string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());
        foreach (string fileName in files)
        {
            string extension = Path.GetExtension(fileName);
            try
            {

            }
        }
    }
}
