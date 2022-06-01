namespace Dto.TournamentHistory
{
    public class Tournament
    {
        public string ID;
        public int CreationTimestamp;
        public int SubmittedScoresCount;
        public int ParticipantsCount;
        public TournamentDefinition TournamentDefinition;
        public int PrizeAmountCash;
        public string ClaimID;
    }
}