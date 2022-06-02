using Dto.TournamentDetails;

namespace Model
{
    public class ParticipantModel 
    {
        public string DisplayName {get;}
        public int ScorePosition {get;}
        public int AvatarId {get;}
        public int PrizeAmountGems {get;}
        public bool IsYou {get;}

        public ParticipantModel(Participant participant)
        {
            DisplayName = participant.UserPublicData.DisplayName;
            ScorePosition = participant.Score;
            AvatarId = participant.UserPublicData.AvatarImage.AvatarId;
            PrizeAmountGems = participant.PrizeAmountGems;
            IsYou = participant.IsYou;
        }
    }
}

