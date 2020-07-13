namespace Raiding.Model
{
    public abstract class BaseHero
    {
        public string Name { get;}

        public abstract int Power { get;}

        public BaseHero(string name)
        {
            Name = name;
        }

        public virtual string CastAbility()
        {
            return $"{this.GetType().Name} - { Name}";
        }
    }
}