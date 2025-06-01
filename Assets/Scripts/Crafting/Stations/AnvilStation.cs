// Assets/Scripts/Crafting/Stations/AnvilStation.cs
using UnityEngine;
using CraftingSystem.Data;
using CraftingSystem.Enums;

namespace CraftingSystem.Stations
{
    public class AnvilStation : CraftingStation
    {
        protected void Awake()
        {
            stationName = "Anvil";
            stationType = CraftingStationType.Anvil;
        }

        protected override void CompleteCraft()
        {
            if (currentRecipe == null)
            {
                // This check is also in base, but good for specific logs before calling base.
                Debug.LogError($"{stationName}: CompleteCraft called with no current recipe. This should not happen if logic is correct.");
                isCrafting = false; // Ensure state is reset
                return;
            }

            // Specific Anvil completion message using outputItem's name
            Debug.Log($"Anvil forged: {currentRecipe.outputItem.itemName} (x{currentRecipe.outputQuantity}). (Placeholder for adding to inventory)");

            // Call base.CompleteCraft() to handle shared logic:
            // inventory update (placeholder), XP grant (placeholder), and starting next craft.
            base.CompleteCraft();
        }

        // Optional: Override other methods if Anvil has unique behavior.
        // public override bool CanCraftRecipe(RecipeData recipe) { ... }
        // protected override void OnCraftingTick() { ... }
    }
}
