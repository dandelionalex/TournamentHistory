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

        public void Init( List<TournamentModel> tournaments)
        {
            foreach(var tournament in tournaments)
            {
                var tournamentRenderer = Instantiate(tounamentRendererPrefab);
                tournamentRenderer.transform.SetParent(renderersContainer, false);
            }
        }
    }
}

