using System;
using TMPro;
using UnityEngine;

namespace GameSession {

    public class GameTimer : MonoBehaviour {

        private float _currentTimer;

        private int _currentIntTimer;

        private bool _isTimerWorking;

        [SerializeField]
        private TextMeshProUGUI _timerText;

        [SerializeField]
        private int _startTimer;

        public Action OnTimerTick = delegate { };

        public Action OnTimerFinished = delegate { };

        private void Start() {
            _currentIntTimer = _startTimer;
            _currentTimer = _startTimer;
        }

        private void Update() {
            if (!_isTimerWorking) return;

            _currentTimer -= Time.deltaTime;

            int time = Mathf.CeilToInt(_currentTimer);
            if (_currentTimer < _currentIntTimer) {
                UpdateTime(time);
            }
        }

        private void UpdateTime(int time) {
            _currentIntTimer = time;
            if (time == 0) {
                OnTimerFinished.Invoke();
            } else {
                OnTimerTick.Invoke();
            }
        }

        public void StartTimer() {
            _isTimerWorking = true;
        }

        public void StopTimer() {
            _isTimerWorking = false;
        }
    }

}