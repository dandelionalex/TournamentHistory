using UnityEngine;
using System.Collections.Generic;
using Model;

namespace UI
{
    public class CompletedTournaments : WindowBase
    {
        [SerializeField]
        private TournamentRenderer tounamentRendererPrefab;

        [SerializeField]
        private Transform renderersContainer;

        public override void Init( WindowData windowData )
        {
            if(windowData == null && !(windowData is CompletedTournamentsData))    
                return;

            var tournaments = (windowData as CompletedTournamentsData).Tournaments;

            foreach(var tournament in tournaments)
            {
                var tournamentRenderer = Instantiate(tounamentRendererPrefab);
                tournamentRenderer.Init(tournament);
                tournamentRenderer.transform.SetParent(renderersContainer, false);
            }
        }

        public class CompletedTournamentsData : WindowData
        {
            public List<TournamentModel> Tournaments {get;}
            public CompletedTournamentsData(List<TournamentModel> tournaments)
            {
                Tournaments = tournaments;
            }
        }
    }
}