using System.Collections.Generic;
using Dto.TournamentDetails;

namespace Model
{
    public class TournamentExtendedModel 
    {
        public string TournamentName {get;}
        public List<ParticipantModel> Participants {get;}

        public TournamentExtendedModel(TournamentDetails tournamentDetails)
        {
            TournamentName = tournamentDetails.TournamentDefition.DisplayName;
            Participants = new List<ParticipantModel>();
            foreach(var participant in tournamentDetails.Participants)
            {
                var participantModel = new ParticipantModel(participant);
                Participants.Add(participantModel);
            }
        }
    }
}