using UnityEngine;
using UI;
using Managers;

namespace Logic
{
    public class TournamentLogic : MonoBehaviour
    {
        [SerializeField]
        private UIManager uniManager;
        
        void Start()
        {
            uniManager.ShowWindow<CompletedTournaments>();
        }
    }
}