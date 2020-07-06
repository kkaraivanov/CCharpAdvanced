namespace FootballTeamGenerator.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PlayerModel;
    using TeamModel;

    public static class GlobalValidator
    {
        private const int STATE_MIN_VALUE = 0;
        private const int STATE_MAX_VALUE = 100;

        public static void IsValidTeamName(this string teamName, List<Team> teams)
        {
            if (!teams.Any(x => x.Name == teamName))
                throw new ArgumentException(string.Format(GlobalConstants.InvalidCommandMissingTeamMessage, teamName));
        }

        public static void IsValidPlayer(this Player player,string playerName, string teamName)
        {
            if (player == null)
                throw new InvalidOperationException(string.Format(GlobalConstants.InvalidRemoveMissingPlayerMessage, playerName, teamName));
        }

        public static void IsValidState(this int value, string stateName)
        {
            if (value < STATE_MIN_VALUE || value > STATE_MAX_VALUE)
                throw new InvalidOperationException(string.Format(GlobalConstants.InvalidStatExceptionMessage,
                    stateName, STATE_MIN_VALUE, STATE_MAX_VALUE));
        }

        public static void IsNullOrWhiteSpace(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidOperationException(GlobalConstants.InvalidNameExceptionMessage);
        }
    }
}