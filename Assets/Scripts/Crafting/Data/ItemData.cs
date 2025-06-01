// Assets/Scripts/Crafting/Data/ItemData.cs
using UnityEngine;
using CraftingSystem.Enums; // For ItemQuality

namespace CraftingSystem.Data
{
    // Not using CreateAssetMenu here as this is a base class.
    // Derived classes will have their own menu items.
    public abstract class ItemData : ScriptableObject
    {
        [Header("Core Item Details")]
        public string itemID; // Should be unique
        public string itemName;
        [TextArea(3, 5)]
        public string itemDescription;
        public Sprite icon;

        [Header("Value & Quality")]
        public float baseSellValue;
        public ItemQuality itemQuality;

        [Header("Stacking")]
        public bool isStackable = true;
        public int maxStackSize = 99; // Default, only relevant if isStackable is true

        protected virtual void OnValidate()
        {
            if (string.IsNullOrEmpty(itemID))
            {
                itemID = System.Guid.NewGuid().ToString();
                #if UNITY_EDITOR
                UnityEditor.EditorUtility.SetDirty(this);
                #endif
            }
            if (!isStackable)
            {
                maxStackSize = 1;
            }
        }
    }
}
