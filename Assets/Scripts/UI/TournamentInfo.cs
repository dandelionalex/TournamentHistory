using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Model;

namespace UI
{
    public class TournamentInfo : MonoBehaviour
    {
        [SerializeField]
        private Button topCloseButton;

        [SerializeField]
        private Button infoButton;

        [SerializeField]
        private TMP_Text displayName;

        [SerializeField]
        private Button bottomCloseButton;

        [SerializeField]
        private Transform renderersContainer;

        [SerializeField]
        private ParticipantRenderer participantRendererPrefabMy;

        [SerializeField]
        private ParticipantRenderer participantRendererPrefabOther;

        public void Init(TournamentExtendedModel tournamentModel)
        {
            foreach(var participant in tournamentModel.Participants)
            {
                ParticipantRenderer participantRenderer = null;
                if(participant.IsYou)
                    participantRenderer = Instantiate(participantRendererPrefabMy);
                else
                    participantRenderer = Instantiate(participantRendererPrefabOther);

                participantRenderer.transform.SetParent(renderersContainer, false);   
                participantRenderer.Init(participant);
            }
        }
    }
}