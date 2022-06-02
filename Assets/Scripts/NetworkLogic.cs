using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;

public static class NetworkLogic 
{
    private const string tournamentResult = "https://parana-unity-test.s3.amazonaws.com/tournament-history.json";
    private const string detailsLink = "https://parana-unity-test.s3.amazonaws.com/tournament-details/";
    
    public static async Task<string> GetListAsync()
    {
        return await GetData(tournamentResult);
    }

    public static async Task<string> GetTournamentDetails(string tournamentId)
    {
        var url = $"{detailsLink}{tournamentId}.json";
        return await GetData(url);
    }

    public static async Task<string> GetData(string url)
    {
        using var webRequest = UnityWebRequest.Get(url);
        webRequest.SetRequestHeader("Content-Type", "application/json");
        var operation = webRequest.SendWebRequest();
        while(!operation.isDone)
            await Task.Yield();

        //webRequest.isNetworkError || webRequest.isHttpError
        if(webRequest.result == UnityWebRequest.Result.Success)
        {
            Debug.Log($"SUCCESS {webRequest.downloadHandler.text}");    
        }
        else
        {
            Debug.Log($"FAILED {webRequest.error}");
        }    
        
        return webRequest.downloadHandler.text; 
    }
}
