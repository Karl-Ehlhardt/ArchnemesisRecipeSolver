using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace TestingFrontend
{
    class Program
    {
        static void Main(string[] args)
        {
            //FileStream screenshot = File.OpenRead("C:\\Users\\steve\\source\\repos\\ArchnemesisRecipeSolver\\TestingFrontend\\TestImages\\screenshot-0002.png");
            //FileStream compare = File.OpenRead("C:\\Users\\steve\\source\\repos\\ArchnemesisRecipeSolver\\TestingFrontend\\TestImages\\screenshot-0002 - Copy.png");


            //byte[] buffer = new byte[16 * 1024];
            //MemoryStream msScreenShot = new MemoryStream();
            //MemoryStream mscompare = new MemoryStream();


            //int read;
            //while ((read = screenshot.Read(buffer, 0, buffer.Length)) > 0)
            //{
            //    msScreenShot.Write(buffer, 0, read);
            //}
            //byte[] screenshotarray = msScreenShot.ToArray();

            //read = 0;
            //buffer = new byte[16 * 1024];
            //while ((read = compare.Read(buffer, 0, buffer.Length)) > 0)
            //{
            //    mscompare.Write(buffer, 0, read);
            //}
            //byte[] comparebytearray = mscompare.ToArray();
            ////comparebytearray = comparebytearray.
            //int lol = 0;
            //for (int i = 0; i < screenshotarray.Length; i++)
            //{
            //    if (screenshotarray[i] != comparebytearray[i])
            //    {
            //        lol = i;
            //        break;
            //    }
            //    if (screenshotarray.Skip(i).Take(comparebytearray.Length).SequenceEqual(comparebytearray))
            //    {
            //        lol = i;
            //        break;
            //    }
            //}

            // Create a Bitmap object from Comparison file, one row of pixels.
            Bitmap compareBitmap = new Bitmap("C:\\Users\\steve\\source\\repos\\ArchnemesisRecipeSolver\\TestingFrontend\\TestImages\\Sharkari.png");

            List<Color> compagreCol = new List<Color>();
            for (int i = 0; i < 50; i++)
            {
                compagreCol.Add(compareBitmap.GetPixel(i, 0));
            }

            // Create a Bitmap object from Screenshot.
            Bitmap ScreenShotBitmap = new Bitmap("C:\\Users\\steve\\source\\repos\\ArchnemesisRecipeSolver\\TestingFrontend\\TestImages\\screenshot-0002.png");

            List<Color> ScreenShotBitmapCol = new List<Color>();
            for (int y = 0; y < 1000; y++)
            {
                try
                {
                    for (int x = 0; x < 1000; x++)
                    {
                        try
                        {

                            ScreenShotBitmapCol.Add(ScreenShotBitmap.GetPixel(x, y));
                        }
                        catch
                        {
                            break;
                        }

                    }

                }
                catch
                {
                    break;
                }
            }

            int rowMatchesInput = 0;
            int inARow = 0;
            int nonMatch = 0;
            bool sequencial = false;
            foreach (Color SSco in ScreenShotBitmapCol)
            {
                foreach (Color co in compagreCol)
                {
                    if (SSco != co)
                    {
                        nonMatch += 1;
                    }
                }

                if (nonMatch < compagreCol.Count())
                {
                    inARow += 1;
                    nonMatch = 0;
                    sequencial = true;
                }
                else
                {
                    sequencial = false;
                    nonMatch = 0;
                }
                if (sequencial)
                {
                    if (inARow == compagreCol.Count())
                    {
                        rowMatchesInput += 1;
                        inARow = 0;

                    }
                }
                else if(!sequencial)
                {
                    inARow = 0;
                }

            }


            Console.WriteLine("Hello World!");
        }
    }
}
