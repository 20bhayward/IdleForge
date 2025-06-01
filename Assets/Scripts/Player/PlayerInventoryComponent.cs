using UnityEngine;
using System.Collections.Generic;
using ResourcesSystem; // For ItemData, MaterialCost
using ResourcesSystem.Inventory; // For Inventory, InventorySlot

namespace Player
{
    /// <summary>
    /// Manages the player's inventory.
    /// This component wraps the Inventory class and provides a MonoBehaviour interface.
    /// Implements a singleton pattern for easy global access.
    /// </summary>
    public class PlayerInventoryComponent : MonoBehaviour
    {
        /// <summary>
        /// Gets the player's inventory instance.
        /// </summary>
        public Inventory inventory { get; private set; }

        /// <summary>
        /// The initial number of slots for the player's inventory.
        /// Configurable in the Unity Inspector.
        /// </summary>
        [SerializeField] private int initialInventorySlots = 20;

        /// <summary>
        /// Singleton instance of the PlayerInventoryComponent.
        /// </summary>
        public static PlayerInventoryComponent Instance { get; private set; }

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// Implements the singleton pattern and initializes the inventory.
        /// </summary>
        private void Awake()
        {
            // Singleton pattern implementation
            if (Instance == null)
            {
                Instance = this;
                // Optional: DontDestroyOnLoad(gameObject); if this inventory should persist across scenes
            }
            else
            {
                Debug.LogWarning("Duplicate PlayerInventoryComponent instance found. Destroying new one.");
                Destroy(gameObject);
                return;
            }

            // Initialize the inventory
            inventory = new Inventory(initialInventorySlots);
        }

        /// <summary>
        /// Adds an item to the player's inventory.
        /// Wrapper around Inventory.AddItem.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <param name="quantity">The quantity to add.</param>
        /// <returns>True if the item was successfully added, false otherwise.</returns>
        public bool AddItemToPlayer(ItemData item, int quantity = 1)
        {
            if (inventory == null) return false;
            // Future: Add player-specific logic or event triggers here
            return inventory.AddItem(item, quantity);
        }

        /// <summary>
        /// Removes an item from the player's inventory.
        /// Wrapper around Inventory.RemoveItem.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        /// <param name="quantity">The quantity to remove.</param>
        /// <returns>True if the item was successfully removed, false otherwise.</returns>
        public bool RemoveItemFromPlayer(ItemData item, int quantity = 1)
        {
            if (inventory == null) return false;
            return inventory.RemoveItem(item, quantity);
        }

        /// <summary>
        /// Checks if the player has a specific item in their inventory.
        /// Wrapper around Inventory.HasItem.
        /// </summary>
        /// <param name="item">The item to check for.</param>
        /// <param name="quantity">The required quantity.</param>
        /// <returns>True if the player has the item in the specified quantity, false otherwise.</returns>
        public bool HasItemInPlayerInventory(ItemData item, int quantity = 1)
        {
            if (inventory == null) return false; // Or based on HasItem's behavior for null item
            return inventory.HasItem(item, quantity);
        }

        /// <summary>
        /// Checks if the player has all specified materials in their inventory.
        /// Wrapper around Inventory.HasMaterials.
        /// </summary>
        /// <param name="materialCosts">A list of materials and their required quantities.</param>
        /// <returns>True if the player has all materials, false otherwise.</returns>
        public bool PlayerHasMaterials(List<MaterialCost> materialCosts)
        {
            if (inventory == null) return false;
            return inventory.HasMaterials(materialCosts);
        }

        /// <summary>
        /// Consumes a list of materials from the player's inventory.
        /// Wrapper around Inventory.ConsumeMaterials.
        /// </summary>
        /// <param name="materialCosts">The list of materials to consume.</param>
        public void ConsumeMaterialsFromPlayer(List<MaterialCost> materialCosts)
        {
            if (inventory == null) return;
            inventory.ConsumeMaterials(materialCosts);
        }

        /// <summary>
        /// Gets the total count of a specific item in the player's inventory.
        /// Wrapper around Inventory.GetItemCount.
        /// </summary>
        /// <param name="item">The item to count.</param>
        /// <returns>The total quantity of the item.</returns>
        public int GetPlayerItemCount(ItemData item)
        {
            if (inventory == null) return 0;
            return inventory.GetItemCount(item);
        }

        /// <summary>
        /// Gets a copy of all items currently in the player's inventory.
        /// Wrapper around Inventory.GetAllItems.
        /// </summary>
        /// <returns>A new list containing all inventory slots.</returns>
        public List<InventorySlot> GetAllPlayerItems()
        {
            if (inventory == null) return new List<InventorySlot>();
            return inventory.GetAllItems();
        }

        /// <summary>
        /// Checks if the player's inventory is full.
        /// Wrapper around Inventory.IsFull.
        /// </summary>
        /// <returns>True if the player's inventory is full, false otherwise.</returns>
        public bool IsPlayerInventoryFull()
        {
            if (inventory == null) return true; // If no inventory, it can't hold items
            return inventory.IsFull();
        }

        /// <summary>
        /// Removes all items from the player's inventory.
        /// Wrapper around Inventory.Clear.
        /// </summary>
        public void ClearPlayerInventory()
        {
            if (inventory == null) return;
            inventory.Clear();
        }
    }
}
