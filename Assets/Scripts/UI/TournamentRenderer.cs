using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Model;
using System;

namespace UI
{
    public class TournamentRenderer : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text positionInRate;

        [SerializeField]
        private TMP_Text tournamentName;

        [SerializeField]
        private TMP_Text participants;

        [SerializeField]
        private TMP_Text tournamentDate;

        [SerializeField]
        private GameObject betterLuck;

        [SerializeField]
        private Button leaderbordButton;

        [SerializeField]
        private Button claimButton;

        [SerializeField]
        private TMP_Text prizeAmount;

        private Action<string> _leaderboardClicked;
        private TournamentModel _tournament;
        public void Init( TournamentModel tournament, Action<string> leaderboardClicked )
        {
            _leaderboardClicked = leaderboardClicked;
            _tournament = tournament;

            positionInRate.text = "1";
            tournamentName.text = tournament.DisplayName;
            participants.text = $"{tournament.ParticipantsCount} Players";
            tournamentDate.text = tournament.CreationTime.ToString("MM/dd/yy");

            if( tournament.PrizeAmount > 0 )
            {
                claimButton.gameObject.SetActive(true);
                betterLuck.SetActive(false);
                prizeAmount.text = $"${tournament.PrizeAmount}";
            }
            else
            {
                claimButton.gameObject.SetActive(false);
                betterLuck.SetActive(true);
            }
        }

        private void OnEnable() 
        {
            leaderbordButton.onClick.AddListener(OnLeaderbordButtonClick);
            claimButton.onClick.AddListener(OnClaimButtonClick);
        }

        private void OnDisable() 
        {
            leaderbordButton.onClick.RemoveAllListeners();
            claimButton.onClick.RemoveAllListeners();
        }

        private void OnLeaderbordButtonClick()
        {
            _leaderboardClicked.Invoke(_tournament.Id);
        }

        private void OnClaimButtonClick()
        {
            Debug.Log("claim for reward");
        }
    }
}

