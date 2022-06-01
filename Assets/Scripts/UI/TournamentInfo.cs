using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

        public void Init()
        {

        }
    }
}
