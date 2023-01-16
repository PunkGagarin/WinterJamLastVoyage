using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core.Team {

    public class TeamController : MonoBehaviour {

        public int teamCounter { get; private set; }

        [Inject]
        private TeamView _teamView;


        [field: SerializeField]
        public int maxTeamCounter { get; private set; } = 5;

        private readonly Dictionary<TeamPanelType, int> _counters = new() {
            { TeamPanelType.Fishing, 0 },
            { TeamPanelType.Repairing, 0 },
            { TeamPanelType.Resting, 0 }
        };

        private void Awake() {
            SetTeamCounter(maxTeamCounter);

            _teamView.OnTeamPanelClick += OnTeamPanelClickHandle;
        }

        private void SetTeamCounter(int teamCounter) {
            this.teamCounter = teamCounter;
            _teamView.SetTeamCounter(teamCounter);
        }

        private void OnTeamPanelClickHandle(TeamPanelType panelType, TeamPanelActionType actionType) {
            if (actionType == TeamPanelActionType.Add) {
                TryAddToPanel(panelType);
            } else {
                TryRemoveFromPanel(panelType);
            }
        }

        private void TryAddToPanel(TeamPanelType panelType) {
            if (HasNoFreeTeam()) return;
            
            DecreaseTeamCounter();
            IncreasePanelCounter(panelType);
        }

        private void TryRemoveFromPanel(TeamPanelType panelType) {
            if (_counters[panelType] <= 0) return;

            DecreasePanelCounter(panelType);
            IncreaseTeamCounter();
        }

        private void IncreaseTeamCounter() {
            teamCounter++;
            _teamView.SetTeamCounter(teamCounter);
        }

        private void DecreaseTeamCounter() {
            teamCounter--;
            _teamView.SetTeamCounter(teamCounter);
        }

        private void IncreasePanelCounter(TeamPanelType panelType) {
            _counters[panelType]++;
            _teamView.SetCounter(panelType, _counters[panelType]);
        }

        private void DecreasePanelCounter(TeamPanelType panelType) {
            _counters[panelType]--;
            _teamView.SetCounter(panelType, _counters[panelType]);
        }

        private bool HasNoFreeTeam() {
            return teamCounter <= 0;
        }
    }

}