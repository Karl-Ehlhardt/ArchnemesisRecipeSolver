using Ganss.Excel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class RecipeLookup
    {

        public List<ConsoleInstructions> GetMissingIngredients(Dictionary<string, int> needed)
        {
            List<ConsoleInstructions> instruct = new List<ConsoleInstructions>();
            //get the Json filepath  
            string json = System.IO.File.ReadAllText(@"C:\Users\steve\source\repos\ArchnemesisRecipeSolver\Data\Recipes.json");
            IEnumerable<Recipe> recipelist = JsonConvert.DeserializeObject<List<Recipe>>(json); ;
            return instruct;
        }

    }
}
