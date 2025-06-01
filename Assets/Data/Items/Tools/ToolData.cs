using UnityEngine;

// Make sure the ToolType enum is accessible, e.g. if it's in a namespace, add:
// using MyGame.Enums; // Assuming ToolType is in MyGame.Enums namespace

[CreateAssetMenu(fileName = "NewToolData", menuName = "Inventory/Tool Data")]
public class ToolData : ItemData // Inherits from ItemData
{
    [Header("Tool Specific Data")]
    public ToolType toolType = ToolType.None;
    public float efficiency = 1.0f; // e.g., affects gather speed or yield bonus
    public float durability = 100f; // Max durability of the tool
    // public float currentDurability; // Could be added for runtime state if tools are ScriptableObject instances
                                     // For SO templates, current durability is better managed on an ItemInstance class
}
