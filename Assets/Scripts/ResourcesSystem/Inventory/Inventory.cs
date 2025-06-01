using System;
using System.Collections.Generic;
using System.Linq;
using ResourcesSystem; // Required for ItemData, MaterialCost

namespace ResourcesSystem.Inventory
{
    /// <summary>
    /// Manages a collection of items in inventory slots.
    /// </summary>
    public class Inventory
    {
        private List<InventorySlot> slots;
        private int maxSlots; // -1 for dynamic size

        /// <summary>
        /// Initializes a new instance of the <see cref="Inventory"/> class.
        /// </summary>
        /// <param name="initialMaxSlots">The maximum number of slots in the inventory. -1 for dynamic size.</param>
        public Inventory(int initialMaxSlots = -1)
        {
            slots = new List<InventorySlot>();
            maxSlots = initialMaxSlots;
        }

        /// <summary>
        /// Adds an item to the inventory.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <param name="quantity">The quantity of the item to add.</param>
        /// <returns>True if any quantity of the item was successfully added, false otherwise.</returns>
        public bool AddItem(ItemData item, int quantity = 1)
        {
            if (item == null || quantity <= 0)
            {
                return false;
            }

            bool itemAdded = false;
            int remainingQuantity = quantity;

            if (item.isStackable)
            {
                // Try to add to existing stacks first
                foreach (InventorySlot slot in slots)
                {
                    if (slot.itemData == item && !slot.IsFull())
                    {
                        int canAdd = item.maxStack - slot.quantity;
                        int amountToAdd = Math.Min(remainingQuantity, canAdd);
                        slot.AddQuantity(amountToAdd);
                        remainingQuantity -= amountToAdd;
                        itemAdded = true;
                        if (remainingQuantity == 0) break;
                    }
                }

                // If quantity remains, try to add to new slots
                while (remainingQuantity > 0)
                {
                    if (maxSlots != -1 && slots.Count >= maxSlots)
                    {
                        break; // Inventory is full
                    }
                    int amountForNewSlot = Math.Min(remainingQuantity, item.maxStack);
                    InventorySlot newSlot = new InventorySlot(item, amountForNewSlot);
                    slots.Add(newSlot);
                    remainingQuantity -= amountForNewSlot;
                    itemAdded = true;
                }
            }
            else // Non-stackable items
            {
                for (int i = 0; i < quantity; i++)
                {
                    if (maxSlots != -1 && slots.Count >= maxSlots)
                    {
                        break; // Inventory is full
                    }
                    InventorySlot newSlot = new InventorySlot(item, 1);
                    slots.Add(newSlot);
                    itemAdded = true;
                    remainingQuantity--;
                }
            }
            return itemAdded || (quantity > 0 && remainingQuantity < quantity); // True if any part was added
        }

        /// <summary>
        /// Removes an item from the inventory.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        /// <param name="quantity">The quantity of the item to remove.</param>
        /// <returns>True if the specified quantity was successfully removed, false otherwise.</returns>
        public bool RemoveItem(ItemData item, int quantity = 1)
        {
            if (item == null || quantity <= 0)
            {
                return false;
            }

            int quantityRemoved = 0;
            for (int i = slots.Count - 1; i >= 0; i--)
            {
                InventorySlot slot = slots[i];
                if (slot.itemData == item)
                {
                    int canRemove = Math.Min(quantity - quantityRemoved, slot.quantity);
                    slot.RemoveQuantity(canRemove);
                    quantityRemoved += canRemove;

                    if (slot.quantity == 0)
                    {
                        slots.RemoveAt(i);
                    }

                    if (quantityRemoved >= quantity)
                    {
                        break;
                    }
                }
            }
            return quantityRemoved >= quantity;
        }

        /// <summary>
        /// Checks if the inventory contains a specific quantity of an item.
        /// </summary>
        /// <param name="item">The item to check for.</param>
        /// <param name="quantity">The required quantity.</param>
        /// <returns>True if the item exists in the required quantity, false otherwise.</returns>
        public bool HasItem(ItemData item, int quantity = 1)
        {
            if (item == null || quantity <= 0)
            {
                // Consider if quantity <= 0 should be true (nothing required) or an error.
                // For now, sticking to the prompt's "true".
                return true;
            }
            return GetItemCount(item) >= quantity;
        }

        /// <summary>
        /// Checks if the inventory contains all specified materials.
        /// </summary>
        /// <param name="materialCosts">A list of materials and their required quantities.</param>
        /// <returns>True if all materials are present in sufficient quantities, false otherwise.</returns>
        public bool HasMaterials(List<MaterialCost> materialCosts)
        {
            if (materialCosts == null || materialCosts.Count == 0)
            {
                return true;
            }
            foreach (MaterialCost material in materialCosts)
            {
                if (!HasItem(material.itemData, material.quantity))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Consumes a list of materials from the inventory.
        /// </summary>
        /// <param name="materialCosts">The list of materials to consume.</param>
        public void ConsumeMaterials(List<MaterialCost> materialCosts)
        {
            if (materialCosts == null)
            {
                return;
            }
            foreach (MaterialCost material in materialCosts)
            {
                RemoveItem(material.itemData, material.quantity);
            }
        }

        /// <summary>
        /// Gets the total count of a specific item in the inventory.
        /// </summary>
        /// <param name="item">The item to count.</param>
        /// <returns>The total quantity of the item in the inventory.</returns>
        public int GetItemCount(ItemData item)
        {
            if (item == null)
            {
                return 0;
            }
            return slots.Where(slot => slot.itemData == item).Sum(slot => slot.quantity);
        }

        /// <summary>
        /// Gets a copy of all items currently in the inventory.
        /// </summary>
        /// <returns>A new list containing all inventory slots.</returns>
        public List<InventorySlot> GetAllItems()
        {
            return new List<InventorySlot>(slots);
        }

        /// <summary>
        /// Checks if the inventory is full (i.e., no more new slots can be added).
        /// This does not necessarily mean all existing slots are at their max stack capacity.
        /// </summary>
        /// <returns>True if the inventory cannot accept any new slots, false otherwise.</returns>
        public bool IsFull()
        {
            if (maxSlots == -1) // Dynamic size
            {
                return false;
            }
            // Check if we have reached the maximum number of slots.
            // Further checks could be added for stackable items if all slots are full
            // and no existing slot can accept more of a particular item, but the current
            // definition is about adding *new* slots.
            return slots.Count >= maxSlots;
        }

        /// <summary>
        /// Removes all items from the inventory.
        /// </summary>
        public void Clear()
        {
            slots.Clear();
        }
    }
}
