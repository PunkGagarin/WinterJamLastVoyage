using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Core.Team {

    public class TeamView : MonoBehaviour {

        [SerializeField]
        private TextMeshProUGUI _totalTamCounter;

        [SerializeField]
        private TeamPanel _fishingTeamPanel;

        [SerializeField]
        private TeamPanel _repairingTeamPanel;

        [SerializeField]
        private TeamPanel _restingTeamPanel;

        private List<TeamPanel> _panels = new();

        public Action<TeamPanelType, TeamPanelActionType> OnTeamPanelClick = delegate { };

        private void Start() {
            _fishingTeamPanel.OnButtonClick += OnTeamPanelClick;
            _repairingTeamPanel.OnButtonClick += OnTeamPanelClick;
            _restingTeamPanel.OnButtonClick += OnTeamPanelClick;

            _panels.AddRange(new List<TeamPanel> { _fishingTeamPanel, _repairingTeamPanel, _restingTeamPanel });
        }

        public void SetTeamCounter(int teamCounter) {
            _totalTamCounter.text = teamCounter.ToString();
        }

        public void SetCounter(TeamPanelType panelType, int counter) {
            _panels.First(panel => panel.teamPanelType == panelType).SetCounter(counter);
        }

        private void OnDestroy() {
            OnTeamPanelClick -= _fishingTeamPanel.OnButtonClick;
            OnTeamPanelClick -= _repairingTeamPanel.OnButtonClick;
            OnTeamPanelClick -= _restingTeamPanel.OnButtonClick;
        }
    }

}