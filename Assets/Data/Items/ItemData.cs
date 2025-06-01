using UnityEngine;

[CreateAssetMenu(fileName = "NewItemData", menuName = "Inventory/Item Data")]
public class ItemData : ScriptableObject
{
    public string itemName = "New Item";
    public Sprite icon; // Added icon as it's commonly needed for items
    public string description = "Item Description"; // Added description
}
