using UnityEngine;
using Model;
using TMPro;
using UnityEngine.UI;
using Config;

namespace UI
{
    public class ParticipantRenderer : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text scorePosition;

        [SerializeField]
        private Image avatar;

        [SerializeField]
        private TMP_Text nickName;

        [SerializeField]
        private TMP_Text score;

        [SerializeField]
        private GameObject prizeObject;    

        [SerializeField]
        private TMP_Text prize;

        [SerializeField]
        private IconsList iconsList;

        public void Init(ParticipantModel model)
        {
            scorePosition.text = model.ScorePosition.ToString();
            avatar.sprite = iconsList.GetIcon(model.AvatarId);
            nickName.text = model.DisplayName;
            score.text = model.Score.ToString();
            
            if(model.PrizeAmountGems > 0)
            {
                prizeObject.SetActive(true);
                prize.text = model.PrizeAmountGems.ToString();
            }
            else
            {
                prizeObject.SetActive(false);
                prize.text = string.Empty;
            }
        }
    }
}

