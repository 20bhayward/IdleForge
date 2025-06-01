using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewRecipeData", menuName = "Gameplay/Recipe Data")]
public class RecipeData : ScriptableObject
{
    public string recipeName;
    public Sprite outputItemIcon; // For now, this can be null or assigned a default Unity sprite if available
    public List<string> materials; // Example: "2x Iron Ore", "1x Coal"
    // Later, materials could be a List<MaterialCost> where MaterialCost is a custom class/struct
}
