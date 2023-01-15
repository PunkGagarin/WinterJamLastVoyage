using System;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Control {
    public class WaterController : MonoBehaviour {

        public ShipController shipController { get; set; }
        public UnityEvent OnEnter = new UnityEvent();
        public UnityEvent OnEnterDestroy = new UnityEvent();

        private void Update() {
            transform.Translate(Vector3.down * shipController.speed);
        }

        private void OnTriggerEnter(Collider other) {
            if (other.gameObject.tag.Contains("DestroyWaterTriggerPoint")) {
                OnEnterDestroy?.Invoke();
            } else {
                OnEnter?.Invoke();
            }
        }
    }
}