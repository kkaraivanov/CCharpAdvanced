namespace FootballTeamGenerator.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PlayerModel;
    using TeamModel;

    public static class GlobalValidator
    {
        public static void IsValidTeamName(this string teamName, List<Team> teams)
        {
            if (!teams.Any(x => x.Name == teamName))
                throw new InvalidOperationException(string.Format(
                    GlobalConstants.InvalidCommandMissingTeamMessage, teamName));
        }

        public static void IsValidPlayer(this Player player, string playerName, string teamName)
        {
            if (player == null)
                throw new InvalidOperationException(string.Format(
                    GlobalConstants.InvalidRemoveMissingPlayerMessage, playerName, teamName));
        }

        public static void IsNullOrWhiteSpace(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidOperationException(GlobalConstants.InvalidNameExceptionMessage);
        }
    }
}