namespace FootballTeamGenerator.Common
{
    public static class GlobalConstants
    {
        public static string InvalidNameExceptionMessage = "A name should not be empty.";
        public static string InvalidStatExceptionMessage = "{0} should be between {1} and {2}.";
        public static string InvalidRemoveMissingPlayerMessage = "Player {0} is not in {1} team.";
        public static string InvalidCommandMissingTeamMessage = "Team {0} does not exist.";
    }
}