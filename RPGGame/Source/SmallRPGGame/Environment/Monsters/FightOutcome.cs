namespace SmallRPGGame.Environment.Monsters
{
    public class FightOutcome
    {
        public FightOutcome(bool b, int i)
        {
            Outcome = b;
            Experience = i;
        }

        public bool Outcome { get; set; }

        public int Experience { get; set; }
    }
}