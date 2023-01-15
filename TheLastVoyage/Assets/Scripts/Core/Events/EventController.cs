using Core.Control;
using events;
using Events;
using UnityEngine;
using Zenject;

namespace GameSession.Events {

    public class EventController : MonoBehaviour {

        [Inject]
        private GameEventPool _gameEventPool;

        [Inject]
        private EventView _eventView;

        [Inject]
        private TimeEventController _timeEventController;

        [field: Inject]
        public ShipCharacteristics shipCharacteristics { get; private set; }

        //todo: find out if Inject field without set property works correctly
        [field: Inject]
        public GameTimer gameTimer { get; }


        private void Awake() {
            _timeEventController.OnTimerEvent += TimerEventHandle;
        }

        private void TimerEventHandle(BaseGameEvent timerEvent) {
            EventHandle(timerEvent);
        }

        private void UpdateUI(BaseGameEvent baseGameEvent) {
            _eventView.UpdateUiForEvent(baseGameEvent);
        }

        private void EventHandle(BaseGameEvent gameEvent) {
            UpdateUI(gameEvent);
        }
    }

}