using System;
using Dto.TournamentHistory;

namespace Model
{
    public class TournamentModel 
    {
        public string Id { get; }
        public DateTime CreationTime { get; }
        public int ParticipantsCount { get; }
        public string DisplayName { get; }
        public int PrizeAmount { get; }
        public int PositionInRate { get; }

        public TournamentModel(Tournament tournament)
        {
            Id = tournament.ID;
            CreationTime = UnixTimeToDateTime(tournament.CreationTimestamp);
            ParticipantsCount = tournament.ParticipantsCount;
            DisplayName = tournament.TournamentDefinition.DisplayName;
            PrizeAmount = tournament.PrizeAmountCash;
        }

        private DateTime UnixTimeToDateTime(long unixtime)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixtime).ToLocalTime();
            return dtDateTime;
        }
    }
}

