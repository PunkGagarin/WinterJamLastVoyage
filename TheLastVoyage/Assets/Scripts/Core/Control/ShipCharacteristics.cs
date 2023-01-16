using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Core.Control {
    public class ShipCharacteristics : MonoBehaviour {
       
        [SerializeField] 
        private Slider _hungerIndicatorSlider;
        
        [SerializeField] 
        private Slider _moraleIndicatorSlider;
        
        [SerializeField] 
        private Slider _healthIndicatorSlider;
        
        [SerializeField] 
        private TextMeshProUGUI _hungerIndicatorText;
        
        [SerializeField] 
        private TextMeshProUGUI _moraleIndicatorText;
        
        [SerializeField] 
        private TextMeshProUGUI _healthIndicatorText;
        
        [HideInInspector]
        public UnityEvent OnDie = new UnityEvent();
        
        public void IncreaseHungerIndicator(int value) {
            _hungerIndicatorText.text = $"+{value.ToString()}";
            _hungerIndicatorText.color = Color.green;
            _hungerIndicatorText.gameObject.SetActive(true);
            StartCoroutine(WaitHandler(() => _hungerIndicatorText.gameObject.SetActive(false)));
            
            _hungerIndicatorSlider.value += value;
        }
        
        public void DecreaseHungerIndicator(int value) {
            _hungerIndicatorText.text = $"-{value.ToString()}";
            _hungerIndicatorText.color = Color.red;
            _hungerIndicatorText.gameObject.SetActive(true);
            StartCoroutine(WaitHandler(() => _hungerIndicatorText.gameObject.SetActive(false)));
            
            _hungerIndicatorSlider.value -= value;
        }
        
        public void IncreaseMoraleIndicator(int value) {
            _moraleIndicatorText.text = $"+{value.ToString()}";
            _moraleIndicatorText.color = Color.green;
            _moraleIndicatorText.gameObject.SetActive(true);
            StartCoroutine(WaitHandler(() => _moraleIndicatorText.gameObject.SetActive(false)));
            
            _moraleIndicatorSlider.value += value;
        }
        
        public void DecreaseMoraleIndicator(int value) {
            _moraleIndicatorText.text = $"-{value.ToString()}";
            _moraleIndicatorText.color = Color.red;
            _moraleIndicatorText.gameObject.SetActive(true);
            StartCoroutine(WaitHandler(() => _moraleIndicatorText.gameObject.SetActive(false)));
            
            _moraleIndicatorSlider.value -= value;
        }
        
        public void IncreaseHealthIndicator(int value) {
            
            _healthIndicatorText.text = $"+{value.ToString()}";
            _healthIndicatorText.color = Color.green;
            _healthIndicatorText.gameObject.SetActive(true);
            StartCoroutine(WaitHandler(() => _healthIndicatorText.gameObject.SetActive(false)));
            
            _healthIndicatorSlider.value += value;
        }
        
        public void DecreaseHealthIndicator(int value) {
            _healthIndicatorText.text = $"-{value.ToString()}";
            _healthIndicatorText.color = Color.red;
            _healthIndicatorText.gameObject.SetActive(true);
            StartCoroutine(WaitHandler(() => _healthIndicatorText.gameObject.SetActive(false)));
            
            _healthIndicatorSlider.value -= value;

            if (_healthIndicatorSlider.value <= 0) {
                OnDie?.Invoke();
            }
        }
        
        private IEnumerator WaitHandler(Action then) {
            
            yield return new WaitForSeconds(1f);
            
            then?.Invoke();
        }
    }
}