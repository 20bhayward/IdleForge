// Assets/Scripts/Crafting/Data/RecipeData.cs
using UnityEngine;
using System.Collections.Generic;
using CraftingSystem.Enums; // For CraftingStationType

namespace CraftingSystem.Data
{
    [CreateAssetMenu(fileName = "NewRecipe", menuName = "Crafting System/Data/Recipe")]
    public class RecipeData : ScriptableObject
    {
        [Header("Recipe Identification")]
        public string recipeID; // Should be unique
        public string displayName; // User-friendly name for UI

        [Header("Crafting Properties")]
        public CraftingStationType craftingStationType; // Which station can craft this
        public ItemData outputItem; // What item this recipe produces
        public int outputQuantity = 1;
        public List<MaterialCost> requiredMaterials; // List of materials and their quantities

        [Header("Crafting Process")]
        public float baseCraftingTime = 5f; // Time in seconds
        public float baseXPGranted = 10f; // Experience points for crafting
        public int requiredPlayerSkillLevel = 0; // For future skill system integration

        protected virtual void OnValidate()
        {
            if (string.IsNullOrEmpty(recipeID))
            {
                recipeID = System.Guid.NewGuid().ToString();
                #if UNITY_EDITOR
                UnityEditor.EditorUtility.SetDirty(this);
                #endif
            }
            if (outputQuantity < 1) outputQuantity = 1;
            if (baseCraftingTime < 0) baseCraftingTime = 0;
        }
    }
}
