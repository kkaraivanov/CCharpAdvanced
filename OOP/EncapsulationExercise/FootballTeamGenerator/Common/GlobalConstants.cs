namespace FootballTeamGenerator.Common
{
    public static class GlobalConstants
    {
        public const int STATE_MIN_VALUE = 0;
        public const int STATE_MAX_VALUE = 100;
        public const double STAT_DELIMITER = 5.0;
        public const string InvalidNameExceptionMessage = "A name should not be empty.";
        public const string InvalidStatExceptionMessage = "{0} should be between {1} and {2}.";
        public const string InvalidRemoveMissingPlayerMessage = "Player {0} is not in {1} team.";
        public const string InvalidCommandMissingTeamMessage = "Team {0} does not exist.";
    }
}