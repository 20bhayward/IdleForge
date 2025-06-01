// Assets/Scripts/Crafting/Data/WeaponData.cs
using UnityEngine;
using CraftingSystem.Enums; // For WeaponType

namespace CraftingSystem.Data
{
    [CreateAssetMenu(fileName = "NewWeapon", menuName = "Crafting System/Data/Weapon")]
    public class WeaponData : ItemData
    {
        [Header("Weapon Specific Stats")]
        public float baseDamage;
        public float durability = 100f; // Max durability
        public WeaponType weaponType;

        // Example of overriding OnValidate if needed for weapon-specific logic
        protected override void OnValidate()
        {
            base.OnValidate(); // Call base class validation
            // Weapon specific validation, e.g., ensuring baseDamage is positive
            if (baseDamage < 0) baseDamage = 0;
            isStackable = false; // Weapons are typically not stackable
            maxStackSize = 1;
        }
    }
}
