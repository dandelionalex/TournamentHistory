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

            if( string.IsNullOrEmpty(task.Result) )
            {
                var preloader = uniManager.GetOpenedWindow<PreloaderScreen>();
                (preloader as PreloaderScreen).SetDescription("network error");
                return;
            }
                
            var converted = JsonConvert.DeserializeObject<Dto.TournamentHistory.Root>(task.Result);
            var tournaments = converted.Content.tournaments;
            var modelList = new List<TournamentModel>();
            foreach(var tournametDto in tournaments)
            {
                modelList.Add(new TournamentModel(tournametDto));
            }

            var completedTournamentsWindow = uniManager
                    .ShowWindow<CompletedTournaments>( new CompletedTournaments.CompletedTournamentsData(modelList) );

            (completedTournamentsWindow as CompletedTournaments).OnRequestForLeaderoard += id => { 
                OnRequestForLeaderoard(id);
                };      
        }

        private async void OnRequestForLeaderoard( string leaderBoardId )
        {
            var loader = uniManager.ShowWindow<Loader>();
            var result = await NetworkManager.GetTournamentDetails(leaderBoardId);
            if( string.IsNullOrEmpty(result) )
            {
                (loader as Loader).SetDescription("network error");
                return;
            }
            
            var converted = JsonConvert.DeserializeObject<Dto.TournamentDetails.Root>(result);
            var model = new TournamentExtendedModel(converted.Content.TournamentDetails);
            uniManager.CloseWindow<Loader>();
            var completedTournamentsWindow = uniManager
                    .ShowWindow<TournamentInfo>( new TournamentInfo.TournamentInfoData(model) );
        }

    }
}