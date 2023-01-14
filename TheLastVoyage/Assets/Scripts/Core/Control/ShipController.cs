using UnityEngine;
using UnityEngine.UI;

namespace Core.Control {
    public class ShipController : MonoBehaviour {
        
        [SerializeField]
        private GameObject _ship;
        
        [SerializeField]
        private Slider _speedSlider;
      
        private float speed { get; set; }
      
        private void Update()
        {
            speed = _speedSlider.value;
            
            RotateThings(); 
        }
        private void RotateThings()
        {
            if (Input.GetKey(KeyCode.A)) {
                RotateLeft();
            }
            
            if (Input.GetKey(KeyCode.D)) {
                RotateRight();
            }
               
            if (Input.GetKey(KeyCode.UpArrow)) {
                _speedSlider.value += 0.0001f;
            }
            
            if (Input.GetKey(KeyCode.DownArrow)) {
                _speedSlider.value -= 0.0001f;
            }
        }

        private void RotateLeft()
        {
            _ship.transform.rotation = Quaternion.Euler(0f, 0f, 1.5f * speed) * _ship.transform.rotation;
            _ship.transform.Translate(Vector3.left * speed);
        }

        private void RotateRight()
        {
            _ship.transform.rotation = Quaternion.Euler(0f, 0f, -1.5f * speed) * _ship.transform.rotation;
            _ship.transform.Translate(Vector3.right * speed);
        }
    }
}
