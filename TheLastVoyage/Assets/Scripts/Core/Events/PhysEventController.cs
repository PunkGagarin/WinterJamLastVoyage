using Core.Events.GameEvents;
using Core.Events.GameEvents.PhysEvents;
using Core.Events.Pools;
using Core.Events.UI;
using UnityEngine;
using Zenject;

namespace Core.Events {

    public class PhysEventController : MonoBehaviour {

        [Inject]
        private GameEventPool _gameEventPool;

        [Inject]
        private EventView _eventView;

        private void Awake() {
            _gameEventPool.InitPool();
        }

        private void UpdateUI(BaseGameEvent baseGameEvent) {
            _eventView.UpdateUiForEvent(baseGameEvent);
        }

        public void EventHandle(BasePhysicalEvent gameEvent) {
            UpdateUI(gameEvent);
        }

        public BasePhysicalEvent GetRandomEvent() {
            return _gameEventPool.GetRandomPoolEvent();
        }
    }

}