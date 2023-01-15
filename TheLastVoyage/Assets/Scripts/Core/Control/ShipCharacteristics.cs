using UnityEngine;
using UnityEngine.UI;

namespace Core.Control {
    public class ShipCharacteristics : MonoBehaviour {
       
        [SerializeField] 
        private Slider _hungerIndicatorSlider;
        
        [SerializeField] 
        private Slider _moraleIndicatorSlider;
        
        [SerializeField] 
        private Slider _healthIndicatorSlider;

        public void IncreaseHungerIndicator(int value) {
            _hungerIndicatorSlider.value += value;
        }
        
        public void DecreaseHungerIndicator(int value) {
            _hungerIndicatorSlider.value -= value;
        }
        
        public void IncreaseMoraleIndicator(int value) {
            _moraleIndicatorSlider.value += value;
        }
        
        public void DecreaseMoraleIndicator(int value) {
            _moraleIndicatorSlider.value -= value;
        }
        
        public void IncreaseHealthIndicator(int value) {
            _healthIndicatorSlider.value += value;
        }
        
        public void DecreaseHealthIndicator(int value) {
            _healthIndicatorSlider.value -= value;
        }
    }
}