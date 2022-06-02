using UnityEngine;
using Newtonsoft.Json;
using Model;
using UI;
using Managers;
using System.Collections.Generic;

namespace Logic
{
    public class TournamentLogic : MonoBehaviour
    {
        [SerializeField]
        private UIManager uniManager;
        
        private void Start()
        {
            LoadTournamentHistory();
        }

        private async void LoadTournamentHistory()
        {
            var task = NetworkManager.GetListAsync();
            await task;

            var converted = JsonConvert.DeserializeObject<Dto.TournamentHistory.Root>(task.Result);
            var tournaments = converted.Content.tournaments;
            var modelList = new List<TournamentModel>();
            foreach(var tournametDto in tournaments)
            {
                modelList.Add(new TournamentModel(tournametDto));
            }

            uniManager.ShowWindow<CompletedTournaments>( new CompletedTournaments.CompletedTournamentsData(modelList) );
        }
    }
}