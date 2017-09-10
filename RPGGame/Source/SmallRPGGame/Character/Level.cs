namespace SmallRPGGame.Character
{
    public class Level
    {
        public Level()
        {
        }

        private int Experience { get; set; }

        public int GetLevel()
        {
            return Experience / 100 + 1;
        }

        public void AddExperience(int experience)
        {
            Experience += experience;
        }
    }
}