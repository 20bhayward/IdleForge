// Assets/Scripts/Crafting/Data/MaterialData.cs
using UnityEngine;
using CraftingSystem.Enums; // For MaterialTier

namespace CraftingSystem.Data
{
    [CreateAssetMenu(fileName = "NewMaterial", menuName = "Crafting System/Data/Material")]
    public class MaterialData : ScriptableObject
    {
        [Header("Basic Information")]
        public string itemName;
        [TextArea(3, 5)]
        public string itemDescription;
        public Sprite icon;

        [Header("Material Properties")]
        public MaterialTier materialTier;
        public float baseValue; // For potential use in economy systems
    }
}
