using System;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Control {
    public class WaterController : MonoBehaviour {

        [field:SerializeField]
        public GameObject GameEventTriggerGameobject { get; set; }
        public ShipController shipController { get; set; }
        
        [HideInInspector]
        public UnityEvent OnEnter = new UnityEvent();
        [HideInInspector]
        public UnityEvent OnEnterDestroy = new UnityEvent();

        private void Update() {
            transform.Translate(Vector3.down * shipController.speed);
        }

        private void OnTriggerEnter(Collider other) {
            if (other.gameObject.tag.Contains("DestroyWaterTriggerPoint")) {
                OnEnterDestroy?.Invoke();
            } else if (other.gameObject.tag.Contains("SpawnWaterTriggerPoint")) {
                OnEnter?.Invoke();
            }
        }
    }
}