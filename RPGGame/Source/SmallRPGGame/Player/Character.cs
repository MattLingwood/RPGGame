using SmallRPGGame.Items;

namespace SmallRPGGame.Player
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