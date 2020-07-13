namespace Raiding.Model
{
    public class Rogue : BaseHero
    {
        public override int Power => 80;

        public Rogue(string name) 
            : base(name)
        {
        }

        public override string CastAbility()
        {
            return $"{base.CastAbility()} hit for {Power} damage";
        }
    }
}