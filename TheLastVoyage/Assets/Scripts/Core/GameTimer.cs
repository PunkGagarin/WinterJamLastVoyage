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

        public Action<int> OnTimerTick = delegate { };

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
            UpdateTimerUI(time);

            if (time <= 0) {
                OnTimerFinished.Invoke();
            } else {
                OnTimerTick.Invoke(time);
            }
        }

        private void UpdateTimerUI(int time) {
            _timerText.text = GetProperTimerFormat(time);
        }

        private string GetProperTimerFormat(int time) {
            TimeSpan timeSpan = TimeSpan.FromSeconds(time);
            return $"{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
        }

        public void StartTimer() {
            _isTimerWorking = true;
        }

        public void StopTimer() {
            _isTimerWorking = false;
        }

        public void DecreaseTime(int timeToDecrease) {
            _currentIntTimer -= timeToDecrease;
            _currentTimer -= timeToDecrease;
            
            UpdateTimerUI(_currentIntTimer);
        }
        
        public void IncreaseTime(int timeToIncrease) {
            _currentIntTimer += timeToIncrease;
            _currentTimer += timeToIncrease;
            
            UpdateTimerUI(_currentIntTimer);
        }
    }

}