namespace Raiding.Model
{
    public class Warrior : BaseHero
    {
        public override int Power => 100;

        public Warrior(string name) 
            : base(name)
        {
        }

        public override string CastAbility()
        {
            return $"{base.CastAbility()} hit for {Power} damage";
        }
    }
}