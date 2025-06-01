using ResourcesSystem;

namespace ResourcesSystem
{
    public class MaterialCost
    {
        public ItemData itemData;
        public int quantity;

        public MaterialCost(ItemData data, int qty)
        {
            itemData = data;
            quantity = qty;
        }
    }
}
