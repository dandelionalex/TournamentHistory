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
        private TMP_Text score;

        [SerializeField]
        private Image avatar;
        
        public void Init(ParticipantModel model)
        {

        }
    }
}

