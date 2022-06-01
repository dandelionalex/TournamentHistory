using UnityEngine;
using Newtonsoft.Json;
using Dto.TournamentHistory;
using Model;
using UI;
using System.Collections.Generic;

public class TestRun : MonoBehaviour
{
    [SerializeField]
    private CompletedTournaments completedTournament;
    
    [SerializeField]
    private TournamentInfo tournamentInfo;

    [ContextMenu("LoadData")]
    private async void LoadData()
    {
        var task = NetworkLogic.GetListAsync();
        await task;

        Debug.Log($"task {task.Result}");
        var converted = JsonConvert.DeserializeObject<Root>(task.Result);
        var tournaments = converted.Content.tournaments;
        var modelList = new List<TournamentModel>();
        foreach(var tournametDto in tournaments)
        {
            Debug.Log($"tounament is {tournametDto}");
            modelList.Add(new TournamentModel(tournametDto));
        }

        completedTournament.Init(modelList);
    }
}
