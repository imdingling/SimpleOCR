using System;
using System.Collections.Generic;
using SimpleOCR.Properties;

namespace SimpleOCR
{
    class Program
    {
        static void Main(string[] args)
        {
            var image = new List<ImageChar>();
            //ALEXANDRO AMARAL JUSTINO
            const string fullWord = "ALEXANDROAMARALJUSTINO";
            var bmp = Resources.alexandro;
            ImageChar curImageChar = null;
            for (var x = 0; x < bmp.Width; x++)
            {
                var whiteColumn = true;
                var colors = new bool[bmp.Height];
                for (var y = 0; y < bmp.Height; y++)
                {
                    var clr = bmp.GetPixel(x, y);

                    whiteColumn = whiteColumn && clr.R > 200 && clr.G > 200 && clr.B> 200;
                    colors[y] = clr.R > 200 && clr.G > 200 && clr.B > 200;
                }
                if (!whiteColumn)
                {
                    if (curImageChar == null)
                        curImageChar = new ImageChar(bmp.Height, colors);
                    else
                        curImageChar.AppendColors(colors);

                } else
                {
                    if(curImageChar != null)
                    {
                        curImageChar.Letter = fullWord[image.Count].ToString();
                        image.Add(curImageChar);
                        curImageChar = null;
                    }
                }
            }
            Console.WriteLine(image.Count == "ALEXANDROAMARALJUSTINO".Length);
            foreach (var i in image)
                Console.Write(i);
            Console.WriteLine();
            Console.WriteLine(image[0].Equals(image[4]) ? "Deu certo" : "Nao deu");
            Console.WriteLine();
        }
    }
}