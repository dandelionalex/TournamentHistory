using Dto.TournamentDetails;

namespace Model
{
    public class ParticipantModel 
    {
        public string DisplayName {get;}
        public int ScorePosition {get;}
        public int Score {get;}
        public string AvatarId {get;}
        public int PrizeAmountGems {get;}
        public bool IsYou {get;}

        public ParticipantModel(Participant participant)
        {
            DisplayName = participant.UserPublicData.DisplayName;
            ScorePosition = participant.ScorePosition;
            Score = participant.Score;
            AvatarId = participant.UserPublicData.AvatarImage.ID;
            PrizeAmountGems = participant.PrizeAmountGems;
            IsYou = participant.IsYou;
        }
    }
}

