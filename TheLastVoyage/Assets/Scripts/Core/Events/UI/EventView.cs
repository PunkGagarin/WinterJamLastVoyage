using System.Collections.Generic;
using Core.Events.GameEvents;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Events.UI {

    public class EventView : MonoBehaviour {

        private const string DefaultAcceptText = "Accept";
        private const string DefaultRejectText = "Reject";

        private BaseGameEvent _currentEvent;

        [SerializeField]
        private GameObject _contentPanel;

        [SerializeField]
        private TextMeshProUGUI _eventText;

        [SerializeField]
        private Button _acceptButton;

        [SerializeField]
        private Button _rejectButton;

        [SerializeField]
        private Button _okayButton;

        private List<EventButton> _eventButtons;


        private void Awake() {
            _acceptButton.onClick.AddListener(AcceptEvent);
            _rejectButton.onClick.AddListener(RejectEvent);
            _okayButton.onClick.AddListener(HideContent);
        }


        private void AcceptEvent() {
            HideButtons();
            _currentEvent.Apply();
            ShowEventText(_currentEvent.acceptedText);
        }

        private void ShowEventText(string currentEventAcceptedText) {
        }

        private void RejectEvent() {
            HideButtons();

            ShowEventText(_currentEvent.rejectedText);
            _currentEvent.Reject();
        }

        public void UpdateUiForEvent(BaseGameEvent baseGameEvent) {
            ShowContent();
            ShowButtons();
            _currentEvent = baseGameEvent;

            _eventText.text = baseGameEvent.gameEventText;
            if (baseGameEvent.acceptButtonText != null) {
                _acceptButton.GetComponentInChildren<TextMeshProUGUI>().text = baseGameEvent.acceptButtonText;
            }
            if (baseGameEvent.rejectButtonText != null) {
                _rejectButton.GetComponentInChildren<TextMeshProUGUI>().text = baseGameEvent.rejectButtonText;
            }
        }

        private void ShowContent() {
            _contentPanel.SetActive(true);
        }

        private void HideContent() {
            _okayButton.gameObject.SetActive(false);
            _contentPanel.SetActive(false);
        }

        private void ShowButtons() {
            _acceptButton.gameObject.SetActive(true);
            _rejectButton.gameObject.SetActive(true);
            ShowOkayButton();
        }

        private void HideButtons() {
            SetDefaultButtonsText();
            _acceptButton.gameObject.SetActive(false);
            _rejectButton.gameObject.SetActive(false);
            ShowOkayButton();
        }

        private void SetDefaultButtonsText() {
            _acceptButton.GetComponentInChildren<TextMeshProUGUI>().text = DefaultAcceptText;
            _acceptButton.GetComponentInChildren<TextMeshProUGUI>().text = DefaultRejectText;
        }

        private void ShowOkayButton() {
            _okayButton.gameObject.SetActive(true);
        }

        private void OnDestroy() {
            _acceptButton.onClick.RemoveAllListeners();
            _rejectButton.onClick.RemoveAllListeners();
        }
    }

}