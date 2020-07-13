namespace Raiding.Model
{
    public class Druid : BaseHero
    {
        public override int Power => 80;

        public Druid(string name) 
            : base(name)
        {
        }

        public override string CastAbility()
        {
            return $"{base.CastAbility()} healed for {Power}";
        }
    }
}