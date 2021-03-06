using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Model;
using Managers;

namespace UI
{
    public class TournamentInfo : WindowBase
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
        private Button claimButtom;

        [SerializeField]
        private Transform renderersContainer;

        [SerializeField]
        private ParticipantRenderer participantRendererPrefabMy;

        [SerializeField]
        private ParticipantRenderer participantRendererPrefabOther;

        [SerializeField]
        private RectTransform listViewport;

        public override void Init(WindowData windowData)
        {
            if(windowData == null && !(windowData is TournamentInfoData))    
                return;

            var tournamentModel = (windowData as TournamentInfoData).Tournament;
           
            if(!string.IsNullOrEmpty( tournamentModel.ClaimId) )
            {
                claimButtom.gameObject.SetActive(true);
                listViewport.anchorMin = new Vector2(0, 0.182f);
            }
            else
            {
                claimButtom.gameObject.SetActive(false);
                listViewport.anchorMin = new Vector2(0, 0.103f);
            }  

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

        private void OnEnable() 
        {
            infoButton.onClick.AddListener(OnInfoButtonClick);
            topCloseButton.onClick.AddListener(OnCloseButtonClick);
            bottomCloseButton.onClick.AddListener(OnCloseButtonClick);
        }

        private void OnDisable() 
        {
            infoButton.onClick.RemoveAllListeners();
            topCloseButton.onClick.RemoveAllListeners();
            bottomCloseButton.onClick.RemoveAllListeners();
        }

        private void OnCloseButtonClick()
        {
            FindObjectOfType<UIManager>().CloseWindow<TournamentInfo>();
        }

        private void OnInfoButtonClick()
        {

        }

        public class TournamentInfoData : WindowData
        {
            public TournamentExtendedModel Tournament {get;}
            public TournamentInfoData(TournamentExtendedModel tournament)
            {
                Tournament = tournament;
            }
        }
    }
}