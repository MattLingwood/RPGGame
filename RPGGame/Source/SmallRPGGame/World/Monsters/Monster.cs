namespace SmallRPGGame.World.Monsters
{
    public class Monster
    {
        private MonsterName chicken;

        public Monster(MonsterName chicken)
        {
            this.chicken = chicken;
        }

        public MonsterName name { get; }
    }
}