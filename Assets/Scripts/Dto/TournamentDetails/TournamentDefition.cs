using System.Collections.Generic;

namespace Dto.TournamentDetails
{
    public class TournamentDefition 
    {
        public string ID;
        public List<int> PrizesGems;
        public List<object> PrizesBonusCash;
        public List<object> PrizesCash;
        public string GameType;
        public int ParticipantsCount;
        public string DisplayName;
        public int EntryFeeCash;
        public int EntryFeeGems;
        public string TournamentType;
    }
}

