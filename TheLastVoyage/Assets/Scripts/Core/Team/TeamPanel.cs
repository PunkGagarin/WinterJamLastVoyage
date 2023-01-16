using System;
using ModestTree;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Team {

    public class TeamPanel : MonoBehaviour {

        [field: SerializeField]
        public TeamPanelType teamPanelType { get; private set; }

        [SerializeField]
        private TextMeshProUGUI _teamCounterText;

        [SerializeField]
        private Button _addTeamMemberButton;

        [SerializeField]
        private Button _removeTeamMemberButton;

        public Action<TeamPanelType, TeamPanelActionType> OnButtonClick = delegate { };

        private void Awake() {
            Assert.IsNotNull(_addTeamMemberButton);
            Assert.IsNotNull(_removeTeamMemberButton);
        }

        private void Start() {
            _addTeamMemberButton.onClick.AddListener(ButtonAddClickHandle);
            _removeTeamMemberButton.onClick.AddListener(ButtonRemoveClickHandle);
        }

        private void ButtonAddClickHandle() {
            OnButtonClick.Invoke(teamPanelType, TeamPanelActionType.Add);
        }

        private void ButtonRemoveClickHandle() {
            OnButtonClick.Invoke(teamPanelType, TeamPanelActionType.Remove);
        }


        public void SetCounter(int counter) {
            _teamCounterText.text = counter.ToString();
        }
    }

}