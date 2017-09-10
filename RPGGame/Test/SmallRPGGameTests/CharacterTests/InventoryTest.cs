using System.Collections.Generic;
using Shouldly;
using SmallRPGGame.Character;
using SmallRPGGame.Items;
using Xunit;

namespace SmallRPGGameTests.CharacterTests
{
    public class InventoryTest
    {
        private readonly Inventory _inventory;

        public InventoryTest()
        {
            _inventory = new Inventory();
        }

        [Fact]
        public void WhenAnItemIsUsed_ItIsRemovedFromTheInventory()
        {
            _inventory.AddItem(Equipment.Spade);

            var itemAvailableForUse =_inventory.UseItem(Equipment.Spade);
            itemAvailableForUse.ShouldBeTrue();

            var itemAvailableForSecondUse = _inventory.UseItem(Equipment.Spade);
            itemAvailableForSecondUse.ShouldBeFalse();
        }
    }
}