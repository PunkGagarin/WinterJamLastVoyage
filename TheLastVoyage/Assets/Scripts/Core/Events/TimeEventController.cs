using Core.Events.GameEvents.TimeEvents;
using Core.Events.Pools;
using Core.Events.UI;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Core.Events {

    public class TimeEventController : MonoBehaviour {

        private int _eventTimer;

        [Inject]
        private TimeEventPool _timeEventPool;

        [Inject]
        private EventView _eventView;

        [Inject]
        private GameTimer _timer;

        [SerializeField]
        private int _minEventTimer = 15;

        [SerializeField]
        private int _maxEventTimer = 30;

        private void Awake() {
            _timer.OnTimerTick += OnTimerTickHandle;
            _timeEventPool.InitPool();
        }

        private void OnTimerTickHandle(int time) {
            if (time <= 5) return;

            _eventTimer--;
            if (_eventTimer <= 0) {
                ApplyTimeEvent();
                _eventTimer = CalculateNewEventTimer();
            }
        }

        private void ApplyTimeEvent() {
            BaseTimeEvent gameEvent = _timeEventPool.GetRandomPoolEvent();
            EventHandle(gameEvent);
        }

        private void EventHandle(BaseTimeEvent gameEvent) {
            UpdateUI(gameEvent);
        }

        private void UpdateUI(BaseTimeEvent gameEvent) {
            _eventView.UpdateUiForEvent(gameEvent);
        }

        private int CalculateNewEventTimer() {
            return Random.Range(_minEventTimer, _maxEventTimer);
        }
    }

}