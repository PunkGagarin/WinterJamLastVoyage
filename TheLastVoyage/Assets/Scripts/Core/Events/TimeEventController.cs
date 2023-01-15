using System;
using GameSession;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace events {

    public class TimeEventController : MonoBehaviour {

        private int _eventTimer;

        private TimeEventPool _timeEventPool;

        [Inject]
        private GameTimer _timer;

        [SerializeField]
        private int _minEventTimer = 15;

        [SerializeField]
        private int _maxEventTimer = 30;

        public Action<BaseGameEvent> OnTimerEvent = delegate { };


        private void Awake() {
            _timer.OnTimerTick += OnTimerTickHandle;
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
            //todo: implement
            BaseGameEvent gameEvent = _timeEventPool.GetRandomEvent();
            OnTimerEvent.Invoke(gameEvent);
        }

        private int CalculateNewEventTimer() {
            return Random.Range(_minEventTimer, _maxEventTimer);
        }
    }

}