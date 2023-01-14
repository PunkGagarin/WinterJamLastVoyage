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


        private void Awake() {
            _timeEventController.OnTimerEvent += TimerEventHandle;
        }

        private void TimerEventHandle(BaseGameEvent timerEvent) {
            UpdateUI();
            EventHandle(timerEvent);
        }

        private void UpdateUI() {
        }

        public void EventHandle(BaseGameEvent gameEvent) {
            gameEvent.Apply(this);
        }
    }

}