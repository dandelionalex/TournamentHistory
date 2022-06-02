using UnityEngine;
using Model;
using TMPro;
using UnityEngine.UI;

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

        public void Init(ParticipantModel model)
        {

        }
    }
}

