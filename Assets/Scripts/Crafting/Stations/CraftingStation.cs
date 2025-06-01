// Assets/Scripts/Crafting/Stations/CraftingStation.cs
using UnityEngine;
using CraftingSystem.Data;
using CraftingSystem.Enums;
using System.Collections.Generic; // For Queue

namespace CraftingSystem.Stations
{
    public abstract class CraftingStation : MonoBehaviour
    {
        [Header("Station Properties")]
        public string stationName = "Generic Crafting Station";
        public CraftingStationType stationType; // To be set by derived classes or in Inspector

        [Header("Crafting State")]
        [SerializeField] protected RecipeData currentRecipe;
        [SerializeField] protected float craftingProgress; // 0 to 1
        [SerializeField] protected bool isCrafting;
        [SerializeField] protected Queue<RecipeData> craftingQueue = new Queue<RecipeData>();

        // Public accessors if needed, e.g., for UI
        public RecipeData CurrentRecipe => currentRecipe;
        public float CraftingProgress => craftingProgress;
        public bool IsCrafting => isCrafting;
        public int QueueCount => craftingQueue.Count;

        /// <summary>
        /// Checks if the player has the required materials for a given recipe.
        /// Placeholder for actual inventory check.
        /// </summary>
        public virtual bool CanCraftRecipe(RecipeData recipe)
        {
            if (recipe == null)
            {
                Debug.LogError($"{stationName}: Recipe is null, cannot check if craftable.");
                return false;
            }
            // Placeholder: Assume PlayerInventory static class exists
            Debug.Log($"{stationName}: Checking if player can craft {recipe.displayName}. Placeholder for PlayerInventory.HasMaterials(recipe.requiredMaterials).");
            // return PlayerInventory.HasMaterials(recipe.requiredMaterials); // Uncomment when PlayerInventory is implemented
            return true; // Placeholder: always return true for now
        }

        /// <summary>
        /// Adds a recipe to the crafting queue if it can be crafted.
        /// </summary>
        public virtual void AddToQueue(RecipeData recipe)
        {
            if (recipe == null)
            {
                Debug.LogError($"{stationName}: Cannot add null recipe to queue.");
                return;
            }

            if (recipe.craftingStationType != this.stationType)
            {
                Debug.LogWarning($"{stationName}: Recipe {recipe.displayName} requires station {recipe.craftingStationType}, but this is a {this.stationType}.");
                return;
            }

            if (CanCraftRecipe(recipe))
            {
                craftingQueue.Enqueue(recipe);
                Debug.Log($"{stationName}: Added {recipe.displayName} to crafting queue. Queue size: {craftingQueue.Count}");
                if (!isCrafting)
                {
                    StartCraftingNext();
                }
            }
            else
            {
                Debug.LogWarning($"{stationName}: Cannot craft {recipe.displayName}, missing materials (placeholder).");
            }
        }

        /// <summary>
        /// Starts crafting the next item in the queue.
        /// </summary>
        public virtual void StartCraftingNext()
        {
            if (isCrafting)
            {
                Debug.LogWarning($"{stationName}: Already crafting {currentRecipe?.displayName}. Cannot start new craft yet.");
                return;
            }

            if (craftingQueue.Count > 0)
            {
                currentRecipe = craftingQueue.Dequeue();
                isCrafting = true;
                craftingProgress = 0f;
                Debug.Log($"{stationName}: Starting craft for {currentRecipe.displayName}. Crafting time: {currentRecipe.baseCraftingTime}s.");
            }
            else
            {
                Debug.Log($"{stationName}: Crafting queue is empty. Nothing to craft.");
                currentRecipe = null;
            }
        }

        /// <summary>
        /// Updates the crafting progress. Called via Update() in a MonoBehaviour.
        /// </summary>
        protected virtual void UpdateCraftingProgress(float deltaTime)
        {
            if (!isCrafting || currentRecipe == null)
            {
                return;
            }

            if (currentRecipe.baseCraftingTime <= 0) // Avoid division by zero or negative time
            {
                craftingProgress = 1f; // Instantly complete if time is zero or less
            }
            else
            {
                craftingProgress += deltaTime / currentRecipe.baseCraftingTime;
            }

            OnCraftingTick();

            if (craftingProgress >= 1f)
            {
                craftingProgress = 1f;
                CompleteCraft();
            }
        }

        /// <summary>
        /// Finalizes the craft, adds item to inventory (placeholder), and starts next craft if available.
        /// </summary>
        protected virtual void CompleteCraft()
        {
            if (currentRecipe == null)
            {
                Debug.LogError($"{stationName}: CompleteCraft called with no current recipe.");
                isCrafting = false;
                return;
            }

            Debug.Log($"{stationName}: Completed crafting {currentRecipe.displayName} (x{currentRecipe.outputQuantity}). Placeholder for PlayerInventory.AddItem(currentRecipe.outputItem, currentRecipe.outputQuantity).");
            // PlayerInventory.AddItem(currentRecipe.outputItem, currentRecipe.outputQuantity);

            Debug.Log($"{stationName}: Granted {currentRecipe.baseXPGranted} XP (placeholder).");

            isCrafting = false;
            craftingProgress = 0f;
            RecipeData completedRecipe = currentRecipe;
            currentRecipe = null;

            if (craftingQueue.Count > 0)
            {
                StartCraftingNext();
            }
            else
            {
                Debug.Log($"{stationName}: Crafting queue empty after completing {completedRecipe.displayName}.");
            }
        }

        /// <summary>
        /// Called periodically during crafting.
        /// </summary>
        protected virtual void OnCraftingTick()
        {
            // Example: Debug.Log($"{stationName}: Crafting tick for {currentRecipe?.displayName}. Progress: {craftingProgress:P0}");
        }

        protected virtual void Update()
        {
            if (isCrafting)
            {
                UpdateCraftingProgress(Time.deltaTime);
            }
        }
    }
}
