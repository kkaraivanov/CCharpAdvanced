namespace MilitaryElite.Interface
{
    public interface IMission
    {
        string Name { get; }

        string State { get; }

        void CompleteMission();
    }
}