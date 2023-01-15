using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Control {
    public class ShipController : MonoBehaviour {
        
        [SerializeField]
        private GameObject _ship;
        
        [SerializeField]
        private Slider _speedSlider;
      
        public float speed { get; set; }

        private float _offset;
        private float _yPosition;

        private void Start() {
            _yPosition = _ship.transform.position.y;
        }

        private void Update()
        {
            speed = _speedSlider.value;
            
            RotateThings(); 
        }
        
        private void OnTriggerEnter(Collider other) {
            if (other.gameObject.tag.Contains("Coast")) {
                _speedSlider.value = 0;
                _offset = 0;
                //_ship.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

                StartCoroutine(RotateShip());
            }
        }

        private IEnumerator RotateShip() {
            float elapsed = 0f;
            while (elapsed < 3f) {
                elapsed += Time.deltaTime;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f),  Time.deltaTime * 3);
                yield return null;
            }
        }

        private void RotateThings()
        {
            _ship.transform.Translate(new Vector3(_offset, 0, 0) * speed);
            var position = _ship.transform.position;
            _ship.transform.position = new Vector3(position.x, _yPosition, position.z);

            if (_ship.transform.eulerAngles == Vector3.zero) {
                _offset = 0;
            }
            
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

        private void RotateLeft() {
            _offset -= 0.001f;
            _ship.transform.rotation = Quaternion.Euler(0f, 0f, 1.5f * (speed * 5)) * _ship.transform.rotation;
        }

        private void RotateRight()
        {
            _offset += 0.001f;
            _ship.transform.rotation = Quaternion.Euler(0f, 0f, -1.5f * (speed * 5)) * _ship.transform.rotation;
        }
    }
}
