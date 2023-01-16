using Core.Events.UI;
using UnityEngine;
using Zenject;

namespace Core.Events.Zenject {

    public class EventInstaller : MonoInstaller {


        [SerializeField]
        private PhysEventController _physEventController;
        
        [SerializeField]
        private TimeEventController _timeEventController;

        [SerializeField]
        private EventView _eventView;
        
        [SerializeField]
        private GameTimer _gameTimer;

        public override void InstallBindings() {
            /*
            Container.Bind<GameEventPool>()
                .FromNew()
                .AsSingle();
            
            Container.Bind<TimeEventPool>()
                .FromNew()
                .AsSingle();
            */
                
            Container.Bind<EventView>()
                .FromInstance(_eventView)
                .AsSingle();

            /*
            Container.Bind<GameTimer>()
                .FromInstance(_gameTimer)
                .AsSingle();

            Container.Bind<PhysEventController>()
                .FromInstance(_physEventController)
                .AsSingle();
            
            Container.Bind<TimeEventController>()
                .FromInstance(_timeEventController)
                .AsSingle();
            */
        }
    }

}