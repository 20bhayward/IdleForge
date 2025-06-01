using System;
using ResourcesSystem; // Required for ItemData

namespace ResourcesSystem.Inventory
{
    /// <summary>
    /// Represents a single slot in an inventory, holding an item and its quantity.
    /// </summary>
    public class InventorySlot
    {
        /// <summary>
        /// Gets the data of the item in this slot.
        /// </summary>
        public ItemData itemData { get; private set; }

        /// <summary>
        /// Gets the quantity of the item in this slot.
        /// </summary>
        public int quantity { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InventorySlot"/> class.
        /// </summary>
        /// <param name="item">The item data for this slot.</param>
        /// <param name="quantity">The initial quantity of the item.</param>
        public InventorySlot(ItemData item, int quantity)
        {
            itemData = item;
            if (item != null && item.isStackable)
            {
                this.quantity = Math.Min(quantity, item.maxStack);
            }
            else if (item != null) // Not stackable, quantity should be 1 unless it's 0
            {
                this.quantity = Math.Min(quantity, 1);
            }
            else // No item
            {
                this.quantity = 0;
            }
        }

        /// <summary>
        /// Adds a specified amount to the quantity of the item in the slot.
        /// If the item is stackable, the quantity will not exceed its maxStack.
        /// Does nothing if itemData is null.
        /// </summary>
        /// <param name="amount">The amount to add.</param>
        public void AddQuantity(int amount)
        {
            if (itemData == null || amount <= 0)
            {
                return;
            }

            if (itemData.isStackable)
            {
                quantity = Math.Min(quantity + amount, itemData.maxStack);
            }
            else
            {
                // For non-stackable items, quantity can only be 0 or 1.
                // Adding quantity to a non-stackable item that already has 1 item doesn't make sense
                // unless we are replacing it. This method assumes we are just trying to increase.
                // If quantity is 0, it can become 1.
                if (this.quantity == 0) {
                    this.quantity = 1;
                }
            }
        }

        /// <summary>
        /// Removes a specified amount from the quantity of the item in the slot.
        /// Ensures the quantity does not go below 0.
        /// </summary>
        /// <param name="amount">The amount to remove.</param>
        public void RemoveQuantity(int amount)
        {
            if (itemData == null || amount <= 0)
            {
                return;
            }
            quantity = Math.Max(0, quantity - amount);
            if (quantity == 0)
            {
                // Optionally, clear itemData if quantity becomes 0
                // itemData = null;
            }
        }

        /// <summary>
        /// Checks if the slot is full (i.e., item is stackable and quantity has reached maxStack).
        /// </summary>
        /// <returns>True if the slot is full, false otherwise.</returns>
        public bool IsFull()
        {
            if (itemData == null)
            {
                return false;
            }
            return itemData.isStackable && quantity >= itemData.maxStack;
        }
    }
}
