// Assets/Scripts/Player/PlayerInventory.cs
using UnityEngine;
using System.Collections.Generic;
using CraftingSystem.Data; // Required for MaterialCost and ItemData

namespace Player
{
    /// <summary>
    /// Placeholder class for player inventory interactions.
    /// This class will eventually be replaced or integrated with a full inventory system.
    /// </summary>
    public static class PlayerInventory
    {
        /// <summary>
        /// Placeholder method to check if the player has the required materials.
        /// </summary>
        /// <param name="costs">A list of MaterialCost structs/classes detailing required materials.</param>
        /// <returns>True if player has materials (currently always true for placeholder), false otherwise.</returns>
        public static bool HasMaterials(List<MaterialCost> costs)
        {
            if (costs == null || costs.Count == 0)
            {
                Debug.Log("PlayerInventory (Placeholder): No materials required.");
                return true;
            }

            // Log the materials being checked
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("PlayerInventory (Placeholder): Checking for materials: ");
            for (int i = 0; i < costs.Count; i++)
            {
                sb.AppendFormat("{0}x {1}", costs[i].quantity, costs[i].material != null ? costs[i].material.itemName : "UNKNOWN MATERIAL");
                if (i < costs.Count - 1) sb.Append(", ");
            }
            Debug.Log(sb.ToString());

            // In a real system, you would iterate through costs and check against actual player inventory.
            Debug.Log("PlayerInventory (Placeholder): HasMaterials called. Returning true (placeholder).");
            return true;
        }

        /// <summary>
        /// Placeholder method to add an item to the player's inventory.
        /// </summary>
        /// <param name="item">The ItemData ScriptableObject of the item to add.</param>
        /// <param name="quantity">The quantity of the item to add.</param>
        public static void AddItem(ItemData item, int quantity)
        {
            if (item == null)
            {
                Debug.LogError("PlayerInventory (Placeholder): Cannot add null item to inventory.");
                return;
            }
            if (quantity <= 0)
            {
                Debug.LogWarningFormat("PlayerInventory (Placeholder): Attempted to add {0} quantity of {1}. Quantity must be positive.", quantity, item.itemName);
                return;
            }
            Debug.LogFormat("PlayerInventory (Placeholder): AddItem called for {0} (x{1}). (Placeholder - item not actually added)", item.itemName, quantity);
            // In a real system, this would interact with the player's inventory data.
        }
    }
}
