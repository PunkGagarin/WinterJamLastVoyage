using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Control {
    public class ShipController : MonoBehaviour {
        
        [SerializeField]
        private GameObject _ship;
        
        [SerializeField]
        private SpriteRenderer _shipImage;
        
        [SerializeField]
        private Slider _speedSlider;
      
        [SerializeField]
        private ShipCharacteristics _shipCharacteristics;
      
        public float speed { get; set; }

        private float _offset;
        private float _yPosition;
        private bool _isDie;

        private void Start() {
            _yPosition = _ship.transform.position.y;
            
            _shipCharacteristics.OnDie.AddListener(Die);
        }

        private void Die() {
            _isDie = true;
            _speedSlider.value = 0;
            speed = 0;

            StartCoroutine(DieAnimationRoutine());
        }

        private void Update()
        {
            if (_isDie) {
                return;
            }
            
            speed = _speedSlider.value;
            
            RotateThings(); 
        }
        
        private void OnTriggerEnter(Collider other) {
            if (other.gameObject.tag.Contains("Coast")) {
                _speedSlider.value = 0;
                //_ship.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                _shipCharacteristics.DecreaseHealthIndicator(15);
                StartCoroutine(RotateShip());
                _offset = 0;
            }

            if (other.gameObject.tag.Contains("Obstacle")) {
                _shipCharacteristics.DecreaseHealthIndicator(10);
            }
        }

        private IEnumerator RotateShip() {
            float elapsed = 0f;
            while (elapsed < 3f) {
                elapsed += Time.deltaTime;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f),  Time.deltaTime * 3);
                yield return null;
            }
            _ship.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        
        private IEnumerator DieAnimationRoutine() {

            if (_shipImage.color.a <= 0) {
                yield break;
            }
            
            var tempColor = _shipImage.color;
            tempColor.a -= 0.1f;
            _shipImage.color = tempColor;
            yield return new WaitForSeconds(0.1f);
            
            StartCoroutine(DieAnimationRoutine());
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
                _speedSlider.value += 0.00001f;
            }
            
            if (Input.GetKey(KeyCode.DownArrow)) {
                _speedSlider.value -= 0.00001f;
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
