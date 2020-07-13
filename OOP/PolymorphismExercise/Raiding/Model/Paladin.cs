namespace Raiding.Model
{
    public class Paladin : BaseHero
    {
        public override int Power => 100;

        public Paladin(string name) 
            : base(name)
        {
        }

        public override string CastAbility()
        {
            return $"{base.CastAbility()} healed for {Power}";
        }
    }
}