using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace Data
{
    public class ImageLookup
    {

        public Dictionary<string, int> GetAllImageData()
        {


            // Create a Bitmap object from Comparison file, one row of pixels.
            Dictionary<string, List<Color>> allList = new Dictionary<string, List<Color>>();
            string[] allFiles = Directory.GetFiles(@"..\..\..\References\TestImages\Fixed\");
            foreach (string fName in allFiles)
            {
                string[] splitAbsPath = fName.Split("\\");

                Bitmap compareBitmap = new Bitmap(fName);
                List<Color> compareCol = new List<Color>();
                for (int i = 0; i < 10; i++)
                {
                    compareCol.Add(compareBitmap.GetPixel(i, 2));
                }
                allList.Add(splitAbsPath.Last(), compareCol);
                compareBitmap.Dispose();
            }

            // Create a Bitmap object from Screenshot, will do the most recent one in this folder
            string[] shotFiles = Directory.GetFiles("C:\\Users\\steve\\Documents\\My Games\\Path of Exile\\Screenshots\\");

            Bitmap ScreenShotBitmap = new Bitmap(shotFiles[shotFiles.Count() - 1]);
            List<Color> ScreenShotBitmapCol = new List<Color>();
            //Look for box and start froms there? NEEDS UPDATE FOR OTHER MACHINES
            for (int y = 0; y < ScreenShotBitmap.Height; y++)
            {
                for (int x = 0; x < ScreenShotBitmap.Width; x++)
                {
                    ScreenShotBitmapCol.Add(ScreenShotBitmap.GetPixel(x, y));
                }
            }
            ScreenShotBitmap.Dispose();


            int rowMatchesInput = 0;
            int inARow = 0;
            bool sequencial = false;
            Dictionary<string, int> final = new Dictionary<string, int>();

            foreach (string key in allList.Keys)
            {
                foreach (Color SSco in ScreenShotBitmapCol)
                {
                    foreach (Color co in allList[key])
                    {
                        if (SSco == allList[key][inARow])
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
                        if (inARow == allList[key].Count())
                        {
                            rowMatchesInput += 1;
                            inARow = 0;

                        }
                    }
                }

                final.Add(key, rowMatchesInput);
                rowMatchesInput = 0;
            }
            return final;

        }


    }
}


