using GameSession.Events;
using UnityEngine;
using Zenject;

namespace events {

    public class EventInstaller : MonoInstaller {


        [SerializeField]
        private EventController _eventController;

        public override void InstallBindings() {
            Container.Bind<GameEventPool>()
                .FromNew()
                .AsSingle();

            Container.Bind<EventController>()
                .FromInstance(_eventController)
                .AsSingle();
        }
    }

}