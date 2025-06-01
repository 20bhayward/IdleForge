using UnityEngine;

[CreateAssetMenu(fileName = "NewMaterialData", menuName = "Inventory/Material Data")]
public class MaterialData : ScriptableObject
{
    public string materialName = "New Material";
    public Sprite icon;
    public string description = "Material Description";
    // Add other relevant fields for a material, e.g.:
    // public int maxStackSize = 99;
    // public ItemRarity rarity = ItemRarity.Common; // Assuming an ItemRarity enum exists or will be created
}
