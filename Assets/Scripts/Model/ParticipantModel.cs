using Dto.TournamentDetails;
using UnityEngine;

namespace Model
{
    public class ParticipantModel 
    {
        public string DisplayName {get;}
        public int ScorePosition {get;}
        public string AvatarId {get;}
        public int PrizeAmountGems {get;}
        public bool IsYou {get;}

        public ParticipantModel(Participant participant)
        {
            DisplayName = participant.UserPublicData.DisplayName;
            Debug.Log($"DisplayName {DisplayName}, avatarid: {participant.UserPublicData.AvatarImage.ID}");
            ScorePosition = participant.Score;
            AvatarId = participant.UserPublicData.AvatarImage.ID;
            PrizeAmountGems = participant.PrizeAmountGems;
            IsYou = participant.IsYou;
        }
    }
}

