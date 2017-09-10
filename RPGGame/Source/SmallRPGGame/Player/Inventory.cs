using System.Collections.Generic;
using SmallRPGGame.Items;

namespace SmallRPGGame.Player
{
    public class Inventory
    {
        public Inventory()
        {
            Contents = new List<Equipment>();
        }

        private List<Equipment> Contents { get; }


        public void AddItem(Equipment equipment)
        {
            Contents.Add(equipment);
        }

        public bool UseItem(Equipment equipment)
        {
            if (Contents.Contains(equipment))
            {
                Contents.Remove(equipment);
                return true;
            }
            return false;
        }
    }
}