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

            Dictionary<string, List<Color>> allList = new Dictionary<string, List<Color>>();
            List<Color> compagreCol = new List<Color>();
            for (int i = 0; i < 10; i++)
            {
                compagreCol.Add(compareBitmap.GetPixel(i, 0));
            }
            allList.Add("shar", compagreCol);

            List<Color> hasstecompagreCol = new List<Color>();
            for (int i = 0; i < 10; i++)
            {
                hasstecompagreCol.Add(compareBitmap.GetPixel(i, 2));
            }
            allList.Add("hasted", hasstecompagreCol);

            // Create a Bitmap object from Screenshot.
            Bitmap ScreenShotBitmap = new Bitmap("C:\\Users\\steve\\source\\repos\\ArchnemesisRecipeSolver\\TestingFrontend\\TestImages\\screenshot-0002.png");

            List<Color> ScreenShotBitmapCol = new List<Color>();
            //Look for box and start froms there?
            for (int y = 0; y < ScreenShotBitmap.Height; y++)
            {
                            Console.WriteLine(y);
                try
                {
                    for (int x = 0; x < ScreenShotBitmap.Width; x++)
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
            Dictionary<string, int> final = new Dictionary<string, int>();

            foreach (string key in allList.Keys)
            {
                foreach (Color SSco in ScreenShotBitmapCol)
                {
                    foreach (Color co in allList[key])
                    {
                        if (SSco == compagreCol[inARow])
                        {
                            sequencial = true;
                            inARow += 1;
                            break;
                        }
                        else
                        {
                            sequencial = false;
                            inARow += 0;
                            break;
                        }
                    }
                    if (sequencial)
                    {
                        if (inARow == compagreCol.Count())
                        {
                            rowMatchesInput += 1;
                            inARow = 0;

                        }
                    }
                }

                final.Add(key, rowMatchesInput);
                rowMatchesInput = 0;
            }

            //if (nonMatch < compagreCol.Count())
            //{
            //    inARow += 1;
            //    nonMatch = 0;
            //    sequencial = true;
            //}
            //else
            //{
            //    sequencial = false;
            //    nonMatch = 0;
            //}
            //if (sequencial)
            //{
            //    if (inARow == compagreCol.Count())
            //    {
            //        rowMatchesInput += 1;
            //        inARow = 0;

            //    }
            //}
            //else if(!sequencial)
            //{
            //    inARow = 0;
            //}

            Console.WriteLine("Hello World!");
        }


    }
}


