using UnityEngine;
using Newtonsoft.Json;
using Model;
using UI;
using Managers;
using System.Collections.Generic;
using System.Threading.Tasks;

public class TestRun : MonoBehaviour
{
    [SerializeField]
    private CompletedTournaments completedTournament;
    
    [SerializeField]
    private TournamentInfo tournamentInfo;

    [SerializeField]
    private string leaderBoardId = "dab1bbcf-bd41-4c9c-b0c5-2af05dac9f4d";

    [ContextMenu("LoadTournamentList")]
    private async void LoadData()
    {
        var task = NetworkManager.GetListAsync();
        await task;

        Debug.Log($"task {task.Result}");
        var converted = JsonConvert.DeserializeObject<Dto.TournamentHistory.Root>(task.Result);
        var tournaments = converted.Content.tournaments;
        var modelList = new List<TournamentModel>();
        foreach(var tournametDto in tournaments)
        {
            Debug.Log($"tounament is {tournametDto}");
            modelList.Add(new TournamentModel(tournametDto));
        }

        completedTournament.Init( new CompletedTournaments.CompletedTournamentsData( modelList ) );
    }

    [ContextMenu("LoadDefaultTournament")]
    private async void LoadLeaderboardMenu()
    {
        var task = LoadLeaderboard(leaderBoardId);
        await task;
        var converted = JsonConvert.DeserializeObject<Dto.TournamentDetails.Root>(task.Result);
        Debug.Log($"converted {converted}");
        var model = new TournamentExtendedModel(converted.Content.TournamentDetails);
        tournamentInfo.gameObject.SetActive(true);
        tournamentInfo.Init( new TournamentInfo.TournamentInfoData( model) );
    }

    private async Task<string> LoadLeaderboard(string id)
    {
        var task = await NetworkManager.GetTournamentDetails(id);
        return task;
    }
}
