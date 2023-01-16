using Core.Control;
using Core.Events.Types;
using UnityEngine;
using Zenject;

namespace Core.Events.GameEvents.TimeEvents {

    [CreateAssetMenu(menuName = "GameEvent/Time/FairWinds", fileName = "FairWinds")]
    public class FairWindsEvent : BaseTimeEvent, IGameEvent {

        [Inject]
        private GameTimer _gameTimer;

        [Inject]
        private ShipCharacteristics _shipCharacteristics;

        [Header("Accept")]
        [SerializeField]
        private int _moraleBonus = 10;
        
        [SerializeField]
        private int _timeBonus = 30;
        
        [SerializeField]
        private int _hungerCost = 5;

        private void Awake() {
            type = TimeEventType.FairWinds;
        }


        public override void Apply() {
            _shipCharacteristics.IncreaseMoraleIndicator(_moraleBonus);
            _shipCharacteristics.DecreaseHungerIndicator(_hungerCost);
            _gameTimer.IncreaseTime(_timeBonus);
            //todo: implement
            //obstacleController.ReduceObstacleRate(10);
        }

        public override void Reject() {
            
        }
    }

}