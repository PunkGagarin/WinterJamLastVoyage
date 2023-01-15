using Core.Events.GameEvents.PhysEvents;
using UnityEngine;
using Zenject;

namespace Core.Events.UI {
    public class GameEventTrigger : MonoBehaviour {

        public void SetActive(bool isActive) {
            transform.GetChild(0).gameObject.SetActive(isActive);
        }

        [Inject]
        public EventView eventView { get; set; }

        private void OnTriggerEnter(Collider other) {

            if (!transform.GetChild(0).gameObject.activeSelf) {
                return;
            }
            
            if (other.gameObject.tag.Contains("Ship")) {
                var baseGameEvent = Resources.Load<StormEvent>("Events/Physical/Storm");
                eventView.UpdateUiForEvent(baseGameEvent);

                gameObject.SetActive(false);

            }
        }
    }
}