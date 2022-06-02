using UnityEngine;
using Newtonsoft.Json;
using Model;
using UI;
using Managers;
using System.Collections.Generic;
using System.Threading.Tasks;

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

            var completedTournamentsWindow = uniManager
                    .ShowWindow<CompletedTournaments>( new CompletedTournaments.CompletedTournamentsData(modelList) );

            if(completedTournamentsWindow == null)
                return;  

            (completedTournamentsWindow as CompletedTournaments).OnRequestForLeaderoard += id => { 
                OnRequestForLeaderoard(id);
                };      
        }

        private async void OnRequestForLeaderoard( string id )
        {
            //show loading screen
            var model = await LoadLeaderboardMenu(id);
            //hide loading scree
            var completedTournamentsWindow = uniManager
                    .ShowWindow<TournamentInfo>( new TournamentInfo.TournamentInfoData(model) );
            
        }

        private async Task<TournamentExtendedModel> LoadLeaderboardMenu(string leaderBoardId)
        {
            var result = await NetworkManager.GetTournamentDetails(leaderBoardId);
            var converted = JsonConvert.DeserializeObject<Dto.TournamentDetails.Root>(result);

            var model = new TournamentExtendedModel(converted.Content.TournamentDetails);
            return model;
        }
    }
}