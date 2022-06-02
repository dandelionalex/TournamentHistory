using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Model;

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

        public void Init( TournamentModel tournament )
        {
            positionInRate.text = "1";
            tournamentName.text = tournament.DisplayName;
            participants.text = $"{tournament.ParticipantsCount} Players";
            Debug.Log($"time {tournament.CreationTime.Year} {tournament.CreationTime.Month} {tournament.CreationTime.Date} ");
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

        }

        private void OnClaimButtonClick()
        {

        }
    }
}

