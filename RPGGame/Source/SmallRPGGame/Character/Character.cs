using SmallRPGGame.Items;

namespace SmallRPGGame.Character
{
    public class Character
    {
        public Character(Inventory inventory)
        {
            Inventory = inventory;
            Level = new Level();
        }

        private Inventory Inventory { get; }

        public Level Level { get; }

        public void UseItem(Equipment equipment)
        {
            Inventory.UseItem(equipment);
        }
    }
}