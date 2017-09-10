using SmallRPGGame.Player;

namespace SmallRPGGame.GameRunner
{
    public class GameRunner
    {
        public void InitialiseGame()
        {
            var newCharacter = new Character(new Inventory());
        }
    }
}