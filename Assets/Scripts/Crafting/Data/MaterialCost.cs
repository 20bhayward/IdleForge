// Assets/Scripts/Crafting/Data/MaterialCost.cs
using UnityEngine; // Required for ScriptableObject if MaterialData becomes one, or for other Unity types.
// No direct using for MaterialData yet as its script isn't created, will add if needed.

namespace CraftingSystem.Data
{
    [System.Serializable]
    public class MaterialCost
    {
        // It's good practice to forward declare the namespace if we know it.
        // Assuming MaterialData will be in CraftingSystem.Data namespace.
        public MaterialData material; // Reference to the MaterialData ScriptableObject
        public int quantity;

        /// <summary>
        /// Constructor for MaterialCost.
        /// </summary>
        /// <param name="materialRef">The material required.</param>
        /// <param name="qty">The quantity of the material required.</param>
        public MaterialCost(MaterialData materialRef, int qty)
        {
            material = materialRef;
            quantity = qty;
        }
    }
}
