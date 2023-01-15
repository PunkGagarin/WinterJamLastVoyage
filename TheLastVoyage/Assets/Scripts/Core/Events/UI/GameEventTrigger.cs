using Core.Events.GameEvents;
using UnityEngine;
using Zenject;

namespace Core.Events.UI {
    public class GameEventTrigger : MonoBehaviour {
        [SerializeField] 
        private GameObject _gameEventSpriteGo;
        
        [SerializeField] 
        private BaseGameEvent _baseGameEvent;

        public EventView eventView { get; set; }

        private void OnTriggerEnter(Collider other) {

            if (other.gameObject.tag.Contains("Ship")) {
                _gameEventSpriteGo.SetActive(false);

                eventView.UpdateUiForEvent(_baseGameEvent);
            }
        }
    }
}