using Data;
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
            ImageLookup imgLook = new ImageLookup();
            RecipeLookup recLook = new RecipeLookup();

            Dictionary<string, int> allIconsInScreenshot = imgLook.GetAllImageData();
            //Dictionary<string, int> allRecpies = recLook.GetIngredients();



            int AllIcons = 0;
            foreach (string key in allIconsInScreenshot.Keys)
            {
                Console.WriteLine($"{key} - {allIconsInScreenshot[key]}");
                AllIcons += allIconsInScreenshot[key];
            }

            Console.WriteLine($"Total Icons- {AllIcons}");

            Console.ReadLine();
        }


    }
}


