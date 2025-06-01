using System.Collections.Generic;
using ResourcesSystem;

namespace ResourcesSystem
{
    public class RecipeData
    {
        public string recipeName;
        public List<MaterialCost> materialCosts;

        public RecipeData(string name, List<MaterialCost> costs)
        {
            recipeName = name;
            materialCosts = costs;
        }
    }
}
