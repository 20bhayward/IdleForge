namespace ResourcesSystem
{
    public class ItemData
    {
        public string itemName;
        public bool isStackable;
        public int maxStack;

        public ItemData(string name, bool stackable, int max)
        {
            itemName = name;
            isStackable = stackable;
            maxStack = max;
        }
    }
}
